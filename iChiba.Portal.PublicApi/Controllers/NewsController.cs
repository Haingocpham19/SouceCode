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
    public class NewsController : BaseController
    {
        private readonly INewsAppService newsAppService;

        public NewsController(ILogger<NewsController> logger,
            INewsAppService newsAppService)
            : base(logger)
        {
            this.newsAppService = newsAppService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PagingResponse<IList<News>>))]
        public async Task<IActionResult> GetList(NewsListRequest request)
        {
            var response = await newsAppService.GetList(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<News>>))]
        public async Task<IActionResult> GetTopNewsLastest(NewsTopRequest request)
        {
            var response = await newsAppService.GetTopNewsLastest(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<News>>))]
        public async Task<IActionResult> GetTopNewsHighlight(NewsTopRequest request)
        {
            var response = await newsAppService.GetTopNewsHighlight(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<News>))]
        public async Task<IActionResult> GetDetail(NewsDetailRequest request)
        {
            var response = await newsAppService.GetDetailByMetaTitle(request);

            return Ok(response);
        }

        [HttpPost("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<News>))]
        public async Task<IActionResult> GetDetailById(string id)
        {
            var response = await newsAppService.GetDetail(id);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PagingResponse<IList<News>>))]
        public async Task<IActionResult> GetListByTag(NewsListByTagRequest request)
        {
            var response = await newsAppService.GetListByTag(request);

            return Ok(response);
        }
    }
}
