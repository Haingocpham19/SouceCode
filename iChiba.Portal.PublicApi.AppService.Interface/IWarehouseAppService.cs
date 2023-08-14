using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface IWarehouseAppService
    {
        Task<BaseEntityResponse<IList<Warehouse>>> GetAllWarehouseActive(BaseApiRequest baseApi);
        Task<BaseEntityResponse<Warehouse>> GetDetail(BaseApiRequest baseApi, int id);
        Task<BaseEntityResponse<Warehouse>> GetByCode(BaseApiRequest baseApi, string code);
    }
}
