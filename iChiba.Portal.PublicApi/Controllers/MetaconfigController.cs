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
    public class MetaconfigController : BaseController
    {
        private readonly IMetaconfigAppService metaconfigAppService;

        public MetaconfigController(ILogger<MetaconfigController> logger,
            IMetaconfigAppService metaconfigAppService)
            : base(logger)
        {
            this.metaconfigAppService = metaconfigAppService;
        }


        [HttpGet("{languageId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<Metaconfig>>))]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var response = await metaconfigAppService.GetAll(languageId);

            return Ok(response);
        }
    }
}
