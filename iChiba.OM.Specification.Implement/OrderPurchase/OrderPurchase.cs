using Core.Specification.Abstract;
using iChiba.OM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace iChiba.OM.Specification.Implement
{
    public class OrderPurchaseGetByLogIds : SpecificationBase<OrderPurchase>
    {
        public OrderPurchaseGetByLogIds(params int[] logIds) 
            : base(m => m.LogId != null && logIds.Contains(m.LogId.Value))
        {
        }
    }

    public class OrderPurchaseGetByCodes : SpecificationBase<OrderPurchase>
    {
        public OrderPurchaseGetByCodes(params string[] code)
            : base(m => code.Contains(m.OrderCode))
        {
        }
    }

    public class OrderPurchaseGetBySyncStatus : SpecificationBase<OrderPurchase>
    {
        public OrderPurchaseGetBySyncStatus(int syncStatus)
            : base(m => m.SyncAccStatus == syncStatus)
        {
        }
    }

    public class OrderPurchaseGetBySyncStatuses : SpecificationBase<OrderPurchase>
    {
        public OrderPurchaseGetBySyncStatuses(params int[] syncStatuses)
            : base(m => m.SyncAccStatus != null && syncStatuses.Contains(m.SyncAccStatus.Value))
        {
        }
    }

    public class OrderPurchaseGetByLogId : SpecificationBase<OrderPurchase>
    {
        public OrderPurchaseGetByLogId(int logId)
            : base(m => m.LogId == logId)
        {
        }
    }
}
