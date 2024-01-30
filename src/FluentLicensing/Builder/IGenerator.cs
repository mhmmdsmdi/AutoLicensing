using FluentLicensing.Models;

namespace FluentLicensing.Builder;

public interface IGenerator
{
    SignedLicense SignAndCreate();
}