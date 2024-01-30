using AutoLicensing.Exceptions;
using AutoLicensing.Signer;

namespace AutoLicensing.Generator.Generator;

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
            throw new AutoLicensingException(exception.Message);
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
            throw new AutoLicensingException(exception.Message);
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
            throw new AutoLicensingException(exception.Message);
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
            throw new AutoLicensingException(exception.Message);
        }
    }
}