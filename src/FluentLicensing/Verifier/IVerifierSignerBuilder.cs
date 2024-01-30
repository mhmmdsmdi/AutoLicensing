using FluentLicensing.Signer;

namespace FluentLicensing.Verifier;

public interface IVerifierSignerBuilder
{
    IVerifierBuilder WithSigner(ISigner signer);
}