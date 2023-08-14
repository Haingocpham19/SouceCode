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
    public class PolicyController : BaseController
    {
        private readonly IPolicyAppService policyAppService;

        public PolicyController(ILogger<PolicyController> logger,
            IPolicyAppService policyAppService)
            : base(logger)
        {
            this.policyAppService = policyAppService;
        }

        [HttpGet("{languageId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<Policy>>))]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var response = await policyAppService.GetAll(languageId);

            return Ok(response);
        }
    }
}
