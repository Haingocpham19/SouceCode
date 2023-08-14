using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface IAboutAppService
    {
        Task<BaseEntityResponse<IList<About>>> GetAll(string languageId);
    }
}
