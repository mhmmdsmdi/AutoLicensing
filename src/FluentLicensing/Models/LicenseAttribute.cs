using System.Globalization;

namespace FluentLicensing.Models;

public class LicenseAttribute
{
    public LicenseAttribute()
    {
    }

    public LicenseAttribute(string key, string value)
    {
        Key = key;
        Value = value;
    }

    public LicenseAttribute(string key, int value)
    {
        Key = key;
        Value = value.ToString();
    }

    public LicenseAttribute(string key, decimal value)
    {
        Key = key;
        Value = value.ToString(CultureInfo.InvariantCulture);
    }

    public string Key { get; set; }

    public string Value { get; set; }
}