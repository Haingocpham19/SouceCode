using Core.AppModel.Response;
using iChiba.Portal.CS.PublicApi.Driver;
using iChibaShopping.Core.AppService.Implement;
using iChiba.Portal.CustomException;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppModel.Response;
using iChiba.Portal.PublicApi.AppService.Implement.Adapter;
using iChiba.Portal.PublicApi.AppService.Interface;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class OrderAppService : BaseAppService, IOrderAppService
    {
        private readonly HttpClient httpClient;
        private readonly OrderClient orderClient;

        public OrderAppService(ILogger<OrderAppService> logger,
            OrderClient orderClient,
            HttpClient httpClient)
            : base(logger)
        {
            this.httpClient = httpClient;
            this.orderClient = orderClient;
        }

        public async Task<PagingResponse<IList<Order>>> GetList(OrderListRequest request, BaseApiRequest baseApi)
        {
            var response = new PagingResponse<IList<Order>>();

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
                response = JsonConvert.DeserializeObject<PagingResponse<IList<Order>>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<IList<Order>>> GetListAll(OrderListRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<Order>>();

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
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<Order>>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<OrderGetByQuoteCodeResponse> GetListAllByQuoteCode(OrderListRequest request, BaseApiRequest baseApi)
        {
            var response = new OrderGetByQuoteCodeResponse();

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
                response = JsonConvert.DeserializeObject<OrderGetByQuoteCodeResponse>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<OrderGetByQuoteCode>> GetListByQuoteCode(OrderListByBillCodeRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<OrderGetByQuoteCode>();

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
                response = JsonConvert.DeserializeObject<BaseEntityResponse<OrderGetByQuoteCode>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<PagingResponse<IList<Order>>> GetListPaidNotQuoteCode(OrderListRequest request, BaseApiRequest baseApi)
        {
            var response = new PagingResponse<IList<Order>>();

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
                response = JsonConvert.DeserializeObject<PagingResponse<IList<Order>>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<Order>> GetById(int id, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<Order>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url + "/" + id;

                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();

                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<Order>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> UpdateAddress(OrderAddressRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseResponse();

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
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> RateOrder(OrderRatingRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseResponse();

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
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<IList<int>>> Add(OrderAddRequest request)
        {
            var response = new BaseEntityResponse<IList<int>>();

            response = await TryCatchAsync(async () =>
            {
                var driverRequest = request.ToModel();
                response = await orderClient.Add(driverRequest);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> UpdateOrderStatus(OrderUpdateStatusRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseResponse();

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
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> ConfirmDelivery(OrderConfirmDeliveryRequest request)
        {
            var response = new BaseResponse();

            await TryCatchAsync(async () =>
            {
                var cdRequest = new iChiba.Portal.CS.PublicApi.Driver.Request.OrderConfirmDeliveryRequest()
                {
                    OrderId = request.OrderId
                };
                var cdResponse = await orderClient.ConfirmDelivery(cdRequest);

                if (cdResponse.Status)
                {
                    response.Successful();
                }
                else
                {
                    response.Fail(cdResponse.ErrorCode, cdResponse.Parameters);
                }

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> ConfirmDeliveries(OrderConfirmDeliveriesRequest request)
        {
            var response = new BaseResponse();

            await TryCatchAsync(async () =>
            {
                var cdRequest = new iChiba.Portal.CS.PublicApi.Driver.Request.OrderConfirmDeliveriesRequest()
                {
                    OrderIds = request.OrderIds
                };
                var cdResponse = await orderClient.ConfirmDeliveries(cdRequest);

                if (cdResponse.Status)
                {
                    response.Successful();
                }
                else
                {
                    response.Fail(cdResponse.ErrorCode, cdResponse.Parameters);
                }

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> UpdatesAddress(OrderUpdateAddressRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseResponse();

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
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<IList<Order>>> GetByIds(int[] ids, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<Order>>();

            await TryCatchAsync(async () =>
            {
                var queryString = string.Join('&', ids.Select(m => $"ids={m}").ToArray());
                var url = baseApi.Url + "?" + queryString;

                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();

                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<Order>>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> PayOrders(OrderPaysRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseResponse();

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
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> PaymentOrders(OrderPaysRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseResponse();

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
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<int>> GetTotal(OrderTotalRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<int>();

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
                response = JsonConvert.DeserializeObject<BaseEntityResponse<int>>(stringResult);
                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<IDictionary<int, int>>> CountOrderByStatus(OrderTotalRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IDictionary<int, int>>();

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
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IDictionary<int, int>>>(stringResult);
                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<IList<int>>> AddFromWebLink(OrderAddFromWebLinkRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<int>>();

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
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<int>>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<bool>> GetAllOrderFinalization(BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<bool>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<bool>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<IList<int>>> AddOrderAndPayment(OrderAddRequest request)
        {
            var response = new BaseEntityResponse<IList<int>>();

            response = await TryCatchAsync(async () =>
            {
                var driverRequest = request.ToModel();
                response = await orderClient.AddOrderAndPayment(driverRequest);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> UpdateDDImportType(OrderUpdateDDImportTypeRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseResponse();

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
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> UpdateOrderServiceMapping(OrderServiceMappingUpdateRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseResponse();

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
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<Order>> GetByCodeAndPhoneOrEmail(OrderSearchRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<Order>();

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
                response = JsonConvert.DeserializeObject<BaseEntityResponse<Order>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> RateOrderByBillCode(OrderRatingByBillCodeRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseResponse();

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
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<(long TotalPayment, long TotalPaid)>> TotalPaymentListPaidNotQuoteCode(BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<(long TotalPayment, long TotalPaid)>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<(long TotalPayment, long TotalPaid)>>(stringResult);

                return response;
            }, response);

            return response;
        }

        //public async Task<BaseResponse> PayNowFromWallet(PaymentNowFromWalletRequest request)
        //{
        //    var response = new BaseResponse();

        //    await TryCatchAsync(async () =>
        //    {
        //        var cdRequest = new iChiba.Portal.CS.PublicApi.Driver.Request.PaymentNowFromWalletRequest()
        //        {
        //            OrderIds = request.OrderIds
        //        };
        //        var cdResponse = await orderClient.PayNowFromWallet(cdRequest);

        //        if (cdResponse.Status)
        //        {
        //            response.Successful();
        //        }
        //        else
        //        {
        //            response.Fail(cdResponse.ErrorCode, cdResponse.Parameters);
        //        }

        //        return response;
        //    }, response);

        //    return response;
        //}
    }
}