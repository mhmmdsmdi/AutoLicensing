using AutoLicensing.Exceptions;
using AutoLicensing.Extensions;
using AutoLicensing.Models;

namespace AutoLicensing.AspNetCore;

public interface ILicenseProvider
{
    public SignedLicense SignedLicense { get; }

    public LicenseProduct LicenseProduct { get; }

    bool IsFeatureEnabled(string featureName);

    LicenseAttribute GetAttribute(string attributeName);
}

public class LicenseProvider : ILicenseProvider
{
    public LicenseProvider(SignedLicense signedLicense, string productName)
    {
        SignedLicense = signedLicense;

        var licenseProduct = signedLicense.License.GetProduct(productName);

        LicenseProduct = licenseProduct ?? throw new AutoLicensingException("License product name is not valid.");

        if (DateTime.Now >= LicenseProduct.ExpiryDate)
            throw new AutoLicensingException($"License for {LicenseProduct.Name} product is expired.");
    }

    public SignedLicense SignedLicense { get; }

    public LicenseProduct LicenseProduct { get; }

    public bool IsFeatureEnabled(string featureName)
    {
        return LicenseProduct.IsFeatureEnabled(featureName);
    }

    public LicenseAttribute GetAttribute(string attributeName)
    {
        return LicenseProduct.GetAttribute(attributeName);
    }
}