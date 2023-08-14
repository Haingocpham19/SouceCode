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
    public class CategoryAboutController : BaseController
    {
        private readonly ICategoryAboutAppService categoryAboutAppService;

        public CategoryAboutController(ILogger<CategoryAboutController> logger,
            ICategoryAboutAppService categoryAboutAppService)
            : base(logger)
        {
            this.categoryAboutAppService = categoryAboutAppService;
        }

        [HttpGet("{languageId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<CategoryAbout>>))]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var response = await categoryAboutAppService.GetAll(languageId);

            return Ok(response);
        }
    }
}
