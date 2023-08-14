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
    public class CustomerBankinfoConfig
    {
        public string GetList { get; set; }
        public string Add { get; set; }
        public string Update { get; set; }
        public string GetById { get; set; }
        public string Delete { get; set; }
    }

    [Authorize]
    public class CustomerBankinfoController : BaseController
    {
        private readonly IOptions<CustomerBankinfoConfig> customerBankinfoConfig;
        private readonly ICustomerBankinfoAppService customerBankinfoAppService;

        public CustomerBankinfoController(ILogger<CustomerBankinfoController> logger,
            IOptions<CustomerBankinfoConfig> customerBankinfoConfig,
            ICustomerBankinfoAppService customerBankinfoAppService
            )
            : base(logger)
        {
            this.customerBankinfoConfig = customerBankinfoConfig;
            this.customerBankinfoAppService = customerBankinfoAppService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<CustomerBankinfo>>))]
        public async Task<IActionResult> GetList()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerBankinfoConfig.Value.GetList;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await customerBankinfoAppService.GetList(baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Add(CustomerBankinfoAddRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerBankinfoConfig.Value.Add;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await customerBankinfoAppService.Add(request, baseApi);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Update(CustomerBankinfoUpdateRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerBankinfoConfig.Value.Update;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await customerBankinfoAppService.Update(request, baseApi);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<CustomerBankinfo>))]
        public async Task<IActionResult> GetById(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerBankinfoConfig.Value.GetById;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await customerBankinfoAppService.GetById(id, baseApi);
            return Ok(response);
        }

        [HttpPost("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Delete(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerBankinfoConfig.Value.Delete;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await customerBankinfoAppService.Delete(id, baseApi);
            return Ok(response);
        }
    }
}