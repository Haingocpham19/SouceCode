using Core.Common;
using Core.Elasticsearch;
using iChiba.Portal.Index.Model;
using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Service.Interface
{
    public interface INewsService
    {
        Task<IndexResult> Index(News model);
        Task<IndexResult> Index(params News[] models);
        Task<SearchResult<News>> List(int categoryId, string keyword, Paging paging, string languageId);
        Task<ISearchResponse<News>> TopNewsLastest(int? categoryId, int limit, string languageId);
        Task<ISearchResponse<News>> TopNewsHighlight(int? categoryId, int limit, string languageId);
        Task<ISearchResponse<News>> GetDetailByMetaTitle(string metaTitle, string languageId);
        Task<News> GetDetail(string id);
        Task<bool> Delete(int id);
        Task<SearchResult<News>> ListByTag(int tagId, Paging paging, string languageId);
    }
}
