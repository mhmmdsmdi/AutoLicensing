namespace FluentLicensing;

public class ProductLicense
{
    public Dictionary<string, bool> Features { get; set; }

    public List<LicenseAttribute> Attributes { get; set; }

    public DateTime Expiry { get; set; }
}