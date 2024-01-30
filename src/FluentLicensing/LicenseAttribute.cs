namespace FluentLicensing;

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
        Value = value.ToString();
    }

    public string Key { get; set; }

    public string Value { get; set; }

    public int GetInt()
        => Convert.ToInt32(Value);

    public string GetString()
        => Value;

    public decimal GetDecimal()
        => Convert.ToDecimal(Value);
}