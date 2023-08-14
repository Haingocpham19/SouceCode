using iChiba.IS4.Api.Driver;
using System.Threading.Tasks;

namespace iChiba.Portal.ExtensionApi.Driver
{
    public class AuthorizeClientImplement : IAuthorizeClient, Ichiba.Partner.Api.Driver.IAuthorizeClient
    {
        public AuthorizeClientImplement()
        {
        }

        public Task<string> GetAuthorizeToken()
        {
            return Task.FromResult(string.Empty);
        }
    }
}
