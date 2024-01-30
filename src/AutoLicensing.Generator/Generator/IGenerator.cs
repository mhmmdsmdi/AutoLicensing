using AutoLicensing.Models;

namespace AutoLicensing.Generator.Generator;

public interface IGenerator
{
    SignedLicense SignAndCreate();
}