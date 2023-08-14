using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class ExchangeratesController : BaseController
    {
        private readonly IExchangeratesAppService exchangeratesAppService;

        public ExchangeratesController(ILogger<ExchangeratesController> logger,
            IExchangeratesAppService exchangeratesAppService)
            : base(logger)
        {
            this.exchangeratesAppService = exchangeratesAppService;
        }


        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<Exchangerates>>))]
        public async Task<IActionResult> GetAll()
        {
            var response = await exchangeratesAppService.GetAll();

            return Ok(response);
        }
    }
}
