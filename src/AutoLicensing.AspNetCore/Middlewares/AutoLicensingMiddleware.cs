using System.Net;
using AutoLicensing.AspNetCore.Attributes;
using Microsoft.AspNetCore.Http;

namespace AutoLicensing.AspNetCore.Middlewares;

public class AutoLicensingMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context, ILicenseProvider licenseProvider)
    {
        var response = context.Response;

        // Endpoint already resolved (middleware registered after UseRouting):
        // gate before the endpoint runs so streaming/SSE responses pass through un-buffered.
        var endpoint = context.GetEndpoint();
        if (endpoint != null)
        {
            var attribute = endpoint.Metadata.GetMetadata<HasFeatureAttribute>();
            if (attribute != null && !licenseProvider.IsFeatureEnabled(attribute.FeatureName))
            {
                response.StatusCode = (int)HttpStatusCode.NotFound;
                await response.WriteAsync("Not found");
                return;
            }

            await next(context);
            return;
        }

        // Endpoint not resolved yet (middleware registered before UseRouting):
        // buffer the response so the body can be replaced after the endpoint runs.
        // ponytail: SSE/streaming endpoints stay buffered in this placement — register after UseRouting to stream.
        var originBody = response.Body;
        using var newBody = new MemoryStream();
        response.Body = newBody;

        try
        {
            await next(context);

            endpoint = context.GetEndpoint();
            var attribute = endpoint?.Metadata.GetMetadata<HasFeatureAttribute>();
            if (attribute != null && !licenseProvider.IsFeatureEnabled(attribute.FeatureName))
            {
                response.StatusCode = (int)HttpStatusCode.NotFound;
                newBody.SetLength(0);
                await response.WriteAsync("Not found");
                response.ContentLength = newBody.Length;
            }

            newBody.Seek(0, SeekOrigin.Begin);
            await newBody.CopyToAsync(originBody);
        }
        finally
        {
            response.Body = originBody;
        }
    }
}
