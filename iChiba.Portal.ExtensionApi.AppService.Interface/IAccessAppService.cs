using Core.AppModel.Response;
using iChiba.IS4.Api.Driver.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.ExtensionApi.AppService.Interface
{
    public interface IAccessAppService
    {
        Task<BaseResponse> CheckPermission(string resourceKey, string permission);
        Task<BaseEntityResponse<IList<Resource>>> GetResources();
    }
}
