using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface IShoppingCartAppService
    {
        Task<BaseEntityResponse<string>> Add(ShoppingCartAddRequest request);
        Task<BaseResponse> AddTemp(ShoppingCartAddTempRequest request);
        Task<BaseResponse> AddTemps(ShoppingCartAddTempMultiItemRequest request);
        Task<BaseEntityResponse<ShoppingCart>> GetCurrent(ShoppingCartGetCurrentRequest request);
        Task<BaseResponse> Merge(ShoppingCartMergeRequest request);
        Task<BaseEntityResponse<ShoppingCart>> OrderConfirm(ShoppingCartOrderConfirmRequest request);
        Task<BaseResponse> Remove(ShoppingCartRemoveItemRequest request);
        Task<BaseResponse> Removes(ShoppingCartRemovesItemRequest request);
        Task<BaseEntityResponse<ShoppingCart>> OrderConfirmByListProductId(IList<string> productIds);
    }
}
