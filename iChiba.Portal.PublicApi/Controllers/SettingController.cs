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
    public class SettingController : BaseController
    {
        private readonly ISettingAppService settingAppService;

        public SettingController(ILogger<SettingController> logger,
            ISettingAppService settingAppService)
            : base(logger)
        {
            this.settingAppService = settingAppService;
        }

        [HttpPost("{languageId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<List<Settings>>))]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var response = await settingAppService.GetAll(languageId);

            return Ok(response);
        }
    }
}
