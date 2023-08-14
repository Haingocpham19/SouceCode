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
    public class PaymentConfig
    {
        public string PayOrder { get; set; }
        public string CancelOrder { get; set; }
        public string DepositOrder { get; set; }
        public string GetListByRef { get; set; }
        public string GetListByAccount { get; set; }
        public string GetListByPaymentType { get; set; }
    }

    [Authorize]
    public class PaymentController : BaseController
    {
        private readonly PaymentConfig paymentConfig;
        private readonly IPaymentAppService paymentAppService;

        public PaymentController(ILogger<PaymentController> logger,
            IOptions<PaymentConfig> PaymentConfig,
            IPaymentAppService paymentAppService
            )
            : base(logger)
        {
            this.paymentConfig = PaymentConfig.Value;
            this.paymentAppService = paymentAppService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> PayOrder(PaymentPayOrderRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = paymentConfig.PayOrder;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await paymentAppService.PayOrder(request, baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> CancelOrder(PaymentCancelOrderRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = paymentConfig.CancelOrder;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await paymentAppService.CancelOrder(request, baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PagingResponse<IList<Payment>>))]
        public async Task<IActionResult> GetListByRef(PaymentListByRefRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = paymentConfig.GetListByRef;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await paymentAppService.GetListByRef(request, baseApi);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PagingResponse<IList<Payment>>))]
        public async Task<IActionResult> GetListByAccount(PaymentListByAccountRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = paymentConfig.GetListByAccount;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await paymentAppService.GetListByAccount(request, baseApi);
            return Ok(response);
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PagingResponse<IList<Payment>>))]
        public async Task<IActionResult> GetListByPaymentType(PaymentListByPaymentTypeRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = paymentConfig.GetListByPaymentType;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await paymentAppService.GetListByPaymentType(request, baseApi);
            return Ok(response);
        }
    }
}