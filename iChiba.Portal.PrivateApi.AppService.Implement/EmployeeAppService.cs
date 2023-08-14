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
    public class EmployeeAppService : BaseAppService, IEmployeeAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentContext _currentContext;
        private readonly IAspNetUserCache _aspNetUserCache;
        private readonly ICustomerService _customerService;
        private readonly IEmployeeService _employeeService;
        private readonly IOrderService _orderService;
        private readonly ICustomerWalletService _customerWalletService;
        private readonly IPaymentService _paymentService;

        public EmployeeAppService(
            ILogger<CustomerAppService> logger,
            IUnitOfWork unitOfWork,
            IAspNetUserCache aspNetUserCache,
            ICustomerService customerService,
            IEmployeeService employeeService,
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
            _employeeService = employeeService;
            _orderService = orderService;
            _customerWalletService = customerWalletService;
            _paymentService = paymentService;
        }

        public Task<EmployeeResponse> GetEmpoyeeByCustomer()
        {
            var response = new EmployeeResponse();

            TryCatch(() =>
            {
                var customer = _customerService.GetByAccountId(_currentContext.UserId);
                if (customer == null) throw new ErrorCodeException(Common.ErrorCodeDefine.NOT_FOUND);

                var employee = _employeeService.GetByAccountId(customer.CareBy);
                if (employee == null)
                    if (customer == null) throw new ErrorCodeException(Common.ErrorCodeDefine.NOT_FOUND);
                var responseData = employee.ToModel();

                response.SetData(responseData).Successful();
                return response;
            }, response);

            return Task.FromResult(response);
        }
    }
}
