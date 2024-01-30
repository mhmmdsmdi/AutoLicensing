using AutoLicensing.Verifier;

namespace AutoLicensing;

public static class Licenser
{
    public static IVerifierSignerBuilder Verifier => new LicenseVerifierBuilder();
}