using iChiba.Portal.PublicApi.AppService.Implement.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class ExchangeController : BaseController
    {
        private readonly ExchangeRate exchangeRate;

        public ExchangeController(ILogger<ExchangeController> logger, ExchangeRate exchangeRate)
            : base(logger)
        {
            this.exchangeRate = exchangeRate;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetJPRate()
        {
            decimal jpyRate = await exchangeRate.GetJPRate();
            return Ok(jpyRate);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUSDRate()
        {
            decimal usdRate = await exchangeRate.GetUSDRate();
            return Ok(usdRate);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetRate(string code)
        {
            decimal rate = await exchangeRate.GetRate(code);
            return Ok(rate);
        }
    }
}