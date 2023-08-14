using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class DdimportConfig
    {
        public string GetList { get; set; }
        public string GetById { get; set; }
    }

    [Authorize]
    public class DdimportController : BaseController
    {
        private readonly DdimportConfig ddimportConfig;
        private readonly IDdimportAppService ddimportAppService;

        public DdimportController(ILogger<DdimportController> logger,
            IOptions<DdimportConfig> ddimportConfig,
            IDdimportAppService ddimportAppService
            )
            : base(logger)
        {
            this.ddimportConfig = ddimportConfig.Value;
            this.ddimportAppService = ddimportAppService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<Ddimport>>))]
        public async Task<IActionResult> GetList()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = ddimportConfig.GetList;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await ddimportAppService.GetList(baseApi);
            return Ok(response);
        }


        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<Ddimport>))]
        public async Task<IActionResult> GetById(string id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = ddimportConfig.GetById;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await ddimportAppService.GetById(id, baseApi);

            return Ok(response);
        }
    }
}