using iChiba.Portal.PrivateApi.AppModel.Responses;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.AppService.Interface
{
    public interface IServiceChargeAppService
    {
        Task<ServiceChargeListResponse> GetAll();
    }
}
