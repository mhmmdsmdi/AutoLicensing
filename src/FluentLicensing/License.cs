using FluentLicensing.Builder;
using FluentLicensing.Verifier;

namespace FluentLicensing;

public static class License
{
    public static IGeneratorSigner Generator => new LicenseGenerator();
    public static IVerifierSignerBuilder Verifier => new LicenseVerifierBuilder();
}