using AutoLicensing.Exceptions;
using AutoLicensing.Signer;
using AutoLicensing.Verifier;

namespace AutoLicensing.Extensions;

public static class RsaExtensions
{
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
            throw new AutoLicensingException(exception.Message);
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
            throw new AutoLicensingException(exception.Message);
        }
    }
}