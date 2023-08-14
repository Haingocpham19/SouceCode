using iChiba.Portal.ExtensionApi.AppModel.Response;
using iChiba.Portal.ExtensionApi.AppService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.ExtensionApi.Controllers
{
    public class ExchangeratesController : BaseController
    {
        private readonly IExchangeratesService _exchangeratesService;
        public ExchangeratesController(
            ILogger<AccessController> logger,
            IExchangeratesService exchangeratesService
            ) : base(logger)
        {
            _exchangeratesService = exchangeratesService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ExchangratesResponsse))]
        public async Task<IActionResult> GetAllExchangerates()
        {
            try
            {
                var response = await _exchangeratesService.GetAllExchangrates();

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
