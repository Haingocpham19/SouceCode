using Core.AppModel.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface IPaymentAppService
    {
        Task<BaseResponse> PayOrder(PaymentPayOrderRequest request, BaseApiRequest baseApi);
        Task<BaseResponse> CancelOrder(PaymentCancelOrderRequest request, BaseApiRequest baseApi);
        Task<BaseEntityResponse<IList<Payment>>> GetListByRef(PaymentListByRefRequest request, BaseApiRequest baseApi);
        Task<PagingResponse<IList<Payment>>> GetListByAccount(PaymentListByAccountRequest request, BaseApiRequest baseApi);
        Task<PagingResponse<IList<Payment>>> GetListByPaymentType(PaymentListByPaymentTypeRequest request, BaseApiRequest baseApi);
    }
}
