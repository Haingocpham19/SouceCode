using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppService.Interface;
using iChiba.Portal.PublicApi.AppService.Implement.Adapter;
using Core.AppModel.Response;
using System.Collections.Generic;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class TagsAppService : BaseAppService, ITagsAppService
    {
        private readonly ITagsService tagsService;

        public TagsAppService(ILogger<TagsAppService> logger,
            ITagsService tagsService
            )
            : base(logger)
        {
            this.tagsService = tagsService;
        }

        public async Task<BaseEntityResponse<IList<Tags>>> GetAll(string languageId)
        {
            var response = new BaseEntityResponse<IList<Tags>>();
            await TryCatchAsync(async () =>
            {
                var data = await tagsService.GetAll(languageId);
                if (data != null)
                {
                    var responseData = data.Select(m => m.ToModel()).ToList();
                    response.SetData(responseData)
                        .Successful();
                }
                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<IList<Tags>>> GetByIds(TagsByIdRequest request)
        {
            var response = new BaseEntityResponse<IList<Tags>>();
            await TryCatchAsync(async () =>
            {
                var data = await tagsService.GetByIds(request.TagsId, request.LanguageId);
                if (data != null)
                {
                    var responseData = data.Select(m => m.ToModel()).ToList();
                    response.SetData(responseData)
                        .Successful();
                }
                return response;
            }, response);

            return response;
        }
    }
}
