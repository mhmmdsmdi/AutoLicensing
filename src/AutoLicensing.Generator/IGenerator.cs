using AutoLicensing.Models;

namespace AutoLicensing.Generator;

public interface IGenerator
{
    SignedLicense SignAndCreate();
}