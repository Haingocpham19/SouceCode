using iChibaShopping.Core.AppService.Implement;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Implement.Adapter;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppService.Interface;
using Core.AppModel.Response;
using System.Collections.Generic;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class AdvBannerAppService : BaseAppService, IAdvBannerAppService
    {
        private readonly IAdvBannerService advBannerService;

        public AdvBannerAppService(ILogger<AdvBannerAppService> logger,
            IAdvBannerService advBannerService
            )
            : base(logger)
        {
            this.advBannerService = advBannerService;
        }


        public async Task<BaseEntityResponse<IList<AdvBanner>>> GetAdvBannerByKey(AdvBannerRequest request)
        {
            var response = new BaseEntityResponse<IList<AdvBanner>>();
            await TryCatchAsync(async () =>
            {

                var data = await advBannerService.GetBykey(request.KeyBanner, request.LanguageId);
                if (data != null && data?.FirstOrDefault() != null)
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
