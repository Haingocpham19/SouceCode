using Core.AppModel.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface IDepositAppService
    {
        Task<PagingResponse<IList<Deposit>>> GetList(DepositListRequest request, BaseApiRequest baseApi);
        Task<BaseEntityResponse<Deposit>> GetById(DepositDetailRequest request, BaseApiRequest baseApi);
        Task<BaseEntityResponse<int>> Add(DepositAddRequest request, BaseApiRequest baseApi);
        Task<BaseResponse> Delete(int id, BaseApiRequest baseApi);
        Task<BaseEntityResponse<Deposit>> GetWaiting(BaseApiRequest baseApi);
        Task<BaseResponse> Cancel(DepositCancelRequest request, BaseApiRequest baseApi);
        Task<BaseResponse> UpdatePayImage(DepositUpdatePayImageRequest request, BaseApiRequest baseApi);
        Task<BaseEntityResponse<Deposit>> GetByOrderCodeInNote(DepositGetByOrderCodeInNoteRequest request, BaseApiRequest baseApi);
    }
}
