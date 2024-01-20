namespace FluentLicensing;

public class LicenseData(string companyName)
{
    public string CompanyName { get; } = companyName;

    public List<ProductLicense> Products { get; set; }
}