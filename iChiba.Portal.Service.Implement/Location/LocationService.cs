using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Service.Implement
{
    public class LocationService : ILocationService
    {
        private readonly ILocationCache LocationCache;

        public LocationService(
            ILocationCache LocationCache)
        {
            this.LocationCache = LocationCache;
        }


        public Task<Location> GetById(int id)
        {
            return LocationCache.GetById(id);
        }

        public Task<IList<Location>> GetByIds(params int[] ids)
        {
            return LocationCache.GetByIds(ids);
        }

        public Task<bool> HashSet(Location model)
        {
            return LocationCache.HashSet(model);
        }

        public Task HashDelete(int id)
        {
            return LocationCache.HashDelete(id);
        }

        public async Task<IList<Location>> GetFromIdToRoot(int id)
        {
            var result = new List<Location>();
            var model = await GetById(id);

            if (model == null)
            {
                return result;
            }

            result.Add(model);

            if (model.Parent.HasValue)
            {
                var resultByParent = await GetFromIdToRoot(model.Parent.Value);

                result.AddRange(resultByParent);
            }

            return result;
        }
    }
}
