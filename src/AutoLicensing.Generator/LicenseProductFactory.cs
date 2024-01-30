using AutoLicensing.Models;

namespace AutoLicensing.Generator;

public class LicenseProductFactory : ILicenseProductFactory
{
    private readonly LicenseProduct _licenseProduct = new();

    public ILicenseProductFactory WithName(string name)
    {
        _licenseProduct.Name = name;
        return this;
    }

    public ILicenseProductFactory WithExpiryDate(DateTime expiryDate)
    {
        _licenseProduct.ExpiryDate = expiryDate;
        return this;
    }

    public ILicenseProductFactory WithFeature(string featureName, bool isEnable = true)
    {
        _licenseProduct.Features.Add(featureName, isEnable);
        return this;
    }

    public ILicenseProductFactory WithAttribute(string attributeName, string value)
    {
        _licenseProduct.Attributes.Add(new LicenseAttribute(attributeName, value));
        return this;
    }

    public ILicenseProductFactory WithAttribute(string attributeName, int value)
    {
        _licenseProduct.Attributes.Add(new LicenseAttribute(attributeName, value));
        return this;
    }

    public ILicenseProductFactory WithAttribute(string attributeName, decimal value)
    {
        _licenseProduct.Attributes.Add(new LicenseAttribute(attributeName, value));
        return this;
    }

    public LicenseProduct Create()
    {
        return _licenseProduct;
    }
}