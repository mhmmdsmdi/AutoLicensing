namespace FluentLicensing.Models;

public static class LicenseAttributeExtensions
{
    public static int AsInteger(this LicenseAttribute attribute)
        => Convert.ToInt32(attribute.Value);

    public static string AsString(this LicenseAttribute attribute)
        => attribute.Value;

    public static decimal AsDecimal(this LicenseAttribute attribute)
        => Convert.ToDecimal(attribute.Value);
}