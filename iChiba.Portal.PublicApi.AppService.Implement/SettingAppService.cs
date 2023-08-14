using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppService.Implement.Adapter;
using iChiba.Portal.PublicApi.AppService.Interface;
using iChiba.Portal.Service.Interface;
using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class SettingAppService : BaseAppService, ISettingAppService
    {
        private readonly ISettingService settingService;

        public SettingAppService(ILogger<SettingAppService> logger,
            ISettingService settingService
            )
            : base(logger)
        {
            this.settingService = settingService;
        }


        public async Task<BaseEntityResponse<List<Settings>>> GetAll(string languageId)
        {
            var response = new BaseEntityResponse<List<Settings>>();
            await TryCatchAsync(async () =>
            {

                var data = await settingService.GetAll(languageId);

                var responseData = data.Select(m => m.ToModel()).ToList();
                response.SetData(responseData)
                    .Successful();

                return response;
            }, response);

            return response;
        }

    }
}
