using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class WebLinkGroupController : BaseController
    {
        private readonly IWebLinkGroupAppService webLinkGroupAppService;

        public WebLinkGroupController(ILogger<WebLinkGroupController> logger,
            IWebLinkGroupAppService webLinkGroupAppService)
            : base(logger)
        {
            this.webLinkGroupAppService = webLinkGroupAppService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<WebLinkGroup>>))]
        public async Task<IActionResult> GetAll(WebLinkGroupRequest request)
        {
            var response = await webLinkGroupAppService.GetAll(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<WebLink>>))]
        public async Task<IActionResult> GetWebLinkById(WebLinkByGroupIdRequest request)
        {
            var response = await webLinkGroupAppService.GetWebLinkByGroupId(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<WebLinkGroup>>))]
        public async Task<IActionResult> GetWebLinkGroup(WebLinkGroupRequest request)
        {
            var response = await webLinkGroupAppService.GetWebLinkGroup(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<WebLinkGroup>>))]
        public async Task<IActionResult> GetWebLinkGroupTop(WebLinkGroupTopRequest request)
        {
            var response = await webLinkGroupAppService.GetWebLinkGroupTop(request);

            return Ok(response);
        }
    }
}
