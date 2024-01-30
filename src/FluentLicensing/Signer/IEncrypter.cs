using AutoLicensing.Models;

namespace AutoLicensing.Signer;

public interface ISigner
{
    bool Verify(SignedLicense signedLicense);

    void Sign(SignedLicense signedLicense);
}