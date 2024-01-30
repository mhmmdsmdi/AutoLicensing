using AutoLicensing.Models;
using AutoLicensing.Signer;

namespace AutoLicensing.Generator.Generator;

public class LicenseGenerator : IGenerator, IGeneratorLicense, IGeneratorSigner
{
    public static IGeneratorSigner Generator => new LicenseGenerator();

    private License _license = new();

    private ISigner _signer;

    public IGeneratorLicense WithSigner(ISigner signer)
    {
        _signer = signer;
        return this;
    }

    public IGenerator WithLicense(License license)
    {
        _license = license;
        return this;
    }

    public SignedLicense SignAndCreate()
    {
        var signedLicense = new SignedLicense(_license);

        _signer.Sign(signedLicense);

        return signedLicense;
    }
}