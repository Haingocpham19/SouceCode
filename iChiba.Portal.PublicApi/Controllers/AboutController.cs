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
    public class AboutController : BaseController
    {
        private readonly IAboutAppService aboutAppService;

        public AboutController(ILogger<AboutController> logger,
            IAboutAppService aboutAppService)
            : base(logger)
        {
            this.aboutAppService = aboutAppService;
        }


        [HttpGet("{languageId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<About>>))]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var response = await aboutAppService.GetAll(languageId);

            return Ok(response);
        }
    }
}
