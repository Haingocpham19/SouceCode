using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.Portal.PrivateApi.AppModel.Requests;
using iChiba.Portal.PrivateApi.AppModel.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.AppService.Interface
{
    public interface IOrderAppService
    {
        Task<OrderListResponse> GetListOrder(OrderRequest request);
        Task<OrderResponse> GetOrderDetail(OrderDetailRequest request);
        Task<PackageDetailQuoteListResponse> GetListPackageDetailQuote(PackageDetailQuoteRequest request);
        Task<BaseEntityResponse<IList<OrderMessageViewModel>>> GetMessages(OrderMessageRequest request);
        Task<BaseResponse> AddRange(IEnumerable<OrderTransportRequest> request);
        Task<ShoppingCartListResponse> GetListShoppingCart(ShoppingCartRequest request);
        Task<ShoppingCartResponse> AddShoppingCart(ShoppingCartRequest request);
        Task<ShoppingCartResponse> DeleteShoppingCart(ShoppingCartDeleteRequest request);
        Task<ShoppingCartCUDResponse> DeleteShoppingCartITem(ShoppingCartItemDeleteRequest request);
        Task<OrderBuyForYouAddResponse> AddNewOrder(OrderBuyForYouAddRequest request);
        //Task<MemberShipLevelERP> GetCustomerProfileErp(string AccountId);
    }
}
