using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AppModel.Response;
using iChiba.IS4.Api.Driver.Models.Response;

namespace iChiba.Portal.PrivateApi.AppService.Interface
{
    public interface IAccessAppService
    {
        Task<BaseEntityResponse<IList<Resource>>> GetResources(string warehouseCode);
        Task<BaseResponse> CheckPermission(string resourceKey, string permission);
    }
}
