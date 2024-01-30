using AutoLicensing.Exceptions;
using AutoLicensing.Models;
using AutoLicensing.Signer;

namespace AutoLicensing.Verifier;

internal class LicenseVerifierBuilder : IVerifierBuilder, IVerifierSignerBuilder
{
    private ISigner _signer;

    public IVerifierBuilder WithSigner(ISigner signer)
    {
        _signer = signer;
        return this;
    }

    public SignedLicense LoadAndVerify(string content)
    {
        var signedLicense = SignedLicense.Import(content);
        if (!_signer.Verify(signedLicense))
            throw new AutoLicensingException("License is not Valid");

        return signedLicense;
    }
}