namespace AutoLicensing.Models;

public class LicenseProduct
{
    public string Name { get; set; }

    public Dictionary<string, bool> Features { get; set; } = new();

    public List<LicenseAttribute> Attributes { get; set; } = new();

    public DateTime IssueDate { get; set; } = DateTime.Now.ToUniversalTime();

    public DateTime ExpiryDate { get; set; } = DateTime.MaxValue.ToUniversalTime();
}