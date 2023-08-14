using Core.AppModel.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface IWithDrawalAppService
    {
        Task<PagingResponse<IList<WithDrawal>>> GetList(WithDrawalListRequest request, BaseApiRequest baseApi);
        Task<BaseEntityResponse<WithDrawal>> GetById(WithDrawalDetailRequest request, BaseApiRequest baseApi);
        Task<BaseEntityResponse<int>> Add(WithDrawalAddRequest request, BaseApiRequest baseApi);
        Task<BaseResponse> Cancel(WithDrawalCancelRequest request, BaseApiRequest baseApi);
        Task<BaseEntityResponse<WithDrawal>> GetWaiting(BaseApiRequest baseApi);
    }
}
