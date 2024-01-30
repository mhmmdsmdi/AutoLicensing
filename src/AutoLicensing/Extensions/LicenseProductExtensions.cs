using AutoLicensing.Exceptions;
using AutoLicensing.Models;

namespace AutoLicensing.Extensions;

public static class LicenseProductExtensions
{
    public static bool IsFeatureEnabled(this LicenseProduct licenseProduct, string featureName)
    {
        return licenseProduct.Features.ContainsKey(featureName) && licenseProduct.Features[featureName];
    }

    public static LicenseAttribute GetAttribute(this LicenseProduct licenseProduct, string attributeName)
    {
        var attribute = licenseProduct.Attributes
            .SingleOrDefault(x => x.Key == attributeName);
        if (attribute is null)
            throw new AutoLicensingException("Attribute not found.");

        return attribute;
    }
}