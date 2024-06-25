using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System.Configuration;
using System.Text;

[assembly: OwinStartup(typeof(JWTtoken.Startup))]

namespace JWTtoken
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var issuer = ConfigurationManager.AppSettings["issuer"];
            var audience = ConfigurationManager.AppSettings["audience"];
            var secret = ConfigurationManager.AppSettings["secret"]; // Base64-encoded secret key

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = signingKey,
                ValidateLifetime = true // Optionally validate other parameters like expiry
            };

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                TokenValidationParameters = tokenValidationParameters,
                Provider = new CustomJwtBearerAuthenticationProvider("token")
            });
        }
    }
}
