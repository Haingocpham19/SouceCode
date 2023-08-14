using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppModel.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface IOrderAppService
    {
        Task<PagingResponse<IList<Order>>> GetList(OrderListRequest request, BaseApiRequest baseApi);

        Task<BaseEntityResponse<IList<Order>>> GetListAll(OrderListRequest request, BaseApiRequest baseApi);

        Task<BaseEntityResponse<Order>> GetById(int id, BaseApiRequest baseApi);

        Task<BaseResponse> UpdateAddress(OrderAddressRequest request, BaseApiRequest baseApi);

        Task<BaseResponse> RateOrder(OrderRatingRequest request, BaseApiRequest baseApi);

        Task<BaseEntityResponse<IList<int>>> Add(OrderAddRequest request);

        Task<BaseResponse> UpdateOrderStatus(OrderUpdateStatusRequest request, BaseApiRequest baseApi);

        Task<BaseResponse> ConfirmDelivery(OrderConfirmDeliveryRequest request);

        Task<BaseResponse> UpdatesAddress(OrderUpdateAddressRequest request, BaseApiRequest baseApi);

        Task<BaseEntityResponse<IList<Order>>> GetByIds(int[] ids, BaseApiRequest baseApi);

        Task<BaseResponse> PayOrders(OrderPaysRequest request, BaseApiRequest baseApi);

        Task<BaseEntityResponse<int>> GetTotal(OrderTotalRequest request, BaseApiRequest baseApi);

        Task<BaseEntityResponse<IDictionary<int, int>>> CountOrderByStatus(OrderTotalRequest request, BaseApiRequest baseApi);

        Task<BaseResponse> ConfirmDeliveries(OrderConfirmDeliveriesRequest request);

        Task<BaseEntityResponse<IList<int>>> AddFromWebLink(OrderAddFromWebLinkRequest request, BaseApiRequest baseApi);

        Task<BaseEntityResponse<bool>> GetAllOrderFinalization(BaseApiRequest baseApi);

        Task<BaseEntityResponse<IList<int>>> AddOrderAndPayment(OrderAddRequest request);

        Task<BaseResponse> UpdateOrderServiceMapping(OrderServiceMappingUpdateRequest request, BaseApiRequest baseApi);

        Task<BaseResponse> UpdateDDImportType(OrderUpdateDDImportTypeRequest request, BaseApiRequest baseApi);

        Task<BaseResponse> PaymentOrders(OrderPaysRequest request, BaseApiRequest baseApi);

        Task<BaseEntityResponse<Order>> GetByCodeAndPhoneOrEmail(OrderSearchRequest request, BaseApiRequest baseApi);

        Task<OrderGetByQuoteCodeResponse> GetListAllByQuoteCode(OrderListRequest request, BaseApiRequest baseApi);

        Task<PagingResponse<IList<Order>>> GetListPaidNotQuoteCode(OrderListRequest request, BaseApiRequest baseApi);
        Task<BaseResponse> RateOrderByBillCode(OrderRatingByBillCodeRequest request, BaseApiRequest baseApi);
        Task<BaseEntityResponse<OrderGetByQuoteCode>> GetListByQuoteCode(OrderListByBillCodeRequest request, BaseApiRequest baseApi);
        Task<BaseEntityResponse<(long TotalPayment, long TotalPaid)>> TotalPaymentListPaidNotQuoteCode(BaseApiRequest baseApi);

        //Task<BaseResponse> PayNowFromWallet(PaymentNowFromWalletRequest request);
    }
}