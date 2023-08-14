using Core.AppModel.Response;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class FreezeCsConfig
    {
        public string GetList { get; set; }
        public string TemporaryDepositVIP { get; set; }
        public string TemporaryDepositVIPCancel { get; set; }
        public string CurrentTemporaryDepositVIP { get; set; }
        public string CheckTemporaryDepositVIP { get; set; }
    }

    [Authorize]
    public class FreezeController : BaseController
    {
        private readonly FreezeCsConfig freezeConfig;
        private readonly IFreezeAppService freezeAppService;

        public FreezeController(ILogger<FreezeController> logger,
            IOptions<FreezeCsConfig> freezeConfig,
            IFreezeAppService freezeAppService
            )
            : base(logger)
        {
            this.freezeConfig = freezeConfig.Value;
            this.freezeAppService = freezeAppService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PagingResponse<IList<Freeze>>))]
        public async Task<IActionResult> GetList(FreezeListRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = freezeConfig.GetList;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await freezeAppService.GetList(request, baseApi); 
            return Ok(response);
        }

      
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<Freeze>))]
        public async Task<IActionResult> CurrentTemporaryDepositVIP()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = freezeConfig.CurrentTemporaryDepositVIP;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await freezeAppService.CurrentTemporaryDepositVIP(baseApi);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> TemporaryDepositVIP()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = freezeConfig.TemporaryDepositVIP;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await freezeAppService.TemporaryDepositVIP(baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<bool>))]
        public async Task<IActionResult> CheckTemporaryDepositVIP()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = freezeConfig.CurrentTemporaryDepositVIP;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await freezeAppService.CheckTemporaryDepositVIP(baseApi);

            return Ok(response);
        }

        

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> TemporaryDepositVIPCancel()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = freezeConfig.TemporaryDepositVIPCancel;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await freezeAppService.TemporaryDepositVIPCancel(baseApi);
            return Ok(response);
        }
    }
}