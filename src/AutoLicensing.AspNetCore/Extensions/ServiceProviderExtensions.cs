using AutoLicensing.AspNetCore.Filters;
using AutoLicensing.AspNetCore.Middlewares;
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
        app.UseMiddleware<AutoLicensingMiddleware>();
    }

    /// <summary>
    /// Registers license-feature gating ([HasFeature]) as an MVC authorization filter
    /// instead of middleware. Runs only after the endpoint/action is resolved, so it
    /// never needs to buffer the response body — safe for streaming/SSE endpoints
    /// regardless of where it's called relative to UseRouting in Program.cs.
    /// </summary>
    public static IMvcBuilder AddLicenseFeatureGating(this IMvcBuilder builder)
    {
        builder.AddMvcOptions(options => { options.Filters.Add<LicenseFeatureAuthorizationFilter>(); });

        return builder;
    }
}