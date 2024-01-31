using AutoLicensing.AspNetCore.MiddleWares;
using AutoLicensing.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AutoLicensing.AspNetCore.Extensions;

public static class ServiceProviderExtensions
{
    public static IServiceCollection AddAutoLicensing(this IServiceCollection services,
        string productName,
        string publicKey,
        string license)
    {
        var signedLicense = Licenser.Verifier
            .WithRsaPublicKey(publicKey)
            .LoadAndVerify(license);

        services.AddSingleton(signedLicense);

        services.AddSingleton<ILicenseProvider>(new LicenseProvider(signedLicense, productName));

        return services;
    }

    public static void UseAutoLicensing(this IApplicationBuilder app)
    {
        app.UseMiddleware<AutoLicensingMiddleWare>();
    }
}