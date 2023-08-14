using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class AdvBannerController : BaseController
    {
        private readonly IAdvBannerAppService advBannerAppService;

        public AdvBannerController(ILogger<AdvBannerController> logger,
            IAdvBannerAppService AdvBannerAppService)
            : base(logger)
        {
            this.advBannerAppService = AdvBannerAppService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<AdvBanner>>))]
        public async Task<IActionResult> GetAdvBannerByKey(AdvBannerRequest request)
        {
            var response = await advBannerAppService.GetAdvBannerByKey(request);

            return Ok(response);
        }

    }
}
