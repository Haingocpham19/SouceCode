using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class ServiceController : BaseController
    {
        private readonly IServiceAppService serviceAppService;

        public ServiceController(ILogger<ServiceController> logger,
            IServiceAppService serviceAppService)
            : base(logger)
        {
            this.serviceAppService = serviceAppService;
        }

        [HttpGet("{languageId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<AppModel.Model.Service>>))]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var response = await serviceAppService.GetAll(languageId);

            return Ok(response);
        }
    }
}
