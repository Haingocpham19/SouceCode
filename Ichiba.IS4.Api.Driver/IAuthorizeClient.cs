using System.Threading.Tasks;

namespace iChiba.IS4.Api.Driver
{
    public interface IAuthorizeClient
    {
        Task<string> GetAuthorizeToken();
    }
}