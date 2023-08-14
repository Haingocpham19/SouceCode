using iChiba.Portal.PrivateApi.AppService.Implement.Adapter;
using iChiba.Portal.PrivateApi.AppService.Interface;
using iChiba.WH.Service.Interface;
using Ichiba.WH.Api.Driver.Response;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.AppService.Implement
{
    public class WarehouseAppService : BaseAppService, IWarehouseAppService
    {
        private readonly IWarehouseService _warehouseService;
        private readonly IShippingRouteWarehouseService _shippingRouteWarehouseService;

        public WarehouseAppService(
            ILogger<WarehouseAppService> logger,
            IWarehouseService warehouseService,
            IShippingRouteWarehouseService shippingRouteWarehouseService
        ) : base(logger)
        {
            _warehouseService = warehouseService;
            _shippingRouteWarehouseService = shippingRouteWarehouseService;
        }
        public Task<WarehouseListResponse> GetAll()
        {
            var response = new WarehouseListResponse();

            TryCatch(() =>
            {
                var warehouses = _warehouseService.GetAll();

                var responseData = warehouses.Where(x =>x.Region.Equals("QT"))
                    .Select(m => m.ToWarehouseList())
                    .ToList();

                response.SetData(responseData)
                    .Successful();
            }, response);

            return Task.FromResult(response);
        }

        public Task<WarehouseListResponse> GetByRoute(string route)
        {
            var response = new WarehouseListResponse();

            TryCatch(() =>
            {
                var warehouseCodes = _shippingRouteWarehouseService.GetByShippingRouteCode(route)
                    .Select(x => x.WarehouseCode).ToArray();

                var data = _warehouseService.GetByCodes(warehouseCodes).Where(x=>x.Region == "QT");
                var responseData = data
                    .Select(m => m.ToWarehouseList())
                    .ToList();

                response.SetData(responseData)
                    .Successful();
            }, response);

            return Task.FromResult(response);
        }
    }
}
