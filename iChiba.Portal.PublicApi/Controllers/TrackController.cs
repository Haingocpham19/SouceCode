using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class TrackConfig
    {
        public string Order { get; set; }
        public string PublicOrder { get; set; }
    }

    [Authorize]
    public class TrackController : BaseController
    {
        private readonly ITrackAppService trackAppService;
        private readonly IOptions<TrackConfig> trackConfig;

        public TrackController(ILogger<TrackController> logger,
            ITrackAppService trackAppService,
            IOptions<TrackConfig> trackConfig)
            : base(logger)
        {
            this.trackAppService = trackAppService;
            this.trackConfig = trackConfig;
        }

        [HttpPost]
        public async Task<IActionResult> Order(TrackOrderRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = trackConfig.Value.Order;
            var baseApi = new BaseApiRequest
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await trackAppService.Order(request, baseApi);
            return Ok(response);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PublicOrder(TrackOrderRequest request)
        {
            var url = trackConfig.Value.PublicOrder;
            var baseApi = new BaseApiRequest
            {
                Url = url
            };
            var response = await trackAppService.PublicOrder(request, baseApi);
            return Ok(response);
        }
    }
}
