using AutoLicensing.Models;

namespace AutoLicensing.Generator.Generator;

public interface IGeneratorLicense
{
    IGenerator WithLicense(Models.License license);
}