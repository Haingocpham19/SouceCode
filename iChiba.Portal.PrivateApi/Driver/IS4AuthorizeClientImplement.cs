using System.Threading.Tasks;
using iChiba.IS4.Api.Driver;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace iChiba.Portal.PrivateApi.Driver
{
    public class Is4AuthorizeClientImplement : IAuthorizeClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Is4AuthorizeClientImplement(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
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
