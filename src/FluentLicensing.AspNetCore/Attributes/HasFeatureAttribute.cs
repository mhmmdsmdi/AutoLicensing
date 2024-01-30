namespace AutoLicensing.AspNetCore.Attributes;

public class HasFeatureAttribute(string featureName) : Attribute
{
    public string FeatureName { get; } = featureName;
}