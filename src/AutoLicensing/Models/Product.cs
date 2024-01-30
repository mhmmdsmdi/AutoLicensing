namespace AutoLicensing.Models;

public class Product
{
    public string Name { get; set; }

    public Dictionary<string, bool> Features { get; set; }

    public List<LicenseAttribute> Attributes { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime ExpiryDate { get; set; }
}