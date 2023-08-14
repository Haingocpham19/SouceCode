using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface ICustomerWarehouseAppService
    {
        Task<BaseEntityResponse<IList<CustomerWarehouse>>> GetWarehousesByCustomer(BaseApiRequest baseApi);
        Task<BaseResponse> Add(CustomerWarehouseAddRequest request, BaseApiRequest baseApi);
        Task<BaseResponse> Delete(int warehouseId, BaseApiRequest baseApi);
    }
}
