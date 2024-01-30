using AutoLicensing.Models;

namespace AutoLicensing.Generator;

public interface IGeneratorLicense
{
    IGenerator WithLicense(SignedLicense license);
}