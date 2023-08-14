using iChiba.OM.Service.Interface;
using iChiba.Portal.Common;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.Portal.PrivateApi.AppModel.Requests;
using iChiba.Portal.PrivateApi.AppModel.Responses;
using iChiba.Portal.PrivateApi.AppService.Implement.Adapter;
using iChiba.Portal.PrivateApi.AppService.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.AppService.Implement
{
    public class PaymentAppService : BaseAppService, IPaymentAppService
    {
        private readonly ICurrentContext _currentContext;
        private readonly IPaymentService _paymentService;

        public PaymentAppService(
            ILogger<PaymentAppService> logger,
            ICurrentContext currentContext,
            IPaymentService paymentService
        ) : base(logger)
        {
            _currentContext = currentContext;
            _paymentService = paymentService;
        }

        public Task<PaymentTransactionHistoryListResponse> GetPaymentTransactionHistory(PaymentTransactionHistoryRequest request)
        {
            var response = new PaymentTransactionHistoryListResponse();

            TryCatch(() =>
            {
                var sorts = request.Sorts;
                var paging = request.ToPaging();

                var payments = _paymentService.GetListPayment(
                    _currentContext.UserId, request.FromDate, request.ToDate,
                    request.IsRefund, request.Status, sorts, paging
                ).ToList();
                if (payments == null || payments.Count <= 0)
                {
                    response.SetData(new List<PaymentTransactionHistoryViewModel>()).Successful();
                }
                else
                {
                    var paymentViewModels = payments.Select(x =>
                    {
                        var item = x.ToModel();
                        if (!string.IsNullOrEmpty(item.RefCode))
                        {
                            var preCode = item.RefCode.Substring(0, 3);
                            if (StartWithCode.TRANSPORT.Contains(preCode)) item.OrderType = OrderCsType.TRANSPORT;
                            else if (StartWithCode.AUCTION.Contains(preCode)) item.OrderType = OrderCsType.AUCTION;
                            else if (StartWithCode.ECOMMERCE.Contains(preCode)) item.OrderType = OrderCsType.ECOMMERCE;
                        }
                        else
                        {
                            item.OrderType = "PAY_ORDER";
                            item.RefCode = "PAY_ORDER";
                        }
                        item.CreateDateStr = x.CreatedDate.ToString("dd/MM/yyyy");
                        return item;
                    }).ToList();

                    CultureInfo culture2 = new CultureInfo("en-US");
                    var paymentGroups = paymentViewModels.GroupBy(x => x.CreateDateStr);
                    var data = paymentGroups.Select(x =>
                    {
                        var item = new PaymentTransactionHistoryViewModel();
                        item.CreatedDate = DateTime.ParseExact(x.Key, "dd/MM/yyyy", culture2, DateTimeStyles.None);

                        item.CreatedDateDisplay = Utility.GetDateDisplay(item.CreatedDate);

                        item.Payments = x.ToList();
                        return item;
                    }).ToList();

                    response.FromPaging(paging).SetData(data).Successful();
                }

            }, response);

            return Task.FromResult(response);
        }
    }
}
