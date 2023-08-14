using Core.AppModel.Response;
using Core.Resilience.Http;
using iChiba.Portal.CS.PublicApi.Driver.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.CS.PublicApi.Driver
{
    public class OrderConfig
    {
        public string Add { get; set; }
        public string GetIdByProductId { get; set; }
        public string ConfirmDelivery { get; set; }
        public string ConfirmDeliveries { get; set; }
        public string CountOrderWaitForTempDeposit { get; set; }
        public string AddOrderAndPayment { get; set; }
    }

    public class OrderClient : BaseClient
    {
        private readonly OrderConfig orderConfig;

        public OrderClient(IHttpClient httpClient,
            IAuthorizeClient authorizeClient,
            OrderConfig orderConfig)
            : base(httpClient, authorizeClient)
        {
            this.orderConfig = orderConfig;
        }

        public async Task<BaseEntityResponse<IList<int>>> Add(OrderAddRequest request)
        {
            var url = orderConfig.Add;
            var response = await PostAsync<BaseEntityResponse<IList<int>>, OrderAddRequest>(url, request);

            return response;
        }

        public async Task<BaseEntityResponse<int?>> GetIdByProductId(OrderGetIdByProductIdRequest request)
        {
            var url = orderConfig.GetIdByProductId;
            var response = await PostAsync<BaseEntityResponse<int?>, OrderGetIdByProductIdRequest>(url, request);

            return response;
        }

        public async Task<BaseResponse> ConfirmDelivery(OrderConfirmDeliveryRequest request)
        {
            var url = orderConfig.ConfirmDelivery;
            var response = await PostAsync<BaseResponse, OrderConfirmDeliveryRequest>(url, request);

            return response;
        }

        public async Task<BaseResponse> ConfirmDeliveries(OrderConfirmDeliveriesRequest request)
        {
            var url = orderConfig.ConfirmDeliveries;
            var response = await PostAsync<BaseResponse, OrderConfirmDeliveriesRequest>(url, request);

            return response;
        }

        public async Task<BaseEntityResponse<int>> CountOrderWaitForTempDeposit()
        {
            var url = orderConfig.CountOrderWaitForTempDeposit;
            var response = await PostAsync<BaseEntityResponse<int>, object>(url, null);

            return response;
        }

        public async Task<BaseEntityResponse<IList<int>>> AddOrderAndPayment(OrderAddRequest request)
        {
            var url = orderConfig.AddOrderAndPayment;
            var response = await PostAsync<BaseEntityResponse<IList<int>>, OrderAddRequest>(url, request);

            return response;
        }
    }
}
