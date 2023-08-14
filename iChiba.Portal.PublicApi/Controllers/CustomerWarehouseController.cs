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
    public class CustomerWarehouseConfig
    {
        public string GetWarehousesByCustomer { get; set; }
        public string Add { get; set; }
        public string Delete { get; set; }
    }

    [Authorize]
    public class CustomerWarehouseController : BaseController
    {
        private readonly IOptions<CustomerWarehouseConfig> customerWarehouseConfig;
        private readonly ICustomerWarehouseAppService customerWarehouseAppService;

        public CustomerWarehouseController(ILogger<CustomerWarehouseController> logger,
             IOptions<CustomerWarehouseConfig> customerWarehouseConfig,
            ICustomerWarehouseAppService customerWarehouseAppService)
            : base(logger)
        {
            this.customerWarehouseConfig = customerWarehouseConfig;
            this.customerWarehouseAppService = customerWarehouseAppService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<CustomerWarehouse>>))]
        public async Task<IActionResult> GetWarehousesByCustomer()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerWarehouseConfig.Value.GetWarehousesByCustomer;
            var request = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await customerWarehouseAppService.GetWarehousesByCustomer(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Add(CustomerWarehouseAddRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerWarehouseConfig.Value.Add;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await customerWarehouseAppService.Add(request, baseApi);

            return Ok(response);
        }

        [HttpPost("{warehouseId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Delete(int warehouseId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerWarehouseConfig.Value.Delete;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await customerWarehouseAppService.Delete(warehouseId, baseApi);
            return Ok(response);
        }
    }
}
