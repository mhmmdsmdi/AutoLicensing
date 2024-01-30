using AutoLicensing.Verifier;

namespace AutoLicensing;

public static class License
{
    public static IVerifierSignerBuilder Verifier => new LicenseVerifierBuilder();
}