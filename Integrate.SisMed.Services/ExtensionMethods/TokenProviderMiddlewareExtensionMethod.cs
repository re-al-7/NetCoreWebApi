using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integrate.SisMed.Services.CustomTokenProvider;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace Integrate.SisMed.Services.ExtensionMethods
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
