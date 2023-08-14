using System.Threading.Tasks;

namespace iChiba.Portal.CS.PublicApi.Driver
{
    public interface IAuthorizeClient
    {
        Task<string> GetAuthorizeToken();
    }
}
