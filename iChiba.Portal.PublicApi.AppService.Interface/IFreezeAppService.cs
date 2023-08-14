using Core.AppModel.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface IFreezeAppService
    {
        Task<PagingResponse<IList<Freeze>>> GetList(FreezeListRequest request, BaseApiRequest baseApi);
        Task<BaseResponse> TemporaryDepositVIP(BaseApiRequest baseApi);
        Task<BaseResponse> TemporaryDepositVIPCancel(BaseApiRequest baseApi);
        Task<BaseEntityResponse<Freeze>> CurrentTemporaryDepositVIP(BaseApiRequest baseApi);
        Task<BaseEntityResponse<bool>> CheckTemporaryDepositVIP(BaseApiRequest baseApi);
    }
}
