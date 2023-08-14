using Core.Common;
using Core.Elasticsearch;
using iChiba.Portal.Index.Interface;
using iChiba.Portal.Index.Model;
using Nest;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iChiba.Portal.Index.Elasticsearch.Implement
{
    public class NewsElasticConnectionSetting : ElasticConnectionSetting
    {
    }

    public class NewsIndex : INewsIndex
    {
        private readonly ElasticIndexer<NewsElasticConnectionSetting> elasticIndexer;

        public NewsIndex(ElasticIndexer<NewsElasticConnectionSetting> elasticIndexer)
        {
            this.elasticIndexer = elasticIndexer;

        //add or update item to ES
        }
        public Task<IndexResult> Index(News model)
        {
            return elasticIndexer.IndexDocument(model);
        }

        public Task<IndexResult> Index(params News[] models)
        {
            return elasticIndexer.IndexDocuments(models);
        }

        public async Task<SearchResult<News>> List(int? categoryId, string keyword, Paging paging, string languageId)
        {
            var response = await elasticIndexer.Client.SearchAsync<News>(s => s
                    .From(paging.FromIndex)
                    .Size(paging.PageSize)
                    .Query(q =>
                         q.Match(c => c
                            .Field(p => p.LanguageId)
                            .Query(languageId)
                            .Operator(Operator.And)
                            .Name(languageId)
                        ) &&
                        q.Match(c => c
                            .Field(p => p.Status)
                            .Query("1")
                            .Operator(Operator.And)
                            .Name("1")
                        ) &&
                        q.Match(c => c
                            .Field(p => p.Title)
                            .Query(keyword)
                            .Operator(Operator.And)
                            .Name(keyword)
                        )
                        &&
                        q.Bool(b => b
                            .Filter(f => {
                                QueryContainer query = null;

                                if (categoryId != 0 && categoryId != null)
                                {
                                    query = f.Terms(t => t.Field(ff => ff.CategoryId).Terms(categoryId));
                                }

                                return query;
                            }))
                    //&&
                    //q.Match(c => c
                    //    .Field(p => p.CategoryId)
                    //    .Query(categoryId.ToString())
                    //    .Operator(Operator.Or)
                    //    .Name(categoryId.ToString())
                    //)
                    )
                    .Sort(st => st.Descending(g => g.CreatedDate))
                //.Sort(ss => 
                //{
                //    // return sort.Equals(Sort.SORT_DIRECTION_ASC) ? ss.Ascending(sa => sort.SortBy) : ss.Descending(sd => sort.SortBy);
                //})
                );

            return elasticIndexer.MapResponseToSearchResult(response, paging);
        }

        public async Task<ISearchResponse<News>> TopNewsLastest(int? categoryId, int limit, string languageId)
        {
            var response = await elasticIndexer.Client.SearchAsync<News>(s => s
                    .Query(q =>
                        q.Match(c => c
                        .Field(p => p.Status)
                        .Query("1")
                        .Operator(Operator.And)
                        .Name("1"))
                        &&
                        q.Match(c => c
                        .Field(p => p.LanguageId)
                        .Query(languageId)
                        .Operator(Operator.And)
                        .Name(languageId))
                        &&
                        q.Bool(b => b
                            .Filter(f => {
                                QueryContainer query = null;

                                if (categoryId != 0 && categoryId != null)
                                {
                                    query = f.Terms(t => t.Field(ff => ff.CategoryId).Terms(categoryId));
                                }

                                return query;
                            }))
                    )
                    .Sort(st => st.Descending(g => g.CreatedDate))
                    .Take(limit)
                );

            return response;
        }

        public async Task<ISearchResponse<News>> TopNewsHighlight(int? categoryId, int limit, string languageId)
        {
            var response = await elasticIndexer.Client.SearchAsync<News>(s => s
                    .Query(q => q
                        .Match(c => c
                        .Field(p => p.Status)
                        .Query("1")
                        .Operator(Operator.And)
                        .Name("1"))
                        &&
                        q
                        .ConstantScore(c => c
                        .Filter(f => f.Term(t=> t.Hot, true)))
                        &&
                        q.Match(c => c
                        .Field(p => p.LanguageId)
                        .Query(languageId)
                        .Operator(Operator.And)
                        .Name(languageId))
                        &&
                        q.Bool(b => b
                            .Filter(f => {
                                QueryContainer query = null;

                                if (categoryId != 0 && categoryId != null)
                                {
                                    query = f.Terms(t => t.Field(ff => ff.CategoryId).Terms(categoryId));
                                }

                                return query;
                            }))
                    )
                    .Sort(st => st.Descending(g => g.CreatedDate))
                    .Take(limit)
                );

            return response;
        }

        public async Task<SearchResult<News>> Search(int[] categoryIds, Paging paging)
        {
            var response = await elasticIndexer.Client.SearchAsync<News>(s => s
                    .From(paging.FromIndex)
                    .Size(paging.PageSize)
                    .Query(q => q
                        .Terms(t => t
                            .Field(f => f.CategoryId)
                            .Terms(categoryIds)
                        )
                    )
                );

            return elasticIndexer.MapResponseToSearchResult(response, paging);
        }

        public async Task<News> GetDetail(string id)
        {
            try
            {
                var response = await elasticIndexer.Client.GetAsync<News>(id);

                return response.Source;
            }
            catch (System.Exception ex)
            {
                var log = ex.Message;
                throw;
            }
          
        }

        public async Task<ISearchResponse<News>> GetDetailByMetaTitle(string metaTitle, string languageId)
        {

            var response = await elasticIndexer.Client.SearchAsync<News>(s => s
                    .Query(q => q
                            .Match(m => m
                                .Field(f => f.MetaTitle)
                                .Query(metaTitle)
                            ) && q
                            .Match(m => m
                                .Field(f => f.LanguageId)
                                .Query(languageId)
                            )
                        )
                    );

            return response;
        }

        //public async Task<IList<News>> GetByIds(int[] ids)
        //{
        //    var response = await elasticIndexer.Client.SearchAsync<News>(s => s
        //            .Query(q => q
        //                .Terms(t => t
        //                    .Field(f => f.Id)
        //                    .Terms(ids)
        //                )
        //            )
        //        );

        //    if (!response.IsValid)
        //    {
        //        return new List<News>();
        //    }

        //    return response.Documents?.ToList();
        //}

        public async Task<bool> Delete(int id)
        {
            var response = await elasticIndexer.Client.DeleteAsync<News>(id);
            return response.IsValid;
        }

        public async Task<SearchResult<News>> ListByTag(int tagId, string languageId, Paging paging)
        {
            var response = await elasticIndexer.Client.SearchAsync<News>(s => s
                    .From(paging.FromIndex)
                    .Size(paging.PageSize)
                    .Query(q =>
                        q.Match(c => c
                            .Field(p => p.LanguageId)
                            .Query(languageId)
                            .Operator(Operator.And)
                            .Name(languageId)
                        ) &&
                        q.Match(c => c
                            .Field(p => p.Status)
                            .Query("1")
                            .Operator(Operator.And)
                            .Name("1")
                        ) &&
                        q.Match(c => c
                            .Field(p => p.Tags)
                            .Query(tagId.ToString())
                        )
                    )
                    .Sort(st => st.Descending(g => g.CreatedDate))
                );

            return elasticIndexer.MapResponseToSearchResult(response, paging);
        }
    }
}
