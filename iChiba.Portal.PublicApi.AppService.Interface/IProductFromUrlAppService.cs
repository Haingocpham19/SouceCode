using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface IProductFromUrlAppService
    {
        Task<BaseEntityResponse<ProductDetail>> Detail(ProductDetailFromUrlRequest request);
        Task<BaseEntityResponse<IList<ShipquocteNews>>> TopNews(int limit);
    }
}
