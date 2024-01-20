namespace FluentLicensing;

public class ProtectorService
{
    public Key PublicKey { get; set; }

    public Key PrivateKey { get; set; }
}

public class LicenseManager
{
    private readonly Key _publicKey;
    private Dictionary<string, bool> _features;
    private Dictionary<string, bool> _modules;
    private Dictionary<string, string> _attributes;
    private bool _isLicenseValid;

    public string LicenseKey { get; set; }

    public DateOnly ExpiredDate { get; private set; }

    public LicenseManager(Key publicKey, string licenseKey)
    {
        _publicKey = publicKey;
        LicenseKey = licenseKey;
    }

    public bool IsLicenseValid
    {
        get => _isLicenseValid;
        set => _isLicenseValid = value;
    }

    public string GetAttribute(string attributeKey)
        => _attributes.TryGetValue(attributeKey, out var value) ? value : null;

    public bool IsFeatureActive(string feature)
        => _features.TryGetValue(feature, out var value) && value;

    public bool IsModuleEnable(string moduleName)
        => _modules.TryGetValue(moduleName, out var value) && value;
}