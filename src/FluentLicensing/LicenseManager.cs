using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace FluentLicensing;

public class LicenseManager
{
    private readonly RSACryptoServiceProvider _rsaCryptoServiceProvider;

    public License License { get; }

    public LicenseData Data { get; }

    public LicenseManager(EncryptKey publicKey, License license)
    {
        License = license;

        _rsaCryptoServiceProvider = new RSACryptoServiceProvider(publicKey.Size);
        _rsaCryptoServiceProvider.FromXmlString(publicKey.Key);

        var dataByte = license.ToBytes();
        var decryptedByte = _rsaCryptoServiceProvider.Decrypt(dataByte, false);

        var json = Encoding.UTF8.GetString(decryptedByte);

        Data = JsonConvert.DeserializeObject<LicenseData>(json);
    }
}