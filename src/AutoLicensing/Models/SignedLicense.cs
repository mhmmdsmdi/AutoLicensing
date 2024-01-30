using System.Text;
using AutoLicensing.Extensions;
using Newtonsoft.Json;

namespace AutoLicensing.Models;

public class SignedLicense
{
    public SignedLicense() { }
    public SignedLicense(License license)
    {
        License = license;
    }

    /// <summary>
    /// Serialized license data
    /// </summary>
    public string LicenseKey { get; set; }

    [JsonIgnore]
    public License License
    {
        get => LicenseKey.FromBase64JsonString<License>();
        set => LicenseKey = value.ToBase64JsonString();
    }

    public string Signature { get; set; } = string.Empty;

    public string Export()
        => Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this)));

    public static SignedLicense Import(string base46)
        => JsonConvert.DeserializeObject<SignedLicense>(Encoding.UTF8.GetString(Convert.FromBase64String(base46)));
}