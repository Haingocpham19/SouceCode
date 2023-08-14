using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface IOrderServiceAppService
    {
        Task<BaseEntityResponse<IList<OrderService>>> GetListAll(BaseApiRequest baseApi);
        Task<BaseEntityResponse<OrderService>> GetById(int id, BaseApiRequest baseApi);
        Task<BaseEntityResponse<Dictionary<int, List<OrderService>>>> GetServiceActiveByOrderIds(string orderIds, BaseApiRequest baseApi);
    }
}
