using AutoLicensing.Models;

namespace AutoLicensing.Builder;

public interface IGenerator
{
    SignedLicense SignAndCreate();
}