using AutoLicensing.Models;

namespace AutoLicensing.Generator;

public interface ILicenseProductFactory
{
    ILicenseProductFactory WithName(string name);

    ILicenseProductFactory WithExpiryDate(DateTime expiryDate);

    ILicenseProductFactory WithFeature(string featureName, bool isEnable = true);

    ILicenseProductFactory WithAttribute(string attributeName, string value);

    ILicenseProductFactory WithAttribute(string attributeName, int value);

    ILicenseProductFactory WithAttribute(string attributeName, decimal value);

    LicenseProduct Create();
}