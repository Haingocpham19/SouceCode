using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class TrackingOrderConfig
    {
        public string GetPackageTracking { get; set; }
    }

    [Authorize]
    public class TrackingOrderController : BaseController
    {
        private readonly IPackageTrackingAppService packageTrackingAppService;
        private readonly TrackingOrderConfig trackingConfig;

        public TrackingOrderController(ILogger<TrackingOrderController> logger,
            IPackageTrackingAppService packageTrackingAppService,
             IOptions<TrackingOrderConfig> trackingConfig)
            : base(logger)
        {
            this.packageTrackingAppService = packageTrackingAppService;
            this.trackingConfig = trackingConfig.Value;
        }

        [HttpGet("{tracking}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<PackageTracking>>))]
        public async Task<IActionResult> GetPackageTracking(string tracking)
        {
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var url = trackingConfig.GetPackageTracking;
                var baseApi = new BaseApiRequest()
                {
                    Accesstoken = accessToken,
                    Url = url
                };
                var response = await packageTrackingAppService.GetsPackageTracking(tracking, baseApi);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                return BadRequest();
            }
        }
    }
}