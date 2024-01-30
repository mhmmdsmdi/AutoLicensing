using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace FluentLicensing;

public class LicenseManager
{
    public License License { get; }

    public LicenseData Data { get; }

    public LicenseManager(EncryptKey publicKey, License license)
    {
        License = license;

        var rsaCryptoServiceProvider = new RSACryptoServiceProvider(publicKey.Size);
        rsaCryptoServiceProvider.FromXmlString(publicKey.Key);

        var dataByte = license.ToBytes();
        var decryptedByte = rsaCryptoServiceProvider.Decrypt(dataByte, false);

        var json = Encoding.UTF8.GetString(decryptedByte);

        Data = JsonConvert.DeserializeObject<LicenseData>(json);
    }
}