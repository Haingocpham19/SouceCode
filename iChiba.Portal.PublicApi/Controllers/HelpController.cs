using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class HelpController : BaseController
    {
        private readonly IHelpAppService _helpAppService;

        public HelpController(ILogger<GuidelinesController> logger,
            IHelpAppService helpAppService)
            : base(logger)
        {
            _helpAppService = helpAppService;
        }

        [HttpGet("{languageId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<GroupGuidelines>>))]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var response = await _helpAppService.GetAll(languageId);
            return Ok(response);
        }
    }
}
