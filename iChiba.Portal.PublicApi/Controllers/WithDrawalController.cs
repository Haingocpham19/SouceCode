using Core.AppModel.Response;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class WithDrawalConfig
    {
        public string GetList { get; set; }
        public string GetDetail { get; set; }
        public string Add { get; set; }
        public string Cancel { get; set; }
        public string GetWaiting { get; set; }
    }

    [Authorize]
    public class WithDrawalController : BaseController
    {
        private readonly WithDrawalConfig withDrawalConfig;
        private readonly IWithDrawalAppService withDrawalAppService;

        public WithDrawalController(ILogger<WithDrawalController> logger,
            IOptions<WithDrawalConfig> withDrawalConfig,
            IWithDrawalAppService withDrawalAppService

            )
            : base(logger)
        {
            this.withDrawalConfig = withDrawalConfig.Value;
            this.withDrawalAppService = withDrawalAppService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PagingResponse<IList<WithDrawal>>))]
        public async Task<IActionResult> GetList(WithDrawalListRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = withDrawalConfig.GetList;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };

            var response = await withDrawalAppService.GetList(request, baseApi); 
            return Ok(response);
        }

      
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<WithDrawal>))]
        public async Task<IActionResult> GetDetail(WithDrawalDetailRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = withDrawalConfig.GetDetail;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };

            var response = await withDrawalAppService.GetById(request, baseApi);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<int>))]
        public async Task<IActionResult> Add(WithDrawalAddRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = withDrawalConfig.Add;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };

            var response = await withDrawalAppService.Add(request, baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Cancel(WithDrawalCancelRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = withDrawalConfig.Cancel;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };

            var response = await withDrawalAppService.Cancel(request, baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<WithDrawal>))]
        public async Task<IActionResult> GetWaiting()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = withDrawalConfig.GetWaiting;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };

            var response = await withDrawalAppService.GetWaiting(baseApi);

            return Ok(response);
        }
    }

}