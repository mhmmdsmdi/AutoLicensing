using AutoLicensing.Models;
using AutoLicensing.Signer;

namespace AutoLicensing.Generator;

public interface ILicenseFactory
{
    ILicenseFactory WithSigner(ISigner signer);

    ILicenseFactory WithName(string name);

    ILicenseFactory WithCustomerName(string customerName);

    ILicenseFactory WithProduct(LicenseProduct product);

    SignedLicense SignAndCreate();
}