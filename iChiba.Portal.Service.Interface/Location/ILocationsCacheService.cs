using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.Service.Interface
{
    public interface ILocationsCacheService
    {
        //Task<Locations> Search(string provinceName, string districtName, string wardName, string type);
        Task<Location> SearchProvince(IList<Location> locations, string provinceName);
        Task<IList<Location>> SearchProvinceAutoComplete(string provinceName);
        Task<Location> SearchDistrict(IList<Location> locations, int provinceId, string districtName);
        Task<Location> SearchWard(IList<Location> locations, int districtId, string wardName);
        Task<IList<Location>> GetAll();
        Task<Location> GetById(int id);
        Task<IList<Location>> GetByIds(params int[] ids);
        Task<bool> HashSet(Location model);
        Task HashDelete(int id);
        Task<IList<Location>> GetFromIdToRoot(int id);
    }
}
