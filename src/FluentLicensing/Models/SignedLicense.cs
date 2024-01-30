using System.Text;
using Newtonsoft.Json;

namespace FluentLicensing.Models;

public class SignedLicense
{
    public string CompanyName { get; set; }

    public List<Product> Products { get; set; }

    public string Signature { get; set; }

    public string Export()
        => Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this)));

    public static SignedLicense Import(string base46)
        => JsonConvert.DeserializeObject<SignedLicense>(Encoding.UTF8.GetString(Convert.FromBase64String(base46)));
}