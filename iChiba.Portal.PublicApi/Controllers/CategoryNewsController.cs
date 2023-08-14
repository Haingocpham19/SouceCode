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
    public class CategoryNewsController : BaseController
    {
        private readonly ICategoryNewsAppService categoryNewsAppService;

        public CategoryNewsController(ILogger<CategoryNewsController> logger,
            ICategoryNewsAppService categoryNewsAppService)
            : base(logger)
        {
            this.categoryNewsAppService = categoryNewsAppService;
        }

        [HttpGet("{languageId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<CategoryNews>>))]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var response = await categoryNewsAppService.GetAll(languageId);

            return Ok(response);
        }
    }
}
