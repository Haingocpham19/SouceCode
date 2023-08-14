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
    public class LocationController : BaseController
    {
        private readonly ILocationAppService locationsAppService;

        public LocationController(ILogger<LocationController> logger,
            ILocationAppService LocationsAppService)
            : base(logger)
        {
            this.locationsAppService = LocationsAppService;
        }

        [HttpPost("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<Location>>))]
        public async Task<IActionResult> GetLocationsChild(int id)
        {
            var response = await locationsAppService.GetLocationsChild(id);

            return Ok(response);
        }
    }
}
