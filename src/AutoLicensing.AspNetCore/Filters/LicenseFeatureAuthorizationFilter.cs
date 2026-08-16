using System.Net;
using System.Reflection;
using AutoLicensing.AspNetCore.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AutoLicensing.AspNetCore.Filters;

public class LicenseFeatureAuthorizationFilter(ILicenseProvider licenseProvider) : IAsyncAuthorizationFilter
{
    public Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
        var attribute = descriptor?.MethodInfo.GetCustomAttribute<HasFeatureAttribute>()
                        ?? descriptor?.ControllerTypeInfo.GetCustomAttribute<HasFeatureAttribute>();

        if (attribute != null && !licenseProvider.IsFeatureEnabled(attribute.FeatureName))
        {
            context.Result = new NotFoundObjectResult("Not found")
            {
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }

        return Task.CompletedTask;
    }
}