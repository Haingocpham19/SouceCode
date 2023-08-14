using Core.CustomException;
using Core.Repository.Interface;
using iChiba.OM.Model;
using iChiba.OM.Service.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Common;
using iChiba.Portal.CustomException;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.Portal.PrivateApi.AppModel.Responses;
using iChiba.Portal.PrivateApi.AppService.Implement.Adapter;
using iChiba.Portal.PrivateApi.AppService.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.AppService.Implement
{
    public class CustomerAppService : BaseAppService, ICustomerAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentContext _currentContext;
        private readonly IAspNetUserCache _aspNetUserCache;
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly ICustomerWalletService _customerWalletService;
        private readonly IPaymentService _paymentService;

        public CustomerAppService(
            ILogger<CustomerAppService> logger,
            IUnitOfWork unitOfWork,
            IAspNetUserCache aspNetUserCache,
            ICustomerService customerService,
            ICurrentContext currentContext,
            IOrderService orderService,
            ICustomerWalletService customerWalletService,
            IPaymentService paymentService
        ) : base(logger)
        {
            _aspNetUserCache = aspNetUserCache;
            _unitOfWork = unitOfWork;
            _currentContext = currentContext;
            _customerService = customerService;
            _orderService = orderService;
            _customerWalletService = customerWalletService;
            _paymentService = paymentService;
        }

        public Task<CustomerInfoHomePageResponse> GetCustomerInfoHomePage()
        {
            var response = new CustomerInfoHomePageResponse();

            TryCatch(() =>
            {
                var responseData = new CustomerInfoHomePageModel();

                var customer = _customerService.GetByAccountId(_currentContext.UserId);
                if (customer == null) throw new ErrorCodeException(Common.ErrorCodeDefine.NOT_FOUND);

                responseData.Customer = customer.ToModel();

                if (!string.IsNullOrEmpty(customer.CareBy))
                {
                    var saler = _aspNetUserCache.GetById(customer.CareBy).Result;
                    responseData.Customer.Saler = saler?.FullName ?? null;
                    responseData.Customer.SalerPhone = saler?.PhoneNumber ?? null;
                }

                var orders = _orderService.GetByAccountId(customer.AccountId).ToList();
                var customerWallet = _customerWalletService.GetByAccountId(customer.AccountId);
                var payments = _paymentService.GetByAccountId(customer.AccountId)
                    .Where(x => x.Refund != true
                        && (x.Status == PaymentStatus.Approved.GetHashCode() || x.Status == PaymentStatus.Processed.GetHashCode())
                    ).ToList();

                responseData.CustomerAggregateInfo = new CustomerAggregateInfoViewModel
                {
                    CountAllOrder = orders.Count,
                    CountOrderWaitDelivery = orders.Where(x => x.Status == OrderStatus.DANG_GIAO_HANG.GetHashCode()).ToList().Count,
                    CountOrderDelivered = orders.Where(x => x.Status == OrderStatus.DA_GIAO_HANG.GetHashCode()).ToList().Count,
                    TotalAvailableCash = (decimal)(customerWallet?.Cash ?? 0),
                    TotalCashFreeze = (decimal)(customerWallet?.CashFreeze ?? 0),
                    TotalPaymentWaitOrder = 0,
                    TotalPaymentApproved = payments.Where(x => x.Status == PaymentStatus.Approved.GetHashCode()).Sum(x => (decimal)x.Amount),
                    TotalPaymentProcessed = payments.Where(x => x.Status == PaymentStatus.Processed.GetHashCode()).Sum(x => (decimal)x.Amount)
                };

                response.SetData(responseData).Successful();
                return response;
            }, response);

            return Task.FromResult(response);
        }
    }
}
