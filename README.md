# AutoLicensing

[![NuGet](https://img.shields.io/nuget/v/AutoLicensing)](https://www.nuget.org/packages/AutoLicensing/)

This package provides an open-source license manager.

## Usage

Use this command to add AutoLicensing to your project.

```C#
dotnet add package AutoLicensing --version 1.0.5
```

### Generate license

```C#
    var key = LicenseKeyGenerator.GenerateRsaKeyPair();

    var privateKey = key.PrivateKey;
    var publicKey = key.PublicKey;

    var signedLicense = new LicenseFactory()
        .WithRsaPrivateKey(key.PrivateKey)
        .WithName("Enterprise License")
        .WithCustomerName("Some Guy")
        .WithProduct(new LicenseProductFactory()
            .WithName("Application 1")
            .WithExpiryDate(DateTime.Now.AddDays(180))
            .WithAttribute("Limitation 1", 100)
            .WithFeature("Feature 1")
            .WithFeature("Feature 2")
            .Create())
        .SignAndCreate();

        var licenseKey = signedLicense.Export();
```

### Verify license

```C#
    var signedLicense = Licenser.Verifier
        .WithRsaPublicKey(publicKey)
        .LoadAndVerify(licenseKey);
```

## Misc.

You can change the confusing bytes by using this code

```C#
    Confuser.ConfusingBytes = "Some random bytes"u8.ToArray();
```
