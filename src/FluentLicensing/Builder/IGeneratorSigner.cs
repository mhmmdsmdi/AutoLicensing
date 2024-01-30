using FluentLicensing.Signer;

namespace FluentLicensing.Builder;

public interface IGeneratorSigner
{
    IGeneratorLicense WithSigner(ISigner signer);
}