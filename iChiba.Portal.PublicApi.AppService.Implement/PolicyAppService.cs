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
    public class PolicyAppService : BaseAppService, IPolicyAppService
    {
        private readonly IPolicyService policyService;

        public PolicyAppService(ILogger<PolicyAppService> logger,
            IPolicyService policyService
            )
            : base(logger)
        {
            this.policyService = policyService;
        }


        public async Task<BaseEntityResponse<IList<Policy>>> GetAll(string languageId)
        {
            var response = new BaseEntityResponse<IList<Policy>>();
            await TryCatchAsync(async () =>
            {
                var data = await policyService.GetAll(languageId);
                if (data != null)
                {
                    var responseData = data.Select(m => m.ToModel()).OrderBy(m => m.Order).ToList();
                    response.SetData(responseData)
                        .Successful();
                }
               
                return response;
            }, response);

            return response;
        }

    }
}
