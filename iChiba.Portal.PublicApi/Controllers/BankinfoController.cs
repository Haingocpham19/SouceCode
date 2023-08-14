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
    public class BankinfoConfig
    {
        public string GetListAll { get; set; }
        public string GetById { get; set; }
        public string GetByAccountNumber { get; set; }
        public string GetByBankName { get; set; }
        public string GetListByForDepositOrDrawal { get; set; }
    }

    [Authorize]
    public class BankinfoController : BaseController
    {
        private readonly BankinfoConfig bankinfoConfig;
        private readonly IBankinfoAppService bankinfoAppService;

        public BankinfoController(ILogger<BankinfoController> logger,
            IOptions<BankinfoConfig> bankinfoConfig,
            IBankinfoAppService bankinfoAppService
            )
            : base(logger)
        {
            this.bankinfoConfig = bankinfoConfig.Value;
            this.bankinfoAppService = bankinfoAppService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<Bankinfo>>))]
        public async Task<IActionResult> GetListAll()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = bankinfoConfig.GetListAll;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await bankinfoAppService.GetListAll(baseApi); 
            return Ok(response);
        }


        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<Bankinfo>))]
        public async Task<IActionResult> GetById(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = bankinfoConfig.GetById;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await bankinfoAppService.GetById(id, baseApi);

            return Ok(response);
        }

        [HttpGet("{accountNumber}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<Bankinfo>))]
        public async Task<IActionResult> GetByAccountNumber(string accountNumber)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = bankinfoConfig.GetByAccountNumber;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await bankinfoAppService.GetByAccountNumber(accountNumber, baseApi);

            return Ok(response);
        }

        [HttpGet("{bankName}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<Bankinfo>))]
        public async Task<IActionResult> GetByBankName(string bankName)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = bankinfoConfig.GetByBankName;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await bankinfoAppService.GetByBankName(bankName, baseApi);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<Bankinfo>>))]
        public async Task<IActionResult> GetListByForDepositOrDrawal(string bankType = default)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = bankinfoConfig.GetListByForDepositOrDrawal;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await bankinfoAppService.GetListByForDepositOrDrawal(baseApi, bankType);
            return Ok(response);
        }
    }
}