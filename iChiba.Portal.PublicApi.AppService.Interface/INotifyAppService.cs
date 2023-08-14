using System.Threading.Tasks;
using iChiba.Portal.CS.PublicApi.Driver.Request;
using iChiba.Portal.CS.PublicApi.Driver.Response;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface INotifyAppService
    {
        Task<AddOrUpdateCustomerNotifyConfigResponse> AddOrUpdateCustomerNotifyConfig(AddOrUpdateCustomerNotifyConfigRequest request);

        Task<GetNotifyGroupByAppIdResponse> GetNotifyGroupByAppId(GetNotifyGroupByAppIdRequest request);
    }
}