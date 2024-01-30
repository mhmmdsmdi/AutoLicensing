using AutoLicensing.Exceptions;
using AutoLicensing.Models;

namespace AutoLicensing.Extensions.DependencyInjection;

public interface ILicenseProvider
{
    bool IsFeatureEnabled(string featureName);

    LicenseAttribute GetAttribute(string attributeName);
}

public class LicenseProvider(License license, string productName) : ILicenseProvider
{
    public bool IsFeatureEnabled(string featureName)
    {
        var product = license.Products
            .FirstOrDefault(x => x.Name == productName);
        if (product is null)
            throw new AutoLicensingException("LicenseProduct name is not valid.");

        return product.IsFeatureEnabled(featureName);
    }

    public LicenseAttribute GetAttribute(string attributeName)
    {
        var product = license.Products
            .FirstOrDefault(x => x.Name == productName);
        if (product is null)
            throw new AutoLicensingException("LicenseProduct name is not valid.");

        return product.GetAttribute(attributeName);
    }
}