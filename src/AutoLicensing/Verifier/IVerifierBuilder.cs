using AutoLicensing.Models;

namespace AutoLicensing.Verifier;

public interface IVerifierBuilder
{
    SignedLicense LoadAndVerify(string content);
}