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
    public class AboutAppService : BaseAppService, IAboutAppService
    {
        private readonly IAboutService aboutService;

        public AboutAppService(ILogger<AboutAppService> logger,
            IAboutService aboutService
            )
            : base(logger)
        {
            this.aboutService = aboutService;
        }


        public async Task<BaseEntityResponse<IList<About>>> GetAll(string languageId)
        {
            var response = new BaseEntityResponse<IList<About>>();
            await TryCatchAsync(async () =>
            {
                var data = await aboutService.GetAll(languageId);

                var responseData = data.Select(m => m.ToModel()).OrderBy(m => m.Order).ToList();
                response.SetData(responseData)
                    .Successful();

                return response;
            }, response);

            return response;
        }
    }
}
