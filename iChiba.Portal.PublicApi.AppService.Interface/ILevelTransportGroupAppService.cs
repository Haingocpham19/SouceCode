using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface ILevelTransportGroupAppService
    {
        Task<BaseEntityResponse<IList<LevelTransportGroup>>> GetByLevel(int id, BaseApiRequest baseApi);
        Task<BaseEntityResponse<IList<ProductTypeList>>> ProductTypeByGroup(int id, BaseApiRequest baseApi);
        Task<BaseEntityResponse<IList<ProductTypeGroup>>> ProductTypeGroup(BaseApiRequest baseApi);
    }
}
