using AutoLicensing.Models;
using AutoLicensing.Signer;

namespace AutoLicensing.Generator;

public class LicenseFactory : ILicenseFactory
{
    private readonly License _license = new();

    private ISigner _signer;

    public ILicenseFactory WithSigner(ISigner signer)
    {
        _signer = signer;
        return this;
    }

    public ILicenseFactory WithName(string name)
    {
        _license.LicenseName = name;
        return this;
    }

    public ILicenseFactory WithCustomerName(string customerName)
    {
        _license.CustomerName = customerName;
        return this;
    }

    public ILicenseFactory WithProduct(LicenseProduct product)
    {
        _license.Products.Add(product);
        return this;
    }

    public SignedLicense SignAndCreate()
    {
        var signedLicense = new SignedLicense(_license);

        _signer.Sign(signedLicense);

        return signedLicense;
    }
}