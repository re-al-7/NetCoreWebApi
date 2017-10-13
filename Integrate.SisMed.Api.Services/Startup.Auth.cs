using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Integrate.SisMed.Api.BusinessObjects;
using Integrate.SisMed.Api.Services.CustomTokenProvider;
using Integrate.SisMed.Api.Services.Dal.Modelo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Integrate.SisMed.Api.Services
{
    public partial class Startup
    {
        private readonly SymmetricSecurityKey _signingKey;

        private readonly TokenValidationParameters _tokenValidationParameters;

        private readonly TokenProviderOptions _tokenProviderOptions;

        private void ConfigureAuth(IServiceCollection services)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options => { options.TokenValidationParameters = _tokenValidationParameters; })
                .AddCookie(options =>
                {
                    options.Cookie.Name = Configuration.GetSection("TokenAuthentication:CookieName").Value;
                    options.TicketDataFormat = new CustomJwtDataFormat(
                        SecurityAlgorithms.HmacSha256,
                        _tokenValidationParameters);
                });
        }

        private Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            //Obtenemos el Usuario
            var rn = new RnSegUsuarios();
            var obj = rn.ObtenerObjeto(EntSegUsuarios.Fields.loginsus, "'" + username + "'");

            if (obj == null)
                return Task.FromResult<ClaimsIdentity>(null);


            if (CUtilsApi.generarMD5(password).ToUpper() == obj.passsus.ToUpper())
            {
                return Task.FromResult(new ClaimsIdentity(new GenericIdentity(username, "Token"), new Claim[] { }));
            }
            // Don't do this in production, obviously!
            //if (username == "TEST" && password == "TEST123")
            //{
            //    return Task.FromResult(new ClaimsIdentity(new GenericIdentity(username, "Token"), new Claim[] { }));
            //}

            // Credentials are invalid, or account doesn't exist
            return Task.FromResult<ClaimsIdentity>(null);
        }
    }
}
