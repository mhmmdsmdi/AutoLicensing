using AutoLicensing.Signer;

namespace AutoLicensing.Verifier;

public interface IVerifierSignerBuilder
{
    IVerifierBuilder WithSigner(ISigner signer);
}