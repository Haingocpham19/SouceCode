using Core.AppModel.Response;
using Core.Common;
using Core.CustomException;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppModel.Response;
using iChiba.Portal.PublicApi.AppService.Implement.Adapter;
using iChiba.Portal.PublicApi.AppService.Interface;
using iChiba.Portal.Service.Interface;
using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class LocationAppService : BaseAppService, ILocationAppService
    {
        private readonly ILocationsCacheService locationsService;
        private readonly ILocationsNodeCacheService locationsNodeService;
        private readonly ILocationsParentNodeCacheService locationsParentNodeService;

        public LocationAppService(ILogger<LocationAppService> logger,
            ILocationsCacheService locationsService,
            ILocationsNodeCacheService locationsNodeService,
            ILocationsParentNodeCacheService locationsParentNodeService)
            : base(logger)
        {
            this.locationsService = locationsService;
            this.locationsNodeService = locationsNodeService;
            this.locationsParentNodeService = locationsParentNodeService;
        }

        public async Task<BaseEntityResponse<IList<Location>>> GetLocationsChild(int id)
        {
            var response = new BaseEntityResponse<IList<Location>>();

            await TryCatchAsync(async () =>
            {

                var responseData = await GetLocation(id);
                if(responseData!= null)
                {
                    response.SetData(responseData)
                        .Successful();
                }

                return response;
            }, response);

            return response;
        }
        public async Task<LocationForAddressCustomerResponse> GetLocationsForAddressCustomer(LocationForAddressCustomerRequest request)
        {
            var response = new LocationForAddressCustomerResponse();
            const int RootId = 0;

            await TryCatchAsync(async () =>
            {
                response.ProvinceList =await GetLocation(RootId);
                if (response.ProvinceList != null)
                {
                    var province = response.ProvinceList.Where(m => m.Name.Contains(request.ProvinceName))?.FirstOrDefault();
                    if (province != null)
                    {
                        response.DisttrictList = await GetLocation(province.Id);
                    }
                }
                if (response.DisttrictList != null)
                {
                    var district = response.DisttrictList.Where(m => m.Name.Contains(request.DistrictName))?.FirstOrDefault();
                    if (district != null)
                    {
                        response.WardList = await GetLocation(district.Id);
                    }
                }

                response.Successful();

                return response;
            }, response);

            return response;
        }

        private async Task<List<Location>> GetLocation (int Id)
        {
            var LocationsNode = await locationsNodeService.GetById(Id);

            if (LocationsNode == null)
            {
                return null;
            }

            var allIdChild = LocationsNode.Childs.Select(m => m.Id).ToArray();
            var data = await locationsService.GetByIds(allIdChild);
            var responseData = data.Where(m => m != null).Select(m => m.ToModel()).ToList();
            return responseData;
        }
    }
}
