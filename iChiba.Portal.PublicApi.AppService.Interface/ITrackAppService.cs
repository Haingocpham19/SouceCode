using System.Threading.Tasks;
using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppModel.Response;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface ITrackAppService
    {
        Task<BaseEntityResponse<TrackOrderResponse>> Order(TrackOrderRequest request, BaseApiRequest baseApi);
        Task<BaseEntityResponse<TrackOrderResponse>> PublicOrder(TrackOrderRequest request, BaseApiRequest baseApi);
    }
}
