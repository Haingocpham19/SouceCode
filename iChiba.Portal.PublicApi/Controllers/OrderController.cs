using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppModel.Response;
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
    public class OrderConfig
    {
        public string GetList { get; set; }
        public string GetListAll { get; set; }
        public string GetListAllByQuoteCode { get; set; }
        public string GetListByQuoteCode { get; set; }
        public string GetListPaidNotQuoteCode { get; set; }
        public string GetById { get; set; }
        public string UpdateAddress { get; set; }
        public string RateOrder { get; set; }
        public string ConfirmDepositOrder { get; set; }
        public string UpdateOrderStatus { get; set; }
        public string GetByIds { get; set; }
        public string UpdatesAddress { get; set; }
        public string PayOrders { get; set; }
        public string PaymentOrders { get; set; }
        public string GetTotal { get; set; }
        public string CountOrderByStatus { get; set; }
        public string AddFromWebLink { get; set; }
        public string GetAllOrderFinalization { get; set; }
        public string UpdateDDImportType { get; set; }
        public string UpdateOrderServiceMapping { get; set; }
        public string GetByCodeAndPhoneOrEmail { get; set; }
        public string RateOrderByBillCode { get; set; }
        public string TotalPaymentListPaidNotQuoteCode { get; set; }
    }

    [Authorize]
    public class OrderController : BaseController
    {
        private readonly OrderConfig orderConfig;
        private readonly IOrderAppService orderAppService;

        public OrderController(ILogger<OrderController> logger,
            IOptions<OrderConfig> orderConfig,
            IOrderAppService orderAppService
            )
            : base(logger)
        {
            this.orderConfig = orderConfig.Value;
            this.orderAppService = orderAppService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PagingResponse<IList<Order>>))]
        public async Task<IActionResult> GetList(OrderListRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.GetList;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.GetList(request, baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<Order>>))]
        public async Task<IActionResult> GetListAll(OrderListRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.GetListAll;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.GetListAll(request, baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(OrderGetByQuoteCodeResponse))]
        public async Task<IActionResult> GetListAllByQuoteCode(OrderListRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.GetListAllByQuoteCode;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.GetListAllByQuoteCode(request, baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<OrderGetByQuoteCode>))]
        public async Task<IActionResult> GetListByQuoteCode(OrderListByBillCodeRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.GetListByQuoteCode;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.GetListByQuoteCode(request, baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PagingResponse<IList<Order>>))]
        public async Task<IActionResult> GetListPaidNotQuoteCode(OrderListRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.GetListPaidNotQuoteCode;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.GetListPaidNotQuoteCode(request, baseApi);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<Order>))]
        public async Task<IActionResult> GetById(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.GetById;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.GetById(id, baseApi);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> UpdateAddress(OrderAddressRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.UpdateAddress;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.UpdateAddress(request, baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> RateOrder(OrderRatingRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.RateOrder;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.RateOrder(request, baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Add(OrderAddRequest request)
        {
            var response = await orderAppService.Add(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> UpdateOrderStatus(OrderUpdateStatusRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.UpdateOrderStatus;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.UpdateOrderStatus(request, baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> ConfirmDelivery(OrderConfirmDeliveryRequest request)
        {
            var response = await orderAppService.ConfirmDelivery(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> ConfirmDeliveries(OrderConfirmDeliveriesRequest request)
        {
            var response = await orderAppService.ConfirmDeliveries(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> UpdatesAddress(OrderUpdateAddressRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.UpdatesAddress;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.UpdatesAddress(request, baseApi);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<Order>))]
        public async Task<IActionResult> GetByIds([FromQuery]int[] ids)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.GetByIds;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.GetByIds(ids, baseApi);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> PayOrders(OrderPaysRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.PayOrders;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.PayOrders(request, baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> PaymentOrders(OrderPaysRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.PaymentOrders;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.PaymentOrders(request, baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<int>))]
        public async Task<IActionResult> GetTotal(OrderTotalRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.GetTotal;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.GetTotal(request, baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IDictionary<int, int>>))]
        public async Task<IActionResult> CountOrderByStatus(OrderTotalRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.CountOrderByStatus;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.CountOrderByStatus(request, baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<int>))]
        public async Task<IActionResult> AddFromWebLink(OrderAddFromWebLinkRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.AddFromWebLink;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.AddFromWebLink(request, baseApi);
            return Ok(response);
        }

       

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<bool>))]
        public async Task<IActionResult> GetAllOrderFinalization()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.GetAllOrderFinalization;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.GetAllOrderFinalization(baseApi);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> AddOrderAndPayment(OrderAddRequest request)
        {
            var response = await orderAppService.AddOrderAndPayment(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<int>))]

        public async Task<IActionResult> UpdateDDImportType(OrderUpdateDDImportTypeRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.UpdateDDImportType;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.UpdateDDImportType(request, baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<int>))]
        public async Task<IActionResult> UpdateOrderServiceMapping(OrderServiceMappingUpdateRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.UpdateOrderServiceMapping;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.UpdateOrderServiceMapping(request, baseApi);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<Order>))]
        public async Task<IActionResult> GetByCodeAndPhoneOrEmail(OrderSearchRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.GetByCodeAndPhoneOrEmail;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.GetByCodeAndPhoneOrEmail(request, baseApi);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> RateOrderByBillCode(OrderRatingByBillCodeRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.RateOrderByBillCode;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.RateOrderByBillCode(request, baseApi);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<(long TotalPayment, long TotalPaid)>))]
        public async Task<IActionResult> TotalPaymentListPaidNotQuoteCode()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = orderConfig.TotalPaymentListPaidNotQuoteCode;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await orderAppService.TotalPaymentListPaidNotQuoteCode(baseApi);
            return Ok(response);
        }

        //[HttpPost]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType((int)HttpStatusCode.Forbidden)]
        //[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        //public async Task<IActionResult> PayNowFromWallet(PaymentNowFromWalletRequest request)
        //{
        //    var response = await orderAppService.PayNowFromWallet(request);

        //    return Ok(response);
        //}
    }
}