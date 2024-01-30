﻿using FluentLicensing.Models;
using FluentLicensing.Signer;

namespace FluentLicensing.Verifier;

internal class LicenseVerifierBuilder : IVerifierBuilder, IVerifierSignerBuilder
{
    private ISigner _signer;

    public IVerifierBuilder WithSigner(ISigner signer)
    {
        _signer = signer;
        return this;
    }

    public SignedLicense LoadAndVerify(string content)
    {
        var signedLicense = SignedLicense.Import(content);
        if (_signer.Verify(signedLicense))
            Console.WriteLine("OKKKKKKKKKKKKKKKKKKKKKKKKKK");
        else
            Console.WriteLine("NOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");

        return signedLicense;
    }
}