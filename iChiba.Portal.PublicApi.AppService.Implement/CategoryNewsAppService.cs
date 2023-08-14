using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppService.Implement.Adapter;
using iChiba.Portal.PublicApi.AppService.Interface;
using Core.AppModel.Response;
using System.Collections.Generic;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class CategoryNewsAppService : BaseAppService, ICategoryNewsAppService
    {
        private readonly ICategoryNewsService categoryNewsService;

        public CategoryNewsAppService(ILogger<CategoryNewsAppService> logger,
            ICategoryNewsService categoryNewsService
            )
            : base(logger)
        {
            this.categoryNewsService = categoryNewsService;
        }


        public async Task<BaseEntityResponse<IList<CategoryNews>>> GetAll(string languageId)
        {
            var response = new BaseEntityResponse<IList<CategoryNews>>();
            await TryCatchAsync(async () =>
            {
                var data = await categoryNewsService.GetAll(languageId);

                if (data != null)
                {
                    var responseData = data.Select(m => m.ToModel()).OrderBy(m => m.Order).ToList();
                    response.SetData(responseData)
                        .Successful();
                }

                return response;
            }, response);

            return response;
        }
    }
}
