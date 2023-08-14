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
    public class GuidelinesController : BaseController
    {
        private readonly IGuidelinesAppService guidelinesAppService;

        public GuidelinesController(ILogger<GuidelinesController> logger,
            IGuidelinesAppService guidelinesAppService)
            : base(logger)
        {
            this.guidelinesAppService = guidelinesAppService;
        }

        [HttpGet("{languageId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<Guidelines>>))]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var response = await guidelinesAppService.GetAll(languageId);

            return Ok(response);
        }
    }
}
