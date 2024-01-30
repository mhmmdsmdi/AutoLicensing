using AutoLicensing.Exceptions;
using AutoLicensing.Signer;

namespace AutoLicensing.Generator.Extension;

public static class RsaExtensions
{
    public static ILicenseFactory WithRsaPrivateKey(this ILicenseFactory generator, byte[] csbBlobKey)
    {
        try
        {
            var rsaSigner = new RsaSigner(csbBlobKey);
            generator.WithSigner(rsaSigner);

            return generator;
        }
        catch (Exception exception)
        {
            throw new AutoLicensingException(exception.Message);
        }
    }

    public static ILicenseFactory WithRsaPrivateKey(this ILicenseFactory generator, string base64EncodedCsbBlobKey)
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

    public static ILicenseFactory WithRsaPublicKey(this ILicenseFactory generator, byte[] csbBlobKey)
    {
        try
        {
            var rsaSigner = new RsaSigner(csbBlobKey);
            generator.WithSigner(rsaSigner);

            return generator;
        }
        catch (Exception exception)
        {
            throw new AutoLicensingException(exception.Message);
        }
    }

    public static ILicenseFactory WithRsaPublicKey(this ILicenseFactory generator, string base64EncodedCsbBlobKey)
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