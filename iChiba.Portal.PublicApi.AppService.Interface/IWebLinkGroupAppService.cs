using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface IWebLinkGroupAppService
    {
        Task<BaseEntityResponse<IList<WebLinkGroup>>> GetAll(WebLinkGroupRequest request);
        Task<BaseEntityResponse<IList<WebLink>>> GetWebLinkByGroupId(WebLinkByGroupIdRequest request);
        Task<BaseEntityResponse<IList<WebLinkGroup>>> GetWebLinkGroup(WebLinkGroupRequest request);
        Task<BaseEntityResponse<IList<WebLinkGroup>>> GetWebLinkGroupTop(WebLinkGroupTopRequest request);
    }
}
