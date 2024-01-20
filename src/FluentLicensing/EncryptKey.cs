using System.Text;

namespace FluentLicensing;

/// <summary>
/// Public/Private encryption key
/// </summary>
/// <param name="key">RSA xml key</param>
public class EncryptKey(string key, int size)
{
    /// <summary>
    /// RSA Crypto XML Key
    /// </summary>
    public string Key { get; } = key;

    public int Size { get; } = size;

    /// <summary>
    /// Encode key to base64
    /// </summary>
    /// <returns></returns>
    public string ToBase64()
    {
        var textBytes = Encoding.UTF8.GetBytes(Key);
        var base64String = Convert.ToBase64String(textBytes, Base64FormattingOptions.InsertLineBreaks);
        return base64String;
    }

    /// <summary>
    /// Decode the key from base64
    /// </summary>
    /// <param name="base64String"></param>
    /// <returns></returns>
    public static EncryptKey FromBase64(string base64String, int size)
    {
        var base64EncodedBytes = Convert.FromBase64String(base64String);
        var key = Encoding.UTF8.GetString(base64EncodedBytes);
        return new EncryptKey(key, size);
    }

    /// <summary>
    /// To base64
    /// </summary>
    /// <returns></returns>
    public override string ToString()
        => ToBase64();
}