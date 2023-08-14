using Core.AppModel.Response;
using iChiba.IS4.Api.Driver;
using iChiba.IS4.Api.Driver.Models.Response;
using iChiba.Portal.ExtensionApi.AppService.Implement.Configs;
using iChiba.Portal.ExtensionApi.AppService.Interface;

using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.ExtensionApi.AppService.Implement
{
    public class AccessAppService : BaseAppService, IAccessAppService
    {
        private readonly AppConfig appConfig;
        private readonly AccessClient accessClient;

        public AccessAppService(ILogger<AccessAppService> logger,
            AppConfig appConfig,
            AccessClient accessClient)
           : base(logger)
        {
            this.appConfig = appConfig;
            this.accessClient = accessClient;
        }
        
        public async Task<BaseEntityResponse<IList<Resource>>> GetResources()
        {
            var response = new BaseEntityResponse<IList<Resource>>();

            await TryCatchAsync(async () =>
            {
                var data = await accessClient.GetResources(appConfig.AppGroupResourceKey);

                response.SetData(data)
                    .Successful();

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> CheckPermission(string resourceKey, string permission)
        {
            var response = new BaseResponse();

            await TryCatchAsync(async () =>
            {
                var data = await accessClient.CheckPermission(appConfig.AppGroupResourceKey, resourceKey, permission);

                if (data) {
                    response.Successful();
                }
                
                return response;
            }, response);

            return response;
        }
    }
}
