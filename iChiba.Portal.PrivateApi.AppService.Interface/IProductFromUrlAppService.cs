using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Models;
using Ichiba.Partner.Api.Driver.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.AppService.Interface
{
    public interface IProductFromUrlAppService
    {
        Task<BaseEntityResponse<ProductDetail>> Detail(ProductDetailFromUrlRequest request);
        Task<BaseEntityResponse<List<ProductDetail>>> GetListDetail(ProductDetailFromUrlListRequest request);
    }
}
