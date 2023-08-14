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
    public class OrderServiceConfig
    {
        public string GetListAll { get; set; }
        public string GetServiceActiveByOrderIds { get; set; }
        public string GetById { get; set; }
    }

    [Authorize]
    public class OrderServiceController : BaseController
    {
        private readonly OrderServiceConfig orderServiceConfig;
        private readonly IOrderServiceAppService orderServiceAppService;

        public OrderServiceController(ILogger<OrderServiceController> logger,
            IOptions<OrderServiceConfig> orderServiceConfig,
            IOrderServiceAppService orderServiceAppService
            )
            : base(logger)
        {
            this.orderServiceConfig = orderServiceConfig.Value;
            this.orderServiceAppService = orderServiceAppService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<OrderService>>))]
        public async Task<IActionResult> GetListAll()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderServiceConfig.GetListAll;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderServiceAppService.GetListAll(baseApi);
            return Ok(response);
        }


        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<OrderService>))]
        public async Task<IActionResult> GetById(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderServiceConfig.GetById;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderServiceAppService.GetById(id, baseApi);

            return Ok(response);
        }


        [HttpGet("{orderIds}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<Dictionary<int, List<OrderService>>>))]
        public async Task<IActionResult> GetServiceActiveByOrderIds(string orderIds)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderServiceConfig.GetServiceActiveByOrderIds;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderServiceAppService.GetServiceActiveByOrderIds(orderIds, baseApi);
            return Ok(response);
        }
    }
}