using System.Linq;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

public class CustomJwtBearerAuthenticationProvider : OAuthBearerAuthenticationProvider
{
    private readonly string _tokenHeaderKey;

    public CustomJwtBearerAuthenticationProvider(string tokenHeaderKey)
    {
        _tokenHeaderKey = tokenHeaderKey;
    }

    public override Task RequestToken(OAuthRequestTokenContext context)
    {
        var token = context.OwinContext.Request.Headers.Get(_tokenHeaderKey);

        if (!string.IsNullOrEmpty(token))
        {
            context.Token = token;
        }

        return Task.FromResult<object>(null);
    }
}
