using FluentLicensing.Builder;
using FluentLicensing.Exceptions;
using FluentLicensing.Signer;
using FluentLicensing.Verifier;

namespace FluentLicensing.Extensions;

public static class RsaExtensions
{
    public static IGeneratorLicense WithRsaPrivateKey(this IGeneratorSigner generator, byte[] csbBlobKey)
    {
        try
        {
            var rsaSigner = new RsaSigner(csbBlobKey);
            generator.WithSigner(rsaSigner);

            return generator as IGeneratorLicense;
        }
        catch (Exception exception)
        {
            throw new FluentLicensingException(exception.Message);
        }
    }

    public static IGeneratorLicense WithRsaPrivateKey(this IGeneratorSigner generator, string base64EncodedCsbBlobKey)
    {
        try
        {
            return generator.WithRsaPrivateKey(Convert.FromBase64String(base64EncodedCsbBlobKey));
        }
        catch (Exception exception)
        {
            throw new FluentLicensingException(exception.Message);
        }
    }

    public static IGeneratorLicense WithRsaPublicKey(this IGeneratorSigner generator, byte[] csbBlobKey)
    {
        try
        {
            var rsaSigner = new RsaSigner(csbBlobKey);
            generator.WithSigner(rsaSigner);

            return generator as IGeneratorLicense;
        }
        catch (Exception exception)
        {
            throw new FluentLicensingException(exception.Message);
        }
    }

    public static IGeneratorLicense WithRsaPublicKey(this IGeneratorSigner generator, string base64EncodedCsbBlobKey)
    {
        try
        {
            return generator.WithRsaPublicKey(Convert.FromBase64String(base64EncodedCsbBlobKey));
        }
        catch (Exception exception)
        {
            throw new FluentLicensingException(exception.Message);
        }
    }

    public static IVerifierBuilder WithRsaPublicKey(this IVerifierSignerBuilder builder, byte[] csbBlobKey)
    {
        try
        {
            var rsaSigner = new RsaSigner(csbBlobKey);
            builder.WithSigner(rsaSigner);

            return builder as IVerifierBuilder;
        }
        catch (Exception exception)
        {
            throw new FluentLicensingException(exception.Message);
        }
    }

    public static IVerifierBuilder WithRsaPublicKey(this IVerifierSignerBuilder builder, string base64EncodedCsbBlobKey)
    {
        try
        {
            return builder.WithRsaPublicKey(Convert.FromBase64String(base64EncodedCsbBlobKey));
        }
        catch (Exception exception)
        {
            throw new FluentLicensingException(exception.Message);
        }
    }
}