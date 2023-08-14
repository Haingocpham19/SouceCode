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
    public class DepositConfig
    {
        public string GetList { get; set; }
        public string GetDetail { get; set; }
        public string GetWaiting { get; set; }
        public string Add { get; set; }
        public string Delete { get; set; }
        public string Cancel { get; set; }
        public string UpdatePayImage { get; set; }
        public string GetByOrderCodeInNote { get; set; }
    }

    [Authorize]
    public class DepositController : BaseController
    {
        private readonly DepositConfig depositConfig;
        private readonly IDepositAppService depositAppService;

        public DepositController(ILogger<DepositController> logger,
            IOptions<DepositConfig> depositConfig,
            IDepositAppService depositAppService
            )
            : base(logger)
        {
            this.depositConfig = depositConfig.Value;
            this.depositAppService = depositAppService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PagingResponse<IList<Deposit>>))]
        public async Task<IActionResult> GetList(DepositListRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = depositConfig.GetList;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await depositAppService.GetList(request, baseApi); 
            return Ok(response);
        }

      
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<Deposit>))]
        public async Task<IActionResult> GetDetail(DepositDetailRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = depositConfig.GetDetail;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await depositAppService.GetById(request, baseApi);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<Deposit>))]
        public async Task<IActionResult> GetByOrderCodeInNote(DepositGetByOrderCodeInNoteRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = depositConfig.GetByOrderCodeInNote;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await depositAppService.GetByOrderCodeInNote(request, baseApi);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<int>))]
        public async Task<IActionResult> Add(DepositAddRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = depositConfig.Add;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await depositAppService.Add(request, baseApi);
            return Ok(response);
        }

        [HttpPost("{id}")]
        //[Produces("text/plain")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Delete(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = depositConfig.Delete;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await depositAppService.Delete(id, baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<Deposit>))]
        public async Task<IActionResult> GetWaiting()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = depositConfig.GetWaiting;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await depositAppService.GetWaiting(baseApi);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Cancel(DepositCancelRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = depositConfig.Cancel;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await depositAppService.Cancel(request, baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> UpdatePayImage(DepositUpdatePayImageRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = depositConfig.UpdatePayImage;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await depositAppService.UpdatePayImage(request, baseApi);
            return Ok(response);
        }
    }
}