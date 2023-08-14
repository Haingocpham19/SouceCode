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
    public class TagsController : BaseController
    {
        private readonly ITagsAppService tagsAppService;

        public TagsController(ILogger<TagsController> logger,
            ITagsAppService tagsAppService)
            : base(logger)
        {
            this.tagsAppService = tagsAppService;
        }

        [HttpGet("{languageId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<Tags>>))]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var response = await tagsAppService.GetAll(languageId);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<Tags>>))]
        public async Task<IActionResult> GetByIds(TagsByIdRequest request)
        {
            var response = await tagsAppService.GetByIds(request);

            return Ok(response);
        }
    }
}
