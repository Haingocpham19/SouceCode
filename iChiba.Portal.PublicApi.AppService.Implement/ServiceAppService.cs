using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppService.Interface;
using System.Collections.Generic;
using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppService.Implement.Adapter;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class ServiceAppService : BaseAppService, IServiceAppService
    {
        private readonly IServiceService serviceService;

        public ServiceAppService(ILogger<ServiceAppService> logger,
            IServiceService serviceService
            )
            : base(logger)
        {
            this.serviceService = serviceService;
        }

        public async Task<BaseEntityResponse<IList<AppModel.Model.Service>>> GetAll(string languageId)
        {
            var response = new BaseEntityResponse<IList<AppModel.Model.Service>>();
            await TryCatchAsync(async () =>
            {
                var data = await serviceService.GetAll(languageId);
                if (data != null)
                {
                    var responseData = data.Select(m => m.ToModel()).OrderByDescending(m => m.CreatedDate).ToList();
                    response.SetData(responseData)
                        .Successful();
                }
               
                return response;
            }, response);

            return response;
        }
    }
}
