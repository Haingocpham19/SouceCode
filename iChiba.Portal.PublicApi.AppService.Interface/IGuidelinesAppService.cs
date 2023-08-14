using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface IGuidelinesAppService
    {
        Task<BaseEntityResponse<IList<Guidelines>>> GetAll(string languageId);
    }
}
