using System.Threading.Tasks;
using iChiba.IS4.Api.Driver;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace iChiba.Portal.PrivateApi.Driver
{
    public class AuthorizeClientImplement : IAuthorizeClient, Ichiba.Partner.Api.Driver.IAuthorizeClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizeClientImplement(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetAuthorizeToken()
        {
            var isAuthenticated = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
            string authorizationToken = null;

            if (isAuthenticated)
            {
                authorizationToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            }

            return authorizationToken;
        }
    }
}
