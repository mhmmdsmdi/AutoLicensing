using AutoLicensing.Signer;

namespace AutoLicensing.Generator.Generator;

public interface IGeneratorSigner
{
    IGeneratorLicense WithSigner(ISigner signer);
}