using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class BankicConfig
    {
        public string GetListAll { get; set; }
        public string GetListActiveDeposit { get; set; }
        public string GetById { get; set; }
        public string GetByAccountNumber { get; set; }
        public string GetByBankName { get; set; }
    }

    [Authorize]
    public class BankicController : BaseController
    {
        private readonly BankicConfig bankicConfig;
        private readonly IBankicAppService bankicAppService;

        public BankicController(ILogger<BankicController> logger,
            IOptions<BankicConfig> bankicConfig,
            IBankicAppService bankicAppService
            )
            : base(logger)
        {
            this.bankicConfig = bankicConfig.Value;
            this.bankicAppService = bankicAppService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<Bankic>>))]
        public async Task<IActionResult> GetListAll()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = bankicConfig.GetListAll;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await bankicAppService.GetListAll(baseApi);
            return Ok(response);
        }


        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<Bankic>>))]
        public async Task<IActionResult> GetListActiveDeposit()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = bankicConfig.GetListActiveDeposit;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await bankicAppService.GetListActiveDeposit(baseApi);
            return Ok(response);
        }


        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<Bankic>))]
        public async Task<IActionResult> GetById(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = bankicConfig.GetById;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await bankicAppService.GetById(id, baseApi);

            return Ok(response);
        }

        [HttpGet("{accountNumber}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<Bankic>))]
        public async Task<IActionResult> GetByAccountNumber(string accountNumber)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = bankicConfig.GetByAccountNumber;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await bankicAppService.GetByAccountNumber(accountNumber, baseApi);

            return Ok(response);
        }

        [HttpGet("{bankName}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<Bankic>))]
        public async Task<IActionResult> GetByBankName(string bankName)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = bankicConfig.GetByBankName;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await bankicAppService.GetByBankName(bankName, baseApi);

            return Ok(response);
        }
    }
}