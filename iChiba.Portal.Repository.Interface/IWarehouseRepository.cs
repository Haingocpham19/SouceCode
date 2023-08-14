using Core.Repository.Interface;
using iChiba.WH.Model;
using System.Collections.Generic;

namespace iChiba.WH.Repository.Interface
{
    public interface IWarehouseRepository:IRepository<Warehouse>
    {
        void UpdateOrders(IList<Warehouse> models);
    }
}
