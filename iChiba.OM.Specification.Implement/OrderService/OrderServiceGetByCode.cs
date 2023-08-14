using System.Collections.Generic;
using Core.Specification.Abstract;

namespace iChiba.OM.Specification.Implement
{
    public class OrderServiceGetByCode : SpecificationBase<Model.OrderService>
    {
        public OrderServiceGetByCode(string code)
        : base(m => !string.IsNullOrEmpty(m.Code) && m.Code.Equals(code))
        {

        }
    }
    public class OrderServiceGetByWarehouseId : SpecificationBase<Model.OrderService>
    {
        public OrderServiceGetByWarehouseId(int warehouseId)
            : base(m =>  m.WarehouseId.Equals(warehouseId))
        {

        }
    }
    public class OrderServiceGetById : SpecificationBase<Model.OrderService>
    {
        public OrderServiceGetById(int id)
            : base(m => m.Id.Equals(id))
        {

        }
    }
}
