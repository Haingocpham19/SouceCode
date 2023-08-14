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
    public class OrderDeliverybillConfig
    {
        public string GetList { get; set; }
        public string TotalAmountTobePaidAllBillCode { get; set; }
    }

    [Authorize]
    public class OrderDeliverybillController : BaseController
    {
        private readonly OrderDeliverybillConfig orderDeliverybillConfig;
        private readonly IOrderDeliverybillAppService orderDeliverybillAppService;

        public OrderDeliverybillController(ILogger<OrderDeliverybillController> logger,
            IOptions<OrderDeliverybillConfig> orderDeliverybillConfig,
            IOrderDeliverybillAppService orderDeliverybillAppService
            )
            : base(logger)
        {
            this.orderDeliverybillConfig = orderDeliverybillConfig.Value;
            this.orderDeliverybillAppService = orderDeliverybillAppService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PagingResponse<IList<OrderDeliverybillList>>))]
        public async Task<IActionResult> GetList(OrderDeliverybillListRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderDeliverybillConfig.GetList;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderDeliverybillAppService.GetList(request, baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<OrderDeliverybillPayment>))]
        public async Task<IActionResult> TotalAmountTobePaidAllBillCode(OrderDeliverybillListRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderDeliverybillConfig.TotalAmountTobePaidAllBillCode;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderDeliverybillAppService.TotalAmountTobePaidAllBillCode(request, baseApi);
            return Ok(response);
        }
    }
}