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
    public class RecruitmentController : BaseController
    {
        private readonly IRecruitmentAppService recruitmentAppService;

        public RecruitmentController(ILogger<RecruitmentController> logger,
            IRecruitmentAppService RecruitmentAppService)
            : base(logger)
        {
            this.recruitmentAppService = RecruitmentAppService;
        }

        [HttpPost("{languageId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<Recruitment>>))]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var response = await recruitmentAppService.GetAll(languageId);

            return Ok(response);
        }
    }
}
