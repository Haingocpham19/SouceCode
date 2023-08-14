using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.Driver.Implement
{
    public abstract class AuthorizeClient
    {
        public abstract Task<string> GetAuthorizeToken();
    }
}
