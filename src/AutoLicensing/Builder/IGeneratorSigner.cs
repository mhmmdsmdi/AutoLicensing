using AutoLicensing.Signer;

namespace AutoLicensing.Builder;

public interface IGeneratorSigner
{
    IGeneratorLicense WithSigner(ISigner signer);
}