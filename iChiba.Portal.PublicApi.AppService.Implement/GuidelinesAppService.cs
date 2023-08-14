using iChibaShopping.Core.AppService.Implement;
using iChiba.Portal.PublicApi.AppService.Implement.Adapter;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppService.Interface;
using System.Collections.Generic;
using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class GuidelinesAppService : BaseAppService, IGuidelinesAppService
    {
        private readonly IGuidelinesService guidelinesService;

        public GuidelinesAppService(ILogger<GuidelinesAppService> logger,
            IGuidelinesService guidelinesService
            )
            : base(logger)
        {
            this.guidelinesService = guidelinesService;
        }


        public async Task<BaseEntityResponse<IList<Guidelines>>> GetAll(string languageId)
        {
            var response = new BaseEntityResponse<IList<Guidelines>>();
            await TryCatchAsync(async () =>
            {
                var data = await guidelinesService.GetAll(languageId);
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
