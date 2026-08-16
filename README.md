# AutoLicensing

[![NuGet](https://img.shields.io/nuget/v/AutoLicensing)](https://www.nuget.org/packages/AutoLicensing/)
[![NuGet](https://img.shields.io/nuget/v/AutoLicensing.Generator)](https://www.nuget.org/packages/AutoLicensing.Generator/)
[![NuGet](https://img.shields.io/nuget/v/AutoLicensing.AspNetCore)](https://www.nuget.org/packages/AutoLicensing.AspNetCore/)

Open-source license manager for .NET. Generate RSA-signed licenses, embed features and limits per product, and enforce them at runtime — including out-of-the-box ASP.NET Core middleware.

## Packages

| Package | Purpose |
| --- | --- |
| `AutoLicensing` | Core: license model, RSA signing/verification, key generation |
| `AutoLicensing.Generator` | Fluent license builders for issuing licenses |
| `AutoLicensing.AspNetCore` | DI registration + endpoint middleware that blocks disabled features |

## Install

```C#
dotnet add package AutoLicensing
dotnet add package AutoLicensing.Generator
dotnet add package AutoLicensing.AspNetCore
```

`AutoLicensing.Generator` and `AutoLicensing.AspNetCore` reference the core package — install only what you use.

## Frameworks

| Package | .NET 8 | .NET 9 | .NET 10 |
| --- | --- | --- | --- |
| `AutoLicensing` | ✅ | ✅ | ✅ |
| `AutoLicensing.Generator` | ✅ | — | ✅ |
| `AutoLicensing.AspNetCore` | ✅ | ✅ | ✅ |

## How it works

A license is a JSON payload — license name, customer, and one or more products. Each product carries:

- **Features** — named on/off switches
- **Attributes** — key/value limits (int, decimal, or string)
- **Issue / expiry dates**

The payload is signed with your RSA private key; the signature is XOR-obfuscated with the `Confuser` bytes. The result is exported as a single base64 string — the license key your customer installs.

Verification uses your **public key only**. You never ship the private key.

## Generate a license

```C#
var key = LicenseKeyGenerator.GenerateRsaKeyPair(); // keep PrivateKey to yourself

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

var licenseKey = signedLicense.Export(); // give this to the customer
```

## Verify a license

```C#
var signedLicense = Licenser.Verifier
    .WithRsaPublicKey(publicKey)
    .LoadAndVerify(licenseKey); // throws AutoLicensingException if the signature is invalid
```

## Read license data

```C#
var product = signedLicense.License.GetProduct("Application 1");

if (product.IsFeatureEnabled("Feature 1")) { /* feature gate */ }

var limit = product.GetAttribute("Limitation 1").AsInteger();
```

`LicenseAttribute` value converters: `AsString()`, `AsInteger()`, `AsDecimal()`.

## ASP.NET Core enforcement

Register the license and middleware in `Program.cs`:

```C#
builder.Services.AddAutoLicensing("Application 1", publicKey, licenseKey);

var app = builder.Build();

app.UseRouting();
app.UseAutoLicensing(); // register after UseRouting to keep streaming responses un-buffered
app.MapControllers();
```

`AddAutoLicensing` validates the signature up front and throws `AutoLicensingException` if the product name is unknown or the license is expired.

Gate any endpoint behind a feature with the `HasFeature` attribute — disabled features return **404 Not Found**:

```C#
[HasFeature("Feature 1")]
[HttpGet("premium")]
public IActionResult Premium() => Ok("Premium endpoint");
```

> **SSE / streaming:** the middleware only buffers the response when the endpoint is not yet resolved (i.e. registered *before* `UseRouting`). Register it **after** `UseRouting` so feature checks run before the endpoint and streaming responses (SSE, file downloads) pass through untouched.

## Customize the obfuscation bytes

Signature obfuscation must match between signer and verifier. Change the default on both sides:

```C#
Confuser.ConfusingBytes = "Some random bytes"u8.ToArray();
```

## Publishing to NuGet

Create and push all three packages with one script:

```powershell
.\scripts\publish.ps1 -ApiKey <your-api-key>
# or set the key once: $env:NUGET_API_KEY = "<your-api-key>"
```

Get an API key at https://www.nuget.org/account/apikeys. Push is permanent — the same version of a package ID can't be re-uploaded.

## License

MIT
