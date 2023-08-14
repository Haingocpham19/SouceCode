using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppService.Interface;
using System.Collections.Generic;
using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppService.Implement.Adapter;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class CategoryServiceAppService : BaseAppService, ICategoryServiceAppService
    {
        private readonly ICategoryServiceService categoryServiceService;

        public CategoryServiceAppService(ILogger<CategoryServiceAppService> logger,
            ICategoryServiceService categoryServiceService
            )
            : base(logger)
        {
            this.categoryServiceService = categoryServiceService;
        }


        public async Task<BaseEntityResponse<IList<CategoryService>>> GetAll(string languageId)
        {
            var response = new BaseEntityResponse<IList<CategoryService>>();
            await TryCatchAsync(async () =>
            {
                var data = await categoryServiceService.GetAll(languageId);
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
