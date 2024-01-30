using AutoLicensing.Builder;
using AutoLicensing.Verifier;

namespace AutoLicensing;

public static class License
{
    public static IGeneratorSigner Generator => new LicenseGenerator();
    public static IVerifierSignerBuilder Verifier => new LicenseVerifierBuilder();
}