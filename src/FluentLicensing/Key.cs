using System.Text;

namespace FluentLicensing;

public class Key(string key)
{
    public string ToBase64()
    {
        var textBytes = Encoding.UTF8.GetBytes(key);
        var base64String = Convert.ToBase64String(textBytes, Base64FormattingOptions.InsertLineBreaks);
        return base64String;
    }

    public static Key FromBase64(string base64String)
    {
        var base64EncodedBytes = Convert.FromBase64String(base64String);
        var key = Encoding.UTF8.GetString(base64EncodedBytes);
        return new Key(key);
    }
}