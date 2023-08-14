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
    public class CategoryServiceController : BaseController
    {
        private readonly ICategoryServiceAppService categoryServiceAppService;

        public CategoryServiceController(ILogger<CategoryServiceController> logger,
            ICategoryServiceAppService categoryServiceAppService)
            : base(logger)
        {
            this.categoryServiceAppService = categoryServiceAppService;
        }

        [HttpGet("{languageId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<CategoryService>>))]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var response = await categoryServiceAppService.GetAll(languageId);

            return Ok(response);
        }
    }
}
