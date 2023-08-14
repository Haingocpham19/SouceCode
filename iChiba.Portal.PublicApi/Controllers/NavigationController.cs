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
    public class NavigationController : BaseController
    {
        private readonly INavigationAppService navigationAppService;

        public NavigationController(ILogger<NavigationController> logger,
            INavigationAppService navigationAppService)
            : base(logger)
        {
            this.navigationAppService = navigationAppService;
        }

        [HttpGet("{languageId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<Navigation>>))]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var response = await navigationAppService.GetAll(languageId);

            return Ok(response);
        }
    }
}
