using iChiba.Portal.PrivateApi.AppModel.Requests;
using iChiba.Portal.PrivateApi.AppModel.Responses;
using iChiba.Portal.PrivateApi.AppService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IPaymentAppService _paymentAppService;

        public PaymentController(
            ILogger<PaymentController> logger,
            IPaymentAppService paymentAppService) : base(logger)
        {
            _paymentAppService = paymentAppService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PaymentTransactionHistoryListResponse))]
        public async Task<IActionResult> GetPaymentTransactionHistory(PaymentTransactionHistoryRequest request)
        {
            try
            {
                var response = await _paymentAppService.GetPaymentTransactionHistory(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                return BadRequest();
            }
        }
    }
}
