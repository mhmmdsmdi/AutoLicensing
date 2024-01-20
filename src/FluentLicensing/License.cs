namespace FluentLicensing;

public class License(string key)
{
    /// <summary>
    /// Base64 license key
    /// </summary>
    public string Key { get; } = key;

    public License(byte[] bytes) : this(Convert.ToBase64String(bytes))
    {
    }

    /// <summary>
    /// From base64 to bytes
    /// </summary>
    /// <returns></returns>
    public byte[] ToBytes()
        => Convert.FromBase64String(Key);
}