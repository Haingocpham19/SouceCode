using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IContactAppService contactAppService;

        public ContactController(ILogger<ContactController> logger,
            IContactAppService contactAppService)
            : base(logger)
        {
            this.contactAppService = contactAppService;
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Add(Contact model)
        {
            var response = await contactAppService.Add(model);

            return Ok(response);
        }
    }
}
