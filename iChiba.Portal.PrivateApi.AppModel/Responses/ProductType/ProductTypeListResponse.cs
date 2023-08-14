using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Models;

namespace iChiba.Portal.PrivateApi.AppModel.Responses
{
    public class ProductTypeListResponse : BaseEntityResponse<ProductTypeList>
    {
        public ProductTypeListResponse()
        {
            Data = new ProductTypeList();
        }
    }
}
