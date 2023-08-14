using AutoMapper;
using iChiba.WH.Model;
using Ichiba.WH.Api.Driver.Model.Warehouse;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class WarehouseAdapter
    {
        public static WarehouseList ToWarehouseList(this Warehouse model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Warehouse, WarehouseList>(model);
        }

        public static WarehouseViewModel ToModel(this Warehouse model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Warehouse, WarehouseViewModel>(model);
        }
    }
}
