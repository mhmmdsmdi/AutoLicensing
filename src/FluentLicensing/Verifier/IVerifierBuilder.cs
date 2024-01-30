using FluentLicensing.Models;

namespace FluentLicensing.Verifier;

public interface IVerifierBuilder
{
    SignedLicense LoadAndVerify(string content);
}