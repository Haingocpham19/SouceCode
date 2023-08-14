using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class AdvisoryController : BaseController
    {
        private readonly IAdvisoryAppService advisoryAppService;

        public AdvisoryController(ILogger<AdvisoryController> logger,
            IAdvisoryAppService advisoryAppService)
            : base(logger)
        {
            this.advisoryAppService = advisoryAppService;
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Add(Advisory model)
        {
            var response = await advisoryAppService.Add(model);

            return Ok(response);
        }
    }
}
