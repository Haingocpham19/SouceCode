using iChiba.Portal.ExtensionApi.AppModel.Response;
using System.Threading.Tasks;

namespace iChiba.Portal.ExtensionApi.AppService.Interface
{
    public interface IExchangeratesService
    {
        public Task<ExchangratesResponsse> GetAllExchangrates();

    }
}
