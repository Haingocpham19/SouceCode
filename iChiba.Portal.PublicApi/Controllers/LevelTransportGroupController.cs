using System.Collections.Generic;
using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class LevelTransportGroupConfig
    {
        public string GetByLevel { get; set; }
        public string ProductTypeByGroup { get; set; }
        public string ProductTypeGroup { get; set; }
    }

    [Authorize]
    public class LevelTransportGroupController : BaseController
    {
        private readonly IOptions<LevelTransportGroupConfig> levelTransportGroupConfig;
        private readonly ILevelTransportGroupAppService levelTransportGroupAppService;

        public LevelTransportGroupController(ILogger<LevelTransportGroupController> logger,
             IOptions<LevelTransportGroupConfig> levelTransportGroupConfig,
             ILevelTransportGroupAppService levelTransportGroupAppService)
            : base(logger)
        {
            this.levelTransportGroupConfig = levelTransportGroupConfig;
            this.levelTransportGroupAppService = levelTransportGroupAppService;
        }

        [HttpGet("{levelId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<LevelTransportGroup>>))]
        public async Task<IActionResult> GetByLevel(int levelId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = levelTransportGroupConfig.Value.GetByLevel;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await levelTransportGroupAppService.GetByLevel(levelId, baseApi);

            return Ok(response);
        }

        [HttpGet("{groupId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<ProductTypeList>>))]
        public async Task<IActionResult> ProductTypeByGroup(int groupId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = levelTransportGroupConfig.Value.ProductTypeByGroup;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await levelTransportGroupAppService.ProductTypeByGroup(groupId, baseApi);

            return Ok(response);
        }


        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<ProductTypeGroup>>))]
        public async Task<IActionResult> ProductTypeGroup()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = levelTransportGroupConfig.Value.ProductTypeGroup;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await levelTransportGroupAppService.ProductTypeGroup(baseApi);


            return Ok(response);
        }
    }
}
