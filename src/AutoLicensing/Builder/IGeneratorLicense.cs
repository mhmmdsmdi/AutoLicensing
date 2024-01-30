using AutoLicensing.Models;

namespace AutoLicensing.Builder;

public interface IGeneratorLicense
{
    IGenerator WithLicense(SignedLicense license);
}