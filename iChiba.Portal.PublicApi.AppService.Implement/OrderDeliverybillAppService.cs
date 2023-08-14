﻿using Core.AppModel.Response;
using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class OrderDeliverybillAppService : BaseAppService, IOrderDeliverybillAppService
    {
        private readonly HttpClient httpClient;

        public OrderDeliverybillAppService(ILogger<OrderDeliverybillAppService> logger,
            HttpClient httpClient)
            : base(logger)
        {
            this.httpClient = httpClient;
        }

        public async Task<PagingResponse<IList<OrderDeliverybillList>>> GetList(OrderDeliverybillListRequest request, BaseApiRequest baseApi)
        {
            var response = new PagingResponse<IList<OrderDeliverybillList>>();

            await TryCatchAsync(async () =>
            {
                var json = JsonConvert.SerializeObject(request);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

                var url = baseApi.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = stringContent
                };
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);
                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<PagingResponse<IList<OrderDeliverybillList>>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<OrderDeliverybillPayment>> TotalAmountTobePaidAllBillCode(OrderDeliverybillListRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<OrderDeliverybillPayment>();

            await TryCatchAsync(async () =>
            {
                var json = JsonConvert.SerializeObject(request);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

                var url = baseApi.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = stringContent
                };
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);
                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<OrderDeliverybillPayment>>(stringResult);

                return response;
            }, response);

            return response;
        }
    }
}
