using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppService.Interface;
using iChiba.Portal.PublicApi.AppService.Implement.Adapter;
using Core.AppModel.Response;
using System.Collections.Generic;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class RecruitmentAppService : BaseAppService, IRecruitmentAppService
    {
        private readonly IRecruitmentService recruitmentService;

        public RecruitmentAppService(ILogger<RecruitmentAppService> logger,
            IRecruitmentService recruitmentService
            )
            : base(logger)
        {
            this.recruitmentService = recruitmentService;
        }

        public async Task<BaseEntityResponse<IList<Recruitment>>> GetAll(string languageId)
        {
            var response = new BaseEntityResponse<IList<Recruitment>>();
            await TryCatchAsync(async () =>
            {
                var data = await recruitmentService.GetAll(languageId);
                if (data != null)
                {
                    var responseData = data.Select(m => m.ToModel()).ToList();
                    response.SetData(responseData)
                        .Successful();
                }
                return response;
            }, response);

            return response;
        }

    }
}
