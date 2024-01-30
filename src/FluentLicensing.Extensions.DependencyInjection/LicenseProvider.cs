using FluentLicensing.Exceptions;
using FluentLicensing.Models;

namespace FluentLicensing.Extensions.DependencyInjection;

public interface ILicenseProvider
{
    bool IsFeatureEnabled(string featureName);

    LicenseAttribute GetAttribute(string attributeName);
}

public class LicenseProvider(SignedLicense signedLicense, string productName) : ILicenseProvider
{
    public bool IsFeatureEnabled(string featureName)
    {
        var product = signedLicense.Products
            .FirstOrDefault(x => x.Name == productName);
        if (product is null)
            throw new FluentLicensingException("Product name is not valid.");

        return product.Features.ContainsKey(featureName) && product.Features[featureName];
    }

    public LicenseAttribute GetAttribute(string attributeName)
    {
        var product = signedLicense.Products
            .FirstOrDefault(x => x.Name == productName);
        if (product is null)
            throw new FluentLicensingException("Product name is not valid.");

        var attribute = product.Attributes
            .SingleOrDefault(x => x.Key == attributeName);
        if (attribute is null)
            throw new FluentLicensingException("Attribute not found.");

        return attribute;
    }
}