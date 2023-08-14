using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;
using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class PackageTrackingAppService : BaseAppService, IPackageTrackingAppService
    {
        private readonly HttpClient httpClient;

        public PackageTrackingAppService(ILogger<PackageTrackingAppService> logger,
            HttpClient httpClient)
            : base(logger)
        {
            this.httpClient = httpClient;
        }


        public async Task<BaseEntityResponse<IList<PackageTracking>>> GetsPackageTracking(string tracking, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<PackageTracking>>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url + "/" + tracking;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);
                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<PackageTracking>>>(stringResult);
                return response;
            }, response);

            return response;
        }
    }
}
