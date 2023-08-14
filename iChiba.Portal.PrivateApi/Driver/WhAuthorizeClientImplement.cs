using iChiba.IS4.Api.Driver;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.Driver
{
    public class WhAuthorizeClientImplement : IAuthorizeClient
    {
        public WhAuthorizeClientImplement()
        {
        }

        public Task<string> GetAuthorizeToken()
        {
            return Task.FromResult(string.Empty);
        }
    }
}
