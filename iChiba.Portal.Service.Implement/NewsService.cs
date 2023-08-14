using Core.Common;
using Core.Elasticsearch;
using iChiba.Portal.Index.Interface;
using iChiba.Portal.Index.Model;
using iChiba.Portal.Service.Interface;
using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Service.Implement
{
    public class NewsService : INewsService
    {
        private readonly INewsIndex newsIndex;

        public NewsService(INewsIndex newsIndex)
        {
            this.newsIndex = newsIndex;
        }

        public Task<IndexResult> Index(News model)
        {
            return newsIndex.Index(model);
        }

        public Task<IndexResult> Index(params News[] models)
        {
            return newsIndex.Index(models);
        }

        public Task<News> GetDetail(string id)
        {
            return newsIndex.GetDetail(id);
        }

        public Task<ISearchResponse<News>> GetDetailByMetaTitle(string metaTitle, string languageId)
        {
            return newsIndex.GetDetailByMetaTitle(metaTitle, languageId);
        }

        public Task<SearchResult<News>> List(int categoryId, string keyword, Paging paging, string languageId)
        {
            return newsIndex.List(categoryId, keyword, paging, languageId);
        }

        public Task<ISearchResponse<News>> TopNewsLastest(int? categoryId, int limit, string languageId)
        {
            return newsIndex.TopNewsLastest(categoryId, limit, languageId);
        }

        public Task<ISearchResponse<News>> TopNewsHighlight(int? categoryId, int limit, string languageId)
        {
            return newsIndex.TopNewsHighlight(categoryId, limit, languageId);
        }


        public Task<bool> Delete(int id)
        {
            return newsIndex.Delete(id);
        }

        public Task<SearchResult<News>> ListByTag(int tagId, Paging paging, string languageId)
        {
            return newsIndex.ListByTag(tagId, languageId, paging);
        }
    }
}
