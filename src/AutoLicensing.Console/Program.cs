using AutoLicensing;
using AutoLicensing.Extensions;
using AutoLicensing.Generator;
using AutoLicensing.Generator.Extension;
using AutoLicensing.Models;

void Validate()
{
    var publicKey =
        "BwIAAACkAABSU0EyAAQAAAEAAQCttrhKM7LOXAO47ittU8lR2i5uWch2+xxOlWS++6wDFclMH2unsocj/c1b7CqCQ75ErjsOprtuYecdialyRM01KcU/p2A/Mja9kax/++ohUAZ/r3uankodR7+cjeqxalbbrOq/OfRf+feIMU/fyj/naUJEsJJotXe+1nRqoP/S9E8AyRGI3Hg7+ARuxEN1m0PcoOb/P4XJtkfLk/Xq9buDImtQwI68vdvfA77y+IOujL18hDH1rUzmU4kjpN6rlvxDvi1psjv7ScqqK2AJgIUM7sm6gxVEJof4c0ssnCVCeoOaq0QBnJfuL2pu/M/foTQC/J1ytHXTlElCEWBZeyH4x2jGRpHh4TISXG7RNE3HgNiBuopwx+RuDuDM007aiQqorF97dJHQgp6Gitu/ZeDx2385PFN9TpKcwphJhwaT0KWlg9yDiby+UZmvEY2knQJrbcHsko0Z6oAYqQ++f9V8cHwtcuCQj99+AZWIG7nOFKBzM4O7o2uzoHaXey8uGMwJdDwFh1UtZvvM0j754KE1Hf49dNNwItzosVtQyJE+Zc3tu5WRRi9jeslKQEWFvGyPni7MeWlGXRqZgMOgCdDxxT/u5ELmw+RrnloAepw4kqgONqFt+uH7NZGgQkoO5M70Pbl05b7/XYVIGYVU7yrM515NwOJySE1jJtsZU5VLE+EHLUsO9bZrKEJq/T/8kj92qPNCv8ITL23B2ifQfQnRv2JALb7lvcBFGtkEH5B1hFYIPPxE+9Fnzb6k0B+xS0E=";
    var license = "eyJMaWNlbnNlS2V5IjoiZXlKTWFXTmxibk5sVG1GdFpTSTZJaUlzSWtOMWMzUnZiV1Z5VG1GdFpTSTZJa2hwYVdscElpd2lVSEp2WkhWamRITWlPbHQ3SWs1aGJXVWlPbTUxYkd3c0lrWmxZWFIxY21WeklqcDdJa1psWVhSMWNtVXhJanAwY25WbExDSkdaV0YwZFhKbE1pSTZkSEoxWlN3aVJtVmhkSFZ5WlRNaU9tWmhiSE5sZlN3aVFYUjBjbWxpZFhSbGN5STZXM3NpUzJWNUlqb2lTVzV6WlhKMElFeHBiV2wwWVhScGIyNGlMQ0pXWVd4MVpTSTZJakV3TURBaWZTeDdJa3RsZVNJNklsVnpaWElnVEdsdGFYUmhkR2x2YmlJc0lsWmhiSFZsSWpvaU1pSjlYU3dpU1hOemRXVkVZWFJsSWpvaU1EQXdNUzB3TVMwd01WUXdNRG93TURvd01DSXNJa1Y0Y0dseWVVUmhkR1VpT2lJeU1ESTBMVEEzTFRJNVZEQXhPakl3T2pFeExqVTJPVEEyT0RZck1ETTZNekFpZlN4N0lrNWhiV1VpT201MWJHd3NJa1psWVhSMWNtVnpJanA3SWtabFlYUjFjbVUwSWpwMGNuVmxMQ0pHWldGMGRYSmxOU0k2ZEhKMVpTd2lSbVZoZEhWeVpUWWlPbVpoYkhObGZTd2lRWFIwY21saWRYUmxjeUk2VzNzaVMyVjVJam9pU1c1elpYSjBJRXhwYldsMFlYUnBiMjRpTENKV1lXeDFaU0k2SWpFd01EQWlmVjBzSWtsemMzVmxSR0YwWlNJNklqQXdNREV0TURFdE1ERlVNREE2TURBNk1EQWlMQ0pGZUhCcGNubEVZWFJsSWpvaU1qQXlOQzB3T0MweE9GUXdNVG95TURveE1TNDFOekEwTnpZeUt6QXpPak13SW4xZGZRPT0iLCJTaWduYXR1cmUiOiJtZnFEV2tObVJuZkg2Z3Blblp2MjAxdVVmMlRYRVB1NXBHOVdVK05IS2UzRlRtT25pVEhDYW9PdnRhSG10SmFnc0I0YmdwMUcraFRYQmVFVUplUEZhVWlBYXYwenlpY2VGWnNVQm9GbUM5bzdXV1IyWlRRYWt1SGRoT3dZTFo1dUU1Q3F4a3RQS3UySnhIUm9QdFlvd0dWSERZVnBSVUVXRm1EM0pJVEdUaG89In0=";

    var signedLicense = Licenser.Verifier
        .WithRsaPublicKey(publicKey)
        .LoadAndVerify(license);

    var f1 = signedLicense.License
        .GetProduct("Application 3")?
        .IsFeatureEnabled("Feature1");

    var f2 = signedLicense.License
        .GetProduct("Application 1")?
        .IsFeatureEnabled("Feature3");
}

void GenerateLicense()
{
    var key = LicenseKeyGenerator.GenerateRsaKeyPair();

    Console.WriteLine("Private Key :");
    Console.WriteLine(key.PrivateKey);
    Console.WriteLine();

    Console.WriteLine("Public Key :");
    Console.WriteLine(key.PrivateKey);
    Console.WriteLine();

    var signedLicense = new LicenseFactory()
        .WithRsaPrivateKey(key.PrivateKey)
        .WithName("Enterprise License")
        .WithCustomerName("Some Guy")
        .WithProduct(new LicenseProductFactory()
            .WithName("Application 1")
            .WithExpiryDate(DateTime.Now.AddDays(180))
            .WithAttribute("Limitation 1", 100)
            .WithFeature("Feature 1")
            .WithFeature("Feature 2")
            .Create())
        .SignAndCreate();

    Console.WriteLine("License :");
    Console.WriteLine(signedLicense.Export());
}

try
{
    Validate();
    //GenerateLicense();
}
catch (Exception e)
{
    Console.WriteLine(e);
}