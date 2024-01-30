using AutoLicensing.Models;
using AutoLicensing.Signer;

namespace AutoLicensing.Builder;

internal class LicenseGenerator : IGenerator, IGeneratorLicense, IGeneratorSigner
{
    private SignedLicense _signedLicense = new();

    private ISigner _signer;

    public IGeneratorLicense WithSigner(ISigner signer)
    {
        _signer = signer;
        return this;
    }

    public IGenerator WithLicense(SignedLicense license)
    {
        _signedLicense = license;
        return this;
    }

    public SignedLicense SignAndCreate()
    {
        _signer.Sign(_signedLicense);
        return _signedLicense;
    }
}