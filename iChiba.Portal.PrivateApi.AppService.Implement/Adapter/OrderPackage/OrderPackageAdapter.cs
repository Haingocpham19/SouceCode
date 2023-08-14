using AutoMapper;
using iChiba.OM.Model;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.Portal.PrivateApi.AppModel.Requests;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class OrderPackageAdapter
    {

        public static OrderPackage ToModel(this OrderPackageAddRequest model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<OrderPackageAddRequest, OrderPackage>(model);
        }
        public static OrderPackageList ToOrderPackageList(this OrderPackage model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<OrderPackage, OrderPackageList>(model);
        }
        public static OrderPackage ToModel(this OrderPackageUpdateRequest model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<OrderPackageUpdateRequest, OrderPackage>(model);
        }
    }
}
