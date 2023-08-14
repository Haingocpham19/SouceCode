using System.Threading.Tasks;
using iChiba.IS4.Api.Driver;

namespace iChiba.Portal.PrivateApi.Driver
{
    public class CsPrivateAuthorizeClientImplement : IAuthorizeClient
    {
        public Task<string> GetAuthorizeToken()
        {
            return Task.FromResult(string.Empty);
        }
    }
}
