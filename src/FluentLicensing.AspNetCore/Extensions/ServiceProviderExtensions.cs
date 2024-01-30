using AutoLicensing.AspNetCore.MiddleWares;
using Microsoft.AspNetCore.Builder;

namespace AutoLicensing.AspNetCore.Extensions;

public static class ServiceProviderExtensions
{
    public static void UseAutoLicensing(this IApplicationBuilder app)
    {
        app.UseMiddleware<AutoLicensingMiddleWare>();
    }
}