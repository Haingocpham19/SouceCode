using Core.Specification.Abstract;
using iChiba.OM.Model;
using System;
using System.Linq;

namespace iChiba.OM.Specification.Implement
{
    public class OrderPurchaseLogGetByGTId : SpecificationBase<OrderPurchaseLog>
    {
        public OrderPurchaseLogGetByGTId(int id)
           : base(m => m.Id > id)
        {
        }
    }

    public class OrderPurchaseLogGetByOrderId : SpecificationBase<OrderPurchaseLog>
    {
        public OrderPurchaseLogGetByOrderId(int orderId)
           : base(m => m.OrderId == orderId)
        {
        }
    }

    public class OrderPurchaseLogGetByActionType : SpecificationBase<OrderPurchaseLog>
    {
        public OrderPurchaseLogGetByActionType(string actionType)
           : base(m => m.ActionType.Equals(actionType))
        {
        }
    }

    public class OrderPurchaseLogGetByActionTypes : SpecificationBase<OrderPurchaseLog>
    {
        public OrderPurchaseLogGetByActionTypes(string[] actionTypes)
           : base(m => actionTypes.Contains(m.ActionType))
        {
        }
    }

    public class OrderPurchaseLogGetByStatus : SpecificationBase<OrderPurchaseLog>
    {
        public OrderPurchaseLogGetByStatus(int status)
           : base(m => m.Status == status)
        {
        }
    }

    public class OrderPurchaseLogGetByGTEActionDate : SpecificationBase<OrderPurchaseLog>
    {
        public OrderPurchaseLogGetByGTEActionDate(DateTime actionDate)
           : base(m => m.ActionDate >= actionDate)
        {
        }
    }
}
