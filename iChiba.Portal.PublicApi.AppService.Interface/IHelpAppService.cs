using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface IHelpAppService
    {
        Task<BaseEntityResponse<IList<GroupGuidelines>>> GetAll(string languageId);
    }
}
