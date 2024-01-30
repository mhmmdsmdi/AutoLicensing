using AutoLicensing.Signer;

namespace AutoLicensing.Generator;

public interface IGeneratorSigner
{
    IGeneratorLicense WithSigner(ISigner signer);
}