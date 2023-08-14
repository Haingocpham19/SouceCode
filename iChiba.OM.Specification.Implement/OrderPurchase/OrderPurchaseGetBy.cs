using Core.Specification.Abstract;
using iChiba.OM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iChiba.OM.Specification.Implement
{
    public class OrderPurchaseGetBy : SpecificationBase<OrderPurchase>
    {
        public OrderPurchaseGetBy(string keyword, string SyncAccNo, DateTime? startTime, DateTime? EndTime, string type, string productTitle, int? syncAccStatus, string accCredit, string objectCodeCredit, string accDebit, string objectCodeDebit)
               : base(m => (string.IsNullOrEmpty(keyword) || m.SyncAccNo.Contains(keyword))
                     && (string.IsNullOrWhiteSpace(SyncAccNo) || m.SyncAccNo.Contains(SyncAccNo))
                     && (string.IsNullOrWhiteSpace(type) || (type.Equals("BUY") ? m.Type.Equals("BUY") : type.Equals("SURCHARGE") ? m.Type.Equals("SURCHARGE") : m.Type.StartsWith("CANCEL")))
                     && (string.IsNullOrWhiteSpace(productTitle) || m.ProductTitle.Contains(productTitle))
                     && (string.IsNullOrWhiteSpace(accCredit) || m.AccCredited.Contains(accCredit))
                     && (string.IsNullOrWhiteSpace(accDebit) || m.AccDebit.Contains(accDebit))
                     && (string.IsNullOrWhiteSpace(objectCodeCredit) || m.ObjectCodeCredited.Contains(objectCodeCredit))
                     && (string.IsNullOrWhiteSpace(objectCodeDebit) || m.ObjectCodeDebit.Contains(objectCodeDebit))
                     && (startTime == null || m.ActionDate >= startTime)
                     && (EndTime == null || m.ActionDate <= EndTime)
                     && (syncAccStatus == null || m.SyncAccStatus == syncAccStatus || m.SyncAccStatus == syncAccStatus || m.SyncAccStatus == syncAccStatus)
               )
        {

        }

        public OrderPurchaseGetBy(string preCode, string keyword, string SyncAccNo, DateTime? startTime, DateTime? EndTime, string type, string productTitle, int? syncAccStatus, string accCredit, string objectCodeCredit, string accDebit, string objectCodeDebit,string objectCode)
              : base(m => (string.IsNullOrEmpty(keyword) || m.SyncAccNo.Contains(keyword))
                    && (string.IsNullOrWhiteSpace(preCode) || m.OrderCode.StartsWith(preCode))
                    && (string.IsNullOrWhiteSpace(SyncAccNo) || m.SyncAccNo.Contains(SyncAccNo))
                    && (string.IsNullOrWhiteSpace(type) || (type.Equals("BUY") ? m.Type.Equals("BUY") : type.Equals("SURCHARGE") ? m.Type.Equals("SURCHARGE") : type.Equals("CANCEL_BUY") ? m.Type.Equals("CANCEL_BUY") : m.Type.Equals("CANCEL_SURCHARGE")))
                    && (string.IsNullOrWhiteSpace(productTitle) || m.ProductTitle.Contains(productTitle))
                    && (string.IsNullOrWhiteSpace(accCredit) || m.AccCredited.Contains(accCredit))
                    && (string.IsNullOrWhiteSpace(accDebit) || m.AccDebit.Contains(accDebit))
                    && (string.IsNullOrWhiteSpace(objectCodeCredit) || m.ObjectCodeCredited.Contains(objectCodeCredit))
                    && (string.IsNullOrWhiteSpace(objectCodeDebit) || m.ObjectCodeDebit.Contains(objectCodeDebit))
                    && (string.IsNullOrWhiteSpace(objectCode) || m.ObjectCodeCredited.Contains(objectCode) || m.ObjectCodeDebit.Contains(objectCode))
                    && (startTime == null || m.ActionDate >= startTime)
                    && (EndTime == null || m.ActionDate <= EndTime)
                    && (syncAccStatus == null || m.SyncAccStatus == syncAccStatus || m.SyncAccStatus == syncAccStatus || m.SyncAccStatus == syncAccStatus)
              )
        {

        }
        public OrderPurchaseGetBy(string code, string preCode, string keyword, string SyncAccNo, DateTime? startTime, DateTime? EndTime, string type, string productTitle, int? syncAccStatus, string accCredit, string objectCodeCredit, string accDebit, string objectCodeDebit)
              : base(m => (string.IsNullOrEmpty(keyword) || m.SyncAccNo.Contains(keyword))
                    && (string.IsNullOrWhiteSpace(preCode) || m.OrderCode.StartsWith(preCode))
                    && (string.IsNullOrWhiteSpace(SyncAccNo) || m.SyncAccNo.Contains(SyncAccNo))
                    && (string.IsNullOrWhiteSpace(type) || (type.Equals("BUY") ? m.Type.Equals("BUY") : type.Equals("SURCHARGE") ? m.Type.Equals("SURCHARGE") : type.Equals("CANCEL_BUY") ? m.Type.Equals("CANCEL_BUY") : m.Type.Equals("CANCEL_SURCHARGE")))
                    && (string.IsNullOrWhiteSpace(productTitle) || m.ProductTitle.Contains(productTitle))
                    && (string.IsNullOrWhiteSpace(accCredit) || m.AccCredited.Contains(accCredit))
                    && (string.IsNullOrWhiteSpace(accDebit) || m.AccDebit.Contains(accDebit))
                    && (string.IsNullOrWhiteSpace(objectCodeCredit) || m.ObjectCodeCredited.Contains(objectCodeCredit))
                    && (string.IsNullOrWhiteSpace(objectCodeDebit) || m.ObjectCodeDebit.Contains(objectCodeDebit))
                    && (startTime == null || m.ActionDate >= startTime)
                    && (EndTime == null || m.ActionDate <= EndTime)
                    && (syncAccStatus == null || m.SyncAccStatus == syncAccStatus || m.SyncAccStatus == syncAccStatus || m.SyncAccStatus == syncAccStatus)
                    && (m.ObjectCodeCredited.Equals(code) || m.ObjectCodeDebit.Equals(code))
              )
        {

        }


        public OrderPurchaseGetBy(string code, string orderCode, DateTime? startTime, DateTime? EndTime, string type,DateTime? startTimeDefault,DateTime? endTimeDefault)
             : base(m => (string.IsNullOrWhiteSpace(orderCode) || m.OrderCode.Contains(orderCode))
                   && (string.IsNullOrWhiteSpace(type) || (type.Equals("BUY") ? m.Type.Equals("BUY") : type.Equals("SURCHARGE") ? m.Type.Equals("SURCHARGE") : type.Equals("CANCEL_BUY") ? m.Type.Equals("CANCEL_BUY") : m.Type.Equals("CANCEL_SURCHARGE")))
                   && (startTime == null || m.ActionDate >= startTime)
                   && (EndTime == null || m.ActionDate <= EndTime)
                   && (startTimeDefault == null || m.ActionDate >= startTimeDefault)
                   && (endTimeDefault == null || m.ActionDate <= endTimeDefault)
                   && (m.ObjectCodeCredited.Equals(code) || m.ObjectCodeDebit.Equals(code))
             )
        {

        }

        public OrderPurchaseGetBy(List<string> code, DateTime? startTime, DateTime? EndTime)
               : base(m => code.Contains(m.ObjectCodeCredited)
                     && (startTime == null || m.ActionDate >= startTime)
                     && (EndTime == null || m.ActionDate <= EndTime)
               )
        {

        }

    }


    public class OrderPurchaseGet : SpecificationBase<OrderPurchase>
    {
        public OrderPurchaseGet(string[] accountIds,string keyword, string orderType, string SyncAccNo, DateTime? startTime, DateTime? EndTime, string type, string productTitle, int? syncAccStatus, string accCredit, string objectCodeCredit, string accDebit, string objectCodeDebit,string objectCode)
               : base(m => (string.IsNullOrEmpty(keyword) || m.SyncAccNo.Contains(keyword))
                     && (string.IsNullOrWhiteSpace(orderType) || (orderType.Equals("MH") ? (m.OrderCode.StartsWith("JP") || m.OrderCode.StartsWith("MH")) : m.OrderCode.StartsWith(orderType)))
                     && (string.IsNullOrWhiteSpace(SyncAccNo) || m.SyncAccNo.Contains(SyncAccNo))
                     && (string.IsNullOrWhiteSpace(type) || (type.Equals("BUY") ? m.Type.Equals("BUY") : type.Equals("SURCHARGE") ? m.Type.Equals("SURCHARGE") : type.Equals("CANCEL_BUY") ? m.Type.Equals("CANCEL_BUY") : m.Type.Equals("CANCEL_SURCHARGE")))
                     && (string.IsNullOrWhiteSpace(productTitle) || m.ProductTitle.Contains(productTitle))
                     && (string.IsNullOrWhiteSpace(accCredit) || m.AccCredited.Contains(accCredit))
                     && (string.IsNullOrWhiteSpace(accDebit) || m.AccDebit.Contains(accDebit))
                     && (string.IsNullOrWhiteSpace(objectCodeCredit) || m.ObjectCodeCredited.Contains(objectCodeCredit))
                     && (string.IsNullOrWhiteSpace(objectCodeDebit) || m.ObjectCodeDebit.Contains(objectCodeDebit))
                     && (string.IsNullOrWhiteSpace(objectCode) || m.ObjectCodeCredited.Contains(objectCode) || m.ObjectCodeDebit.Contains(objectCode))
                     && (startTime == null || m.ActionDate >= startTime)
                     && (EndTime == null || m.ActionDate <= EndTime)
                     && (accountIds == null || accountIds.Contains(m.AccountId))
                     && (syncAccStatus == null || m.SyncAccStatus == syncAccStatus || m.SyncAccStatus == syncAccStatus || m.SyncAccStatus == syncAccStatus)
               )
        {

        }


        public OrderPurchaseGet(string orderCode)
               : base(m => m.OrderCode.Equals(orderCode))
        {

        }

    }


    public class OrderPurchaseGetJPMH : SpecificationBase<OrderPurchase>
    {
        public OrderPurchaseGetJPMH(string keyword, string SyncAccNo, DateTime? startTime, DateTime? EndTime, string type, string productTitle, int? syncAccStatus, string accCredit, string objectCodeCredit, string accDebit, string objectCodeDebit)
              : base(m => (string.IsNullOrEmpty(keyword) || m.SyncAccNo.Contains(keyword))
                    && (m.OrderCode.StartsWith("JP") || m.OrderCode.StartsWith("MH"))
                    && (string.IsNullOrWhiteSpace(SyncAccNo) || m.SyncAccNo.Contains(SyncAccNo))
                    && (string.IsNullOrWhiteSpace(type) || (type.Equals("BUY") ? m.Type.Equals("BUY") : type.Equals("SURCHARGE") ? m.Type.Equals("SURCHARGE") : type.Equals("CANCEL_BUY") ? m.Type.Equals("CANCEL_BUY") : m.Type.Equals("CANCEL_SURCHARGE")))
                    && (string.IsNullOrWhiteSpace(productTitle) || m.ProductTitle.Contains(productTitle))
                    && (string.IsNullOrWhiteSpace(accCredit) || m.AccCredited.Contains(accCredit))
                    && (string.IsNullOrWhiteSpace(accDebit) || m.AccDebit.Contains(accDebit))
                    && (string.IsNullOrWhiteSpace(objectCodeCredit) || m.ObjectCodeCredited.Contains(objectCodeCredit))
                    && (string.IsNullOrWhiteSpace(objectCodeDebit) || m.ObjectCodeDebit.Contains(objectCodeDebit))
                    && (startTime == null || m.ActionDate >= startTime)
                    && (EndTime == null || m.ActionDate <= EndTime)
                    && (syncAccStatus == null || m.SyncAccStatus == syncAccStatus || m.SyncAccStatus == syncAccStatus || m.SyncAccStatus == syncAccStatus)
              )
        {

        }
    }

    public class OrderPurchaseGetDebt : SpecificationBase<OrderPurchase>
    {
        public OrderPurchaseGetDebt(string code,string objectCodeCredit, string keyword, DateTime? startTime, DateTime? EndTime, string type, int? syncAccStatus,DateTime? startTimeDefault,DateTime? endTimeDefault)
             : base(m => (string.IsNullOrWhiteSpace(keyword) || m.SyncAccNo.Contains(keyword))
                   && (string.IsNullOrWhiteSpace(type) || (type.Equals("BUY") ? m.Type.Equals("BUY") : type.Equals("SURCHARGE") ? m.Type.Equals("SURCHARGE") : type.Equals("CANCEL_BUY") ? m.Type.Equals("CANCEL_BUY") : m.Type.Equals("CANCEL_SURCHARGE")))
                   && (startTime == null || m.ActionDate >= startTime)
                   && (EndTime == null || m.ActionDate <= EndTime)
                   && (startTimeDefault == null || m.ActionDate >= startTimeDefault)
                   && (endTimeDefault == null || m.ActionDate <= endTimeDefault)
                   && (syncAccStatus == null || m.SyncAccStatus == syncAccStatus || m.SyncAccStatus == syncAccStatus || m.SyncAccStatus == syncAccStatus)
                   && (string.IsNullOrWhiteSpace(code) || m.OrderCode.Equals(code))
                   && (m.ObjectCodeCredited.Contains(objectCodeCredit))
             )
        {

        }
    }


    public class OrderPurchaseGetDebtDebit : SpecificationBase<OrderPurchase>
    {
        public OrderPurchaseGetDebtDebit(string code, string objectCodeDedit, string keyword, DateTime? startTime, DateTime? EndTime, string type, int? syncAccStatus)
             : base(m => (string.IsNullOrWhiteSpace(keyword) || m.SyncAccNo.Contains(keyword))
                   && (string.IsNullOrWhiteSpace(type) || (type.Equals("BUY") ? m.Type.Equals("BUY") : type.Equals("SURCHARGE") ? m.Type.Equals("SURCHARGE") : type.Equals("CANCEL_BUY") ? m.Type.Equals("CANCEL_BUY") : m.Type.Equals("CANCEL_SURCHARGE")))
                   && (startTime == null || m.ActionDate >= startTime)
                   && (EndTime == null || m.ActionDate <= EndTime)
                   && (syncAccStatus == null || m.SyncAccStatus == syncAccStatus || m.SyncAccStatus == syncAccStatus || m.SyncAccStatus == syncAccStatus)
                   && (string.IsNullOrWhiteSpace(code) || m.OrderCode.Equals(code))
                   && (m.ObjectCodeDebit.Contains(objectCodeDedit))
             )
        {

        }
    }

    public class OrderPurchaseGetByObjectTypeDebit : SpecificationBase<OrderPurchase>
    {
        public OrderPurchaseGetByObjectTypeDebit(string objectTypeDebit)
               : base(m => m.ObjectTypeDebit.Equals(objectTypeDebit))
        {

        }
    }

    public class OrderPurchaseGetByObjectCodeDebit : SpecificationBase<OrderPurchase>
    {
        public OrderPurchaseGetByObjectCodeDebit(string[] objectCodeDebit)
               : base(m => objectCodeDebit.Contains(m.ObjectCodeDebit))
        {

        }

        public OrderPurchaseGetByObjectCodeDebit(string objectCodeDebit,DateTime? startTime,DateTime? endTime)
              : base(m => (m.ObjectCodeDebit.Contains(objectCodeDebit) && (m.Type.Equals("CANCEL_BUY") || m.Type.Equals("CANCEL_SURCHARGE")) && (m.ActionDate >= startTime) && (m.ActionDate <= endTime)))
        {

        }

        public OrderPurchaseGetByObjectCodeDebit(string[] objectCodeDebit, DateTime? startTime, DateTime? EndTime,string Type)
              : base(m => ((objectCodeDebit.Contains(m.ObjectCodeDebit)) && (m.Type.Equals(Type)) && ((startTime == null || m.ActionDate >= startTime)
                    && (EndTime == null || m.ActionDate <= EndTime))))
        {

        }

        public OrderPurchaseGetByObjectCodeDebit(DateTime? startTime, DateTime? endTime, List<string> objectCodeCredited)
             : base(m => (startTime == null || m.ActionDate >= startTime)
                  && (endTime == null || m.ActionDate <= endTime)
                  && (m.Type.Equals("CANCEL_BUY") || m.Type.Equals("CANCEL_SURCHARGE"))
                  && (objectCodeCredited.Contains(m.ObjectCodeDebit)))
        {

        }
    }

    public class OrderPurchaseGetBylistId : SpecificationBase<OrderPurchase>
    {
        public OrderPurchaseGetBylistId(int[] Id)
               : base(m => Id.Contains(m.Id))
        {

        }
    }

    public class OrderPurchaseGetByObjectTypeCredit : SpecificationBase<OrderPurchase>
    {
        public OrderPurchaseGetByObjectTypeCredit(string objectTypeCredited)
               : base(m => m.ObjectTypeCredited.Equals(objectTypeCredited))
        {

        }
    }

    public class OrderPurchaseGetByCode : SpecificationBase<OrderPurchase>
    {
        public OrderPurchaseGetByCode(string orderCode)
               : base(m => m.OrderCode.Equals(orderCode))
        {

        }
    }


    public class OrderPurchaseGetByObjectCodeCredit : SpecificationBase<OrderPurchase>
    {
        public OrderPurchaseGetByObjectCodeCredit(string[] objectCodeCredited)
               : base(m => objectCodeCredited.Contains(m.ObjectCodeCredited))
        {

        }

        public OrderPurchaseGetByObjectCodeCredit(DateTime? startTime,DateTime? endTime,List<string> objectCodeCredited)
              : base(m =>(startTime == null || m.ActionDate >= startTime)
                   && (endTime == null || m.ActionDate <= endTime)
                   && (m.Type.Equals("BUY") || m.Type.Equals("SURCHARGE"))
                   && (objectCodeCredited.Contains(m.ObjectCodeCredited)))
        {

        }

        public OrderPurchaseGetByObjectCodeCredit(string objectCodeCredited,DateTime? startTime,DateTime? endTime)
              : base(m => (m.ObjectCodeCredited.Contains(objectCodeCredited) && (m.Type.Equals("BUY") || m.Type.Equals("SURCHARGE")) && (m.ActionDate >= startTime) && (m.ActionDate <= endTime)))
        {

        }

        public OrderPurchaseGetByObjectCodeCredit(string[] objectCodeCredited, DateTime? startTime, DateTime? EndTime,string Type)
              : base(m => ((objectCodeCredited.Contains(m.ObjectCodeCredited)) && (m.Type.Equals(Type)) && ((startTime == null || m.ActionDate >= startTime)
                    && (EndTime == null || m.ActionDate <= EndTime))))
        {

        }
    }
}
