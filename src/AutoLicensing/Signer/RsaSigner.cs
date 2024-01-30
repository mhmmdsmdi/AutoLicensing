using System.Security.Cryptography;
using System.Text;
using AutoLicensing.Extensions;
using AutoLicensing.Models;
using Newtonsoft.Json;

namespace AutoLicensing.Signer;

public class RsaSigner() : ISigner
{
    private readonly RSACryptoServiceProvider _cryptoServiceProvider = new();
    private readonly HashAlgorithm _hashAlgorithm = SHA512.Create();

    public RsaSigner(string base64EncodedCsbBlobKey)
        : this(Convert.FromBase64String(base64EncodedCsbBlobKey))
    { }

    public RsaSigner(byte[] csbBlobKey)
        : this()
    {
        _cryptoServiceProvider.ImportCspBlob(csbBlobKey);
    }

    public bool Verify(SignedLicense signedLicense)
    {
        var signature = signedLicense.Signature;

        var bytesContent = Encoding.UTF8.GetBytes(signedLicense.LicenseKey);
        var bytesSignature = Convert.FromBase64String(signature);

        bytesSignature = bytesSignature.UnConfuse();
        return _cryptoServiceProvider.VerifyData(bytesContent, _hashAlgorithm, bytesSignature);
    }

    public void Sign(SignedLicense signedLicense)
    {
        var bytes = Encoding.UTF8.GetBytes(signedLicense.LicenseKey);
        var signature = _cryptoServiceProvider.SignData(bytes, _hashAlgorithm);
        signature = signature.UnConfuse();
        var base64Signing = Convert.ToBase64String(signature);

        signedLicense.Signature = base64Signing;
    }
}