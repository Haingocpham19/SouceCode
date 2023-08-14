using System.Threading.Tasks;
using iChiba.Portal.PublicApi.Driver.Implement;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace iChiba.Portal.PublicApi.Driver
{
    public class AuthorizeToken : AuthorizeClient
    {
        private readonly string accessToken;

        public AuthorizeToken(string accessToken)
        {
            this.accessToken = accessToken;
        }

        public override Task<string> GetAuthorizeToken()
        {
            return Task.FromResult(accessToken);
        }
    }
    public class AuthorizeClientImplement : AuthorizeClient
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthorizeClientImplement(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public override async Task<string> GetAuthorizeToken()
        {
            var isAuthenticated = httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
            string authorizationToken = null;

            if (isAuthenticated)
            {
                authorizationToken = await httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            }

            return authorizationToken;
        }
    }
    public class AuthorizeCSPrivateClientImplement : Ichiba.Partner.Api.Driver.IAuthorizeClient, CS.PublicApi.Driver.IAuthorizeClient
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public AuthorizeCSPrivateClientImplement(IHttpContextAccessor httpContextAccessor = null)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetAuthorizeToken()
        {
            var isAuthenticated = httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
            string authorizationToken = null;

            if (isAuthenticated)
            {
                authorizationToken = await httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            }

            return authorizationToken;
        }
    }
}
