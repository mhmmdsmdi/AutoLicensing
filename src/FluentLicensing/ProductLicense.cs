namespace FluentLicensing;

public class ProductLicense
{
    public Dictionary<string, bool> Features { get; set; }

    public Dictionary<string, string> Attributes { get; set; }

    public DateTime Expiry { get; set; }
}