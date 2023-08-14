using iChibaShopping.Core.AppService.Implement;
using iChibaShopping.Core.CustomException;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Implement.Adapter;
using iChiba.Portal.PublicApi.AppService.Interface;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Core.AppModel.Response;
using System.Collections.Generic;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class NewsAppService : BaseAppService, INewsAppService
    {
        private readonly INewsService newsService;

        public NewsAppService(ILogger<NewsAppService> logger,
            INewsService newsService
            )
            : base(logger)
        {
            this.newsService = newsService;
        }


        public async Task<PagingResponse<IList<News>>> GetList(NewsListRequest request)
        {
            var response = new PagingResponse<IList<News>>();
            await TryCatchAsync(async () =>
            {
                var paging = request.ToPaging();
                var data = await newsService.List(request.CategoryId, request.Keyword, paging, request.LanguageId);
                if (!data.IsValid)
                {
                    response.Fail(ErrorCodeDefine.UNKNOW_ERROR); // TODO: Define error code

                    return response;
                }

                if (data != null)
                {
                    var responseData = data.Results.Select(g => g.ToModel()).ToList();

                    response
                        .FromPaging(paging)
                        .SetData(responseData)
                        .Successful();
                }

                return response;
            }, response);

            return response;

        }


        public async Task<BaseEntityResponse<IList<News>>> GetTopNewsLastest(NewsTopRequest request)
        {
            var response = new BaseEntityResponse<IList<News>>();
            await TryCatchAsync(async () =>
            {
                var data = await newsService.TopNewsLastest(request.CategoryId, request.Limit, request.LanguageId);
                if (!data.IsValid)
                {
                    response.Fail(ErrorCodeDefine.UNKNOW_ERROR); // TODO: Define error code

                    return response;
                }

                if (data != null)
                {
                    var responseData = data.Documents.Select(g => g.ToModel()).ToList();

                    response.SetData(responseData)
                        .Successful();
                }

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<IList<News>>> GetTopNewsHighlight(NewsTopRequest request)
        {
            var response = new BaseEntityResponse<IList<News>>();
            await TryCatchAsync(async () =>
            {
                var data = await newsService.TopNewsHighlight(request.CategoryId, request.Limit, request.LanguageId);
                if (!data.IsValid)
                {
                    response.Fail(ErrorCodeDefine.UNKNOW_ERROR); // TODO: Define error code

                    return response;
                }

                if (data != null)
                {
                    var responseData = data.Documents.Select(g => g.ToModel()).ToList();

                    response.SetData(responseData)
                        .Successful();
                }

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<News>> GetDetailByMetaTitle(NewsDetailRequest request)
        {
            var response = new BaseEntityResponse<News>();
            await TryCatchAsync(async () =>
            {
                var data = await newsService.GetDetailByMetaTitle(request.MetaTitle, request.LanguageId);
                if (!data.IsValid)
                {
                    response.Fail(ErrorCodeDefine.UNKNOW_ERROR); // TODO: Define error code

                    return response;
                }
                if (data != null)
                {
                    var responseData = data.Documents.Select(g => g.ToModel()).FirstOrDefault();
                    response.SetData(responseData)
                        .Successful();
                }

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<News>> GetDetail(string id)
        {
            var response = new BaseEntityResponse<News>();
            await TryCatchAsync(async () =>
            {
                var data = await newsService.GetDetail(id);
                if (data == null)
                {
                    response.Fail(ErrorCodeDefine.UNKNOW_ERROR); // TODO: Define error code

                    return response;
                }
                if (data != null)
                {
                    var responseData = data.ToModel();
                    response.SetData(responseData)
                        .Successful();
                }

                return response;
            }, response);

            return response;
        }

        public async Task<PagingResponse<IList<News>>> GetListByTag(NewsListByTagRequest request)
        {
            var response = new PagingResponse<IList<News>>();
            await TryCatchAsync(async () =>
            {
                var paging = request.ToPaging();
                var data = await newsService.ListByTag(request.TagId, paging, request.LanguageId);
                if (!data.IsValid)
                {
                    response.Fail(ErrorCodeDefine.UNKNOW_ERROR); // TODO: Define error code

                    return response;
                }

                if (data != null)
                {
                    var responseData = data.Results.Select(g => g.ToModel()).ToList();

                    response
                        .FromPaging(paging)
                        .SetData(responseData)
                        .Successful();
                }

                return response;
            }, response);

            return response;

        }
    }
}
