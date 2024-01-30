using FluentLicensing.Models;

namespace FluentLicensing.Builder;

public interface IGeneratorLicense
{
    IGenerator WithLicense(SignedLicense license);
}