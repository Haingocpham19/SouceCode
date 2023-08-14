using System.Collections.Generic;
using System.Threading.Tasks;
using Core.AppModel.Response;
using iChiba.IS4.Api.Driver;
using iChiba.IS4.Api.Driver.Models.Response;
using iChiba.Portal.Common;
using iChiba.Portal.PrivateApi.AppService.Interface;
using Microsoft.Extensions.Logging;

namespace iChiba.Portal.PrivateApi.AppService.Implement
{
    public class AccessAppService : BaseAppService, IAccessAppService
    {
        private readonly AccessClient _accessClient;

        public AccessAppService(
            ILogger<AccessAppService> logger,
            AccessClient accessClient)
            : base(logger)
        {
            _accessClient = accessClient;
        }

        public async Task<BaseEntityResponse<IList<Resource>>> GetResources(string warehouseCode)
        {
            var response = new BaseEntityResponse<IList<Resource>>();

            await TryCatchAsync(async () =>
            {
                //var warehouse = _warehouseService.GetByCode(warehouseCode);
                //var data = await _accessClient.GetResources(string.Concat(ConfigSettingDefine.AppGroupResourceKey.GetConfig(), warehouse.Region));

                //response.SetData(data)
                //    .Successful();

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> CheckPermission(string resourceKey, string permission)
        {
            var response = new BaseResponse();

            await TryCatchAsync(async () =>
            {
                //var data = await _accessClient.CheckPermission(ConfigSettingDefine.AppGroupResourceKey.GetConfig(), resourceKey, permission);

                //if (data)
                //{
                //    response.Successful();
                //}

                return response;
            }, response);

            return response;
        }
    }
}
