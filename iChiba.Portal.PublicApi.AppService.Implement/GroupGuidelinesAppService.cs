using iChibaShopping.Core.AppService.Implement;
using iChiba.Portal.PublicApi.AppService.Implement.Adapter;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppService.Interface;
using Core.AppModel.Response;
using System.Collections.Generic;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class GroupGuidelinesAppService : BaseAppService, IGroupGuidelinesAppService
    {
        private readonly IGroupGuidelinesService groupGuidelinesService;

        public GroupGuidelinesAppService(ILogger<GroupGuidelinesAppService> logger,
            IGroupGuidelinesService groupGuidelinesService
            )
            : base(logger)
        {
            this.groupGuidelinesService = groupGuidelinesService;
        }


        public async Task<BaseEntityResponse<IList<GroupGuidelines>>> GetAll(string languageId)
        {
            var response = new BaseEntityResponse<IList<GroupGuidelines>>();
            await TryCatchAsync(async () =>
            {
                var data = await groupGuidelinesService.GetAll(languageId);
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
