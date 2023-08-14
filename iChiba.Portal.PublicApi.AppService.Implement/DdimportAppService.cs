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
    public class DdimportAppService : BaseAppService, IDdimportAppService
    {
        private readonly HttpClient httpClient;

        public DdimportAppService(ILogger<DdimportAppService> logger,
            HttpClient httpClient)
            : base(logger)
        {
            this.httpClient = httpClient;
        }

        public async Task<BaseEntityResponse<IList<Ddimport>>> GetList(BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<Ddimport>>();

            await TryCatchAsync(async () =>
            {

                var url = baseApi.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);
                res.EnsureSuccessStatusCode();

                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<Ddimport>>>(stringResult);

                return response;
            }, response);

            return response;
        }


        public async Task<BaseEntityResponse<Ddimport>> GetById(string id, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<Ddimport>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url + "/" + id;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);
                res.EnsureSuccessStatusCode();

                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<Ddimport>>(stringResult);

                return response;
            }, response);

            return response;
        }
    }
}
