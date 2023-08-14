using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Interface
{
    public interface INewsAppService
    {
        Task<PagingResponse<IList<News>>> GetList(NewsListRequest request);
        Task<BaseEntityResponse<IList<News>>> GetTopNewsLastest(NewsTopRequest request);
        Task<BaseEntityResponse<IList<News>>> GetTopNewsHighlight(NewsTopRequest request);
        Task<BaseEntityResponse<News>> GetDetailByMetaTitle(NewsDetailRequest request);
        Task<BaseEntityResponse<News>> GetDetail(string id);
        Task<PagingResponse<IList<News>>> GetListByTag(NewsListByTagRequest request);
    }
}
