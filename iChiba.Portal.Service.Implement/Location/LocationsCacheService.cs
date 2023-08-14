using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Core.Common;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.Service.Implement
{
    public class LocationsCacheService : ILocationsCacheService
    {
        private readonly ILocationCache _locationsCache;

        public LocationsCacheService(ILocationCache locationsCache)
        {
            _locationsCache = locationsCache;
        }

        public async Task<Location> Search(string provinceName, string districtName, string wardName, string type)
        {
            var data = await _locationsCache.GetAll();
            if (!string.IsNullOrEmpty(provinceName))
            {
                return data.FirstOrDefault(x => x.Name.Equals(provinceName));
            }

            if (!string.IsNullOrEmpty(districtName))
            {
                return data.FirstOrDefault(x => x.Name.Equals(districtName) && x.Type.Equals(type));
            }

            if (!string.IsNullOrEmpty(wardName))
            {
                return data.FirstOrDefault(x => x.Name.Equals(wardName) && x.Type.Equals(type));
            }

            return null;
        }

        public async Task<Location> SearchProvince(IList<Location> locations, string provinceName)
        {
            var types = new[] { "PROVINCE" };
            IList<Location> data;
            if (locations == null) data = await _locationsCache.GetAll();
            else data = locations;
            if (!string.IsNullOrEmpty(provinceName))
            {
                var response = data.FirstOrDefault(x =>
                    x.Name.ToUnsign().Equals(provinceName.ToUnsign())
                    && types.Contains(x.Type));
                return response;
            }

            return null;
        }

        public async Task<IList<Location>> SearchProvinceAutoComplete(string provinceName)
        {
            var types = new[] { "PROVINCE" };
            IList<Location> data;
            data = await _locationsCache.GetAll();

            if (!data.Any()) return null;

            var response = data.Where(x =>
                x.Name.ToUnsign().Contains(provinceName.ToUnsign())
                && types.Contains(x.Type)).ToList();
            return response;
        }

        public async Task<Location> SearchDistrict(IList<Location> locations, int provinceId, string districtName)
        {
            var types = new[] { "Quận", "Huyện", "Thị xã", "Thành phố" };
            IList<Location> data;
            if (locations == null) data = await _locationsCache.GetAll();
            else data = locations;
            if (!string.IsNullOrEmpty(districtName))
            {
                return data.FirstOrDefault(x =>
                    x.Parent.Equals(provinceId)
                    && x.Name.Equals(districtName)
                    && types.Contains(x.Type));
            }

            return null;
        }

        public async Task<Location> SearchWard(IList<Location> locations, int districtId, string wardName)
        {
            var types = new[]
            {
                StripUnicodeCharactersFromString("Phường"), 
                StripUnicodeCharactersFromString("Xã"), 
                StripUnicodeCharactersFromString("Thị trấn")
            };
            IList<Location> data;
            if (locations == null) data = await _locationsCache.GetAll();
            else data = locations;
            if (!string.IsNullOrEmpty(wardName))
            {
                //Where(e => e.IndexOf(keyword, StringComparison.CurrentCultureIgnoreCase) >= 0)
                //return data.FirstOrDefault(x =>
                //    x.Parent.Equals(districtId)
                //    && x.Name.Equals(wardName)
                //    && types.Contains(x.Type));

                return data.FirstOrDefault(x =>
                    x.Parent.Equals(districtId)
                    && x.Name.Contains(wardName)
                    && types.Contains(StripUnicodeCharactersFromString(x.Type)));
            }

            return null;
        }

        public Task<IList<Location>> GetAll()
        {
            return _locationsCache.GetAll();
        }

        public Task<Location> GetById(int id)
        {
            return _locationsCache.GetById(id);
        }

        public Task<IList<Location>> GetByIds(params int[] ids)
        {
            return _locationsCache.GetByIds(ids);
        }

        public Task<bool> HashSet(Location model)
        {
            return _locationsCache.HashSet(model);
        }

        public Task HashDelete(int id)
        {
            return _locationsCache.HashDelete(id);
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

        public static string StripUnicodeCharactersFromString(string inputValue)
        {
            return Regex.Replace(inputValue, @"[^\u0000-\u007F]", string.Empty);
        }
    }
}
