using System.Security.Cryptography;
using AutoLicensing.Signer;

namespace AutoLicensing;

public static class LicenseKeyGenerator
{
    public static SigningKeyPair GenerateRsaKeyPair()
    {
        var cp = new RSACryptoServiceProvider();
        var privateKey = Convert.ToBase64String(cp.ExportCspBlob(true));
        var publicKey = Convert.ToBase64String(cp.ExportCspBlob(false));

        return new SigningKeyPair(publicKey, privateKey);
    }
}