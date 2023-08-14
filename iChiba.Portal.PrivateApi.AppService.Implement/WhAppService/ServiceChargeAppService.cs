using Core.Common;
using Core.CustomException;
using Core.Repository.Interface;
using iChiba.WH.Service.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using iChiba.OM.Service.Interface;
using iChiba.WH.Model;
using iChiba.OM.DbContext;
using System.Collections.Generic;
using iChiba.Portal.PrivateApi.AppService.Interface;
using iChiba.Portal.PrivateApi.AppModel.Responses;
using iChiba.Portal.PrivateApi.AppService.Implement.Adapter;

namespace iChiba.Portal.PrivateApi.AppService.Implement
{
    public class ServiceChargeAppService : BaseAppService, IServiceChargeAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentContext _currentContext;
        private readonly IServiceChargeService _serviceChargeService;
        private readonly IProductService _productService;
        private readonly IWarehouseService _warehouseService;
        private readonly IPackageDetailService _packageDetailService;
        private readonly IOrderServiceService _orderServiceService;
        public ServiceChargeAppService(
            IUnitOfWork unitOfWork,
            ICurrentContext currentContext,
            ILogger<ServiceChargeAppService> logger,
            IProductService productService,
            IPackageDetailService packageDetailService,
            IServiceChargeService serviceChargeService,
            IWarehouseService warehouseService,
            IOrderServiceService orderServiceService
            ) : base(logger)
        {
            _unitOfWork = unitOfWork;
            _currentContext = currentContext;
            _productService = productService;
            _packageDetailService = packageDetailService;
            _serviceChargeService = serviceChargeService;
            _warehouseService = warehouseService;
            _orderServiceService = orderServiceService;
        }



        public Task<ServiceChargeListResponse> GetAll()
        {
            var response = new ServiceChargeListResponse();
            TryCatch(() =>
            {
                var data = _serviceChargeService.GetAll();
                var responseData = data.Select(x => x.ToModel()).ToList();
                response.SetData(responseData).Successful();
            }, response);

            return Task.FromResult(response);
        }
    }
}
