using System.Text;
using AutoLicensing;
using AutoLicensing.Extensions;
using AutoLicensing.Generator;
using AutoLicensing.Generator.Extension;
using AutoLicensing.Models;
using AutoLicensing.Signer;

void Validate(string publicKey, string license)
{
    var signedLicense = Licenser.Verifier
        .WithRsaPublicKey(publicKey)
        .LoadAndVerify(license);

    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("License is valid");
    Console.ResetColor();

    //var f1 = signedLicense.License
    //.GetProduct("Application 3")?
    //.IsFeatureEnabled("Feature1");

    //var f2 = signedLicense.License
    //    .GetProduct("Application 1")?
    //    .IsFeatureEnabled("Feature3");
}

void GenerateLicense(out SigningKeyPair key, out SignedLicense signedLicense)
{
    key = LicenseKeyGenerator.GenerateRsaKeyPair();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Private Key :");
    Console.WriteLine(key.PrivateKey);
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine("Public Key :");
    Console.WriteLine(key.PublicKey);
    Console.WriteLine();

    signedLicense = new LicenseFactory()
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

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("License :");
    Console.WriteLine(signedLicense.Export());

    Console.ResetColor();
}

try
{
    Confuser.ConfusingBytes = "Some Random Bytes"u8.ToArray();
    GenerateLicense(out var key, out var signedLicense);

    Validate(key.PublicKey, signedLicense.Export());
}
catch (Exception e)
{
    Console.WriteLine(e);
}