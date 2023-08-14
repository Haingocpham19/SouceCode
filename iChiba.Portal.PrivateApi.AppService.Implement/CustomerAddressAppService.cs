using Core.AppModel.Response;
using Core.CustomException;
using Core.Repository.Interface;
using iChiba.OM.Service.Interface;
using iChiba.Portal.CustomException;
using iChiba.Portal.PrivateApi.AppModel.Requests;
using iChiba.Portal.PrivateApi.AppModel.Responses;
using iChiba.Portal.PrivateApi.AppService.Implement.Adapter;
using iChiba.Portal.PrivateApi.AppService.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.AppService.Implement
{
    public class CustomerAddressAppService : BaseAppService, ICustomerAddressAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentContext _currentContext;
        private readonly ICustomerAddressService _customerAddressService;
        private readonly ICustomerService _customerService;

        public CustomerAddressAppService(
            ILogger<CustomerAddressAppService> logger,
            IUnitOfWork unitOfWork,
            ICurrentContext currentContext,
            ICustomerAddressService customerAddressService,
            ICustomerService customerService
        ) : base(logger)
        {
            _unitOfWork = unitOfWork;
            _currentContext = currentContext;
            _customerAddressService = customerAddressService;
            _customerService = customerService;
        }

        public Task<BaseResponse> Add(CustomerAddressAddRequest request)
        {
            var response = new BaseResponse();

            TryCatch(() =>
            {
                var customerAddress = request.ToModel();
                var customer = _customerService.GetByAccountId(_currentContext.UserId);
                if (customer == null) throw new ErrorCodeException(ErrorCodeDefine.NOT_FOUND);

                customerAddress.CustomerId = customer.Id;

                _customerAddressService.Add(customerAddress);
                _unitOfWork.Commit();

                response.Successful();
            }, response);

            return Task.FromResult(response);
        }

        public Task<BaseResponse> Delete(CustomerAddressDeleteRequest request)
        {
            var response = new BaseResponse();

            TryCatch(() =>
            {
                var customerAddress = _customerAddressService.GetById(request.Id);
                if (customerAddress == null) throw new ErrorCodeException(ErrorCodeDefine.NOT_FOUND);

                _customerAddressService.Delete(customerAddress);
                _unitOfWork.Commit();

                response.Successful();
            }, response);

            return Task.FromResult(response);
        }

        public Task<CustomerAddressListResponse> GetListAddress()
        {
            var response = new CustomerAddressListResponse();

            TryCatch(() =>
            {
                var customer = _customerService.GetByAccountId(_currentContext.UserId);
                if (customer == null) throw new ErrorCodeException(ErrorCodeDefine.NOT_FOUND);

                var customerAddress = _customerAddressService.GetByCustomerId(customer.Id).ToList();

                var customerAddressViewModels = customerAddress.Select(x => x.ToModel()).ToList();
                response.SetData(customerAddressViewModels).Successful();

            }, response);

            return Task.FromResult(response);
        }

        public Task<BaseResponse> Update(CustomerAddressUpdateRequest request)
        {
            var response = new BaseResponse();

            TryCatch(() =>
            {
                var customerAddress = _customerAddressService.GetById(request.Id);
                if (customerAddress == null) throw new ErrorCodeException(ErrorCodeDefine.NOT_FOUND);

                var customerAddressUpdate = customerAddress.ToUpdateModel(request);

                _customerAddressService.Update(customerAddressUpdate);
                _unitOfWork.Commit();

                response.Successful();
            }, response);

            return Task.FromResult(response);
        }
    }
}
