using AutoLicensing.Exceptions;

namespace AutoLicensing.Models;

public class License
{
    public string LicenseName { get; set; } = string.Empty;

    public string CustomerName { get; set; } = string.Empty;

    public List<LicenseProduct> Products { get; set; } = new();
}

public static class LicenseExtensions
{
    public static LicenseProduct? GetProduct(this License license, string productName)
    {
        return license.Products
            .FirstOrDefault(x => x.Name == productName);
    }
}