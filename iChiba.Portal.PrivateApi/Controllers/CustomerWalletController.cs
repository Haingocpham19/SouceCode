using iChiba.Portal.PrivateApi.AppModel.Requests;
using iChiba.Portal.PrivateApi.AppModel.Responses;
using iChiba.Portal.PrivateApi.AppService.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.Controllers
{
    public class CustomerWalletController : BaseController
    {
        private readonly ICustomerWalletAppService _customerWalletAppService;

        public CustomerWalletController(
            ILogger<CustomerWalletController> logger,
            ICustomerWalletAppService customerWalletAppService) : base(logger)
        {
            _customerWalletAppService = customerWalletAppService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CustomerWalletResponse))]
        public async Task<IActionResult> GetCustomerWalletInfo()
        {
            try
            {
                var response = await _customerWalletAppService.GetCustomerWalletInfo();

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DepositsHistoryResponse))]
        public async Task<IActionResult> GetListDepositsTransaction(WalletTransactionRequest request)
        {
            try
            {
                var response = await _customerWalletAppService.GetListDepositsTransaction(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(FreezeHistoryResponse))]
        public async Task<IActionResult> GetListFreezeTransaction(WalletTransactionRequest request)
        {
            try
            {
                var response = await _customerWalletAppService.GetListFreezeTransaction(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(WithdrawalHistoryResponse))]
        public async Task<IActionResult> GetListWithdrawalTransaction(WalletTransactionRequest request)
        {
            try
            {
                var response = await _customerWalletAppService.GetListWithdrawalTransaction(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(WalletTransactionResponse))]
        public async Task<IActionResult> GetWalletTransactionHistory(WalletTransactionRequest request)
        {
            try
            {
                var response = await _customerWalletAppService.GetWalletTransactionHistory(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DebtResponse))]
        public async Task<IActionResult> GetDebtInfo()
        {
            try
            {
                var response = await _customerWalletAppService.GetDebtInfo();

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
