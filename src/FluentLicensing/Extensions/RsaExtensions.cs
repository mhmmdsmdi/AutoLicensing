using FluentLicensing.Builder;
using FluentLicensing.Signer;
using FluentLicensing.Verifier;

namespace FluentLicensing.Extensions;

public static class RsaExtensions
{
    public static IGeneratorLicense WithRsaPrivateKey(this IGeneratorSigner generator, byte[] csbBlobKey)
    {
        var rsaSigner = new RsaSigner(csbBlobKey);
        generator.WithSigner(rsaSigner);

        return generator as IGeneratorLicense;
    }

    public static IGeneratorLicense WithRsaPrivateKey(this IGeneratorSigner generator, string base64EncodedCsbBlobKey)
        => generator.WithRsaPrivateKey(Convert.FromBase64String(base64EncodedCsbBlobKey));

    public static IGeneratorLicense WithRsaPublicKey(this IGeneratorSigner generator, byte[] csbBlobKey)
    {
        var rsaSigner = new RsaSigner(csbBlobKey);
        generator.WithSigner(rsaSigner);

        return generator as IGeneratorLicense;
    }

    public static IGeneratorLicense WithRsaPublicKey(this IGeneratorSigner generator, string base64EncodedCsbBlobKey)
        => generator.WithRsaPublicKey(Convert.FromBase64String(base64EncodedCsbBlobKey));

    /// <summary>
    /// //////////////////////////////
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="csbBlobKey"></param>
    /// <returns></returns>
    public static IVerifierBuilder WithRsaPublicKey(this IVerifierSignerBuilder builder, byte[] csbBlobKey)
    {
        var rsaSigner = new RsaSigner(csbBlobKey);
        builder.WithSigner(rsaSigner);

        return builder as IVerifierBuilder;
    }

    public static IVerifierBuilder WithRsaPublicKey(this IVerifierSignerBuilder builder, string base64EncodedCsbBlobKey)
        => builder.WithRsaPublicKey(Convert.FromBase64String(base64EncodedCsbBlobKey));
}