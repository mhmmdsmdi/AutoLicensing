using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace FluentLicensing.Generator;

public class LicenseGenerator
{
    private readonly RSACryptoServiceProvider _rsaCryptoServiceProvider;

    public EncryptKey PrivateKey { get; }
    public EncryptKey PublicKey { get; }

    public LicenseGenerator(int sizeOfTheKey = 2048)
    {
        _rsaCryptoServiceProvider = new RSACryptoServiceProvider(sizeOfTheKey);

        PrivateKey = new EncryptKey(_rsaCryptoServiceProvider.ToXmlString(true), sizeOfTheKey);
        PublicKey = new EncryptKey(_rsaCryptoServiceProvider.ToXmlString(false), sizeOfTheKey);
    }

    public LicenseGenerator(EncryptKey privateKey)
    {
        PrivateKey = privateKey;

        _rsaCryptoServiceProvider = new RSACryptoServiceProvider(privateKey.Size);
        _rsaCryptoServiceProvider.FromXmlString(PrivateKey.Key);
    }

    public License Generate(LicenseData licenseData)
    {
        var json = JsonConvert.SerializeObject(licenseData);
        var bytes = Encoding.UTF8.GetBytes(json);
        var encryptedByteArray = _rsaCryptoServiceProvider.Encrypt(bytes, false).ToArray();

        return new License(encryptedByteArray);
    }
}