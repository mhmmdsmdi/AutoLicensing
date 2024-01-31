using AutoLicensing.Exceptions;
using AutoLicensing.Models;

namespace AutoLicensing.Extensions.DependencyInjection;

public interface ILicenseProvider
{
    public SignedLicense SignedLicense { get; }

    public LicenseProduct? LicenseProduct { get; }

    bool IsFeatureEnabled(string featureName);

    LicenseAttribute GetAttribute(string attributeName);
}

public class LicenseProvider(SignedLicense signedLicense, string productName) : ILicenseProvider
{
    public SignedLicense SignedLicense { get; } = signedLicense;

    public LicenseProduct? LicenseProduct { get; } = signedLicense.License.GetProduct(productName);

    public bool IsFeatureEnabled(string featureName)
    {
        var product = signedLicense.License.GetProduct(productName);
        if (product is null)
            throw new AutoLicensingException("LicenseProduct name is not valid.");

        return product.IsFeatureEnabled(featureName);
    }

    public LicenseAttribute GetAttribute(string attributeName)
    {
        var product = signedLicense.License.GetProduct(productName);
        if (product is null)
            throw new AutoLicensingException("LicenseProduct name is not valid.");

        return product.GetAttribute(attributeName);
    }
}