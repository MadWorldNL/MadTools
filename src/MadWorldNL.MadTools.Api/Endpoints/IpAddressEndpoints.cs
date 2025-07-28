using MadWorldNL.MadTools.Api.Domains.IpAddress;

namespace MadWorldNL.MadTools.Api.Endpoints;

internal static class IpAddressEndpoints
{
    internal static void AddIpAddressEndpoints(this WebApplication app)
    {
        app.MapGet("/IpAddress/WhatIsMyIp", (HttpContext context) =>
        {
            // Try to get the IP from the X-Forwarded-For header
            var ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();

            // If not available, fall back to RemoteIpAddress
            if (string.IsNullOrEmpty(ip))
            {
                ip = context.Connection.RemoteIpAddress?.ToString();
            }

            return new GetWhatIsMyIpResponse()
            {
                IpAddress = ip ?? string.Empty
            };
        });
    }
}