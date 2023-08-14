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
    public class GroupGuidelinesController : BaseController
    {
        private readonly IGroupGuidelinesAppService groupGuidelinesAppService;

        public GroupGuidelinesController(ILogger<GroupGuidelinesController> logger,
            IGroupGuidelinesAppService groupGuidelinesAppService)
            : base(logger)
        {
            this.groupGuidelinesAppService = groupGuidelinesAppService;
        }

        [HttpGet("{languageId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<GroupGuidelines>>))]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var response = await groupGuidelinesAppService.GetAll(languageId);

            return Ok(response);
        }
    }
}
