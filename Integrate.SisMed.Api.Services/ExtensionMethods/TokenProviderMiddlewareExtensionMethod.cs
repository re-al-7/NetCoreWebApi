using Integrate.SisMed.Api.Services.CustomTokenProvider;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace Integrate.SisMed.Api.Services.ExtensionMethods
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenProvider(
            this IApplicationBuilder builder, TokenProviderOptions parameters)
        {
            return builder.UseMiddleware<TokenProviderMiddleware>(Options.Create(parameters));
        }
    }
}
