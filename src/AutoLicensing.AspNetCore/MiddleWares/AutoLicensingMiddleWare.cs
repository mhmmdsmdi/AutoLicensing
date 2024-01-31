using System.Net;
using AutoLicensing.AspNetCore.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace AutoLicensing.AspNetCore.MiddleWares;

public class AutoLicensingMiddleWare
{
    private readonly RequestDelegate _next;

    public AutoLicensingMiddleWare(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, ILicenseProvider licenseProvider)
    {
        var response = context.Response;
        var originBody = response.Body;
        using var newBody = new MemoryStream();
        response.Body = newBody;

        await _next(context);

        await _next.Invoke(context);

        var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
        var attribute = endpoint?.Metadata.GetMetadata<HasFeatureAttribute>();
        if (attribute != null)
        {
            if (!licenseProvider.IsFeatureEnabled(attribute.FeatureName))
            {
                var stream = response.Body;
                response.StatusCode = (int)HttpStatusCode.NotFound;
                using var reader = new StreamReader(stream, leaveOpen: true);
                var originalResponse = await reader.ReadToEndAsync();
                var modifiedResponse = "Not found";

                stream.SetLength(0);
                await using var writer = new StreamWriter(stream, leaveOpen: true);
                await writer.WriteAsync(modifiedResponse);
                await writer.FlushAsync();
                response.ContentLength = stream.Length;
            }
        }

        newBody.Seek(0, SeekOrigin.Begin);
        await newBody.CopyToAsync(originBody);
        response.Body = originBody;
    }
}