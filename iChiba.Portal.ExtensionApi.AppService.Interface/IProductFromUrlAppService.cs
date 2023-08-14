using Core.AppModel.Response;
using iChiba.Portal.ExtensionApi.AppModel.Model.ProductDetail;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ichiba.Partner.Api.Driver.Request;

namespace iChiba.Portal.ExtensionApi.AppService.Interface.ProductFromUrlAppService
{
    public interface IProductFromUrlAppService
    {
        Task<BaseEntityResponse<ProductDetailViewModel>> Detail(ProductDetailFromUrlRequest request);
        Task<BaseEntityResponse<List<ProductDetailViewModel>>> GetListDetail(ProductDetailFromUrlListRequest request);
    }
}
