using FluentLicensing.Models;

namespace FluentLicensing.Signer;

public interface ISigner
{
    bool Verify(SignedLicense signedLicense);

    void Sign(SignedLicense signedLicense);
}