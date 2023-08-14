using Core.Common;
using iChiba.OM.Model;
using System;
using System.Collections.Generic;

namespace iChiba.OM.Service.Interface
{
    public interface IOrderPurchaseService {
        IList<OrderPurchase> GetCodes(string[] codes);
        IList<OrderPurchase> Gets(string keywork, string SyncAccNo, DateTime? StartTime, DateTime? EndTime, string type, string productTitle, int? syncAccStatus, string accCredit, string objectCodeCredit, string accDebit, string objectCodeDebit, Sorts sorts, Paging paging);
        IList<OrderPurchase> GetsObjectTpeDebit(string objectTypeDebit);
        IList<OrderPurchase> GetsObjectTpeCredited(string objectTypeCredited);
        IList<OrderPurchase> GetsObjectCodeDebit(string[] objectCodeDebit);
        IList<OrderPurchase> GetsObjectCodeCredit(string[] objectCodeCredit);
        IList<OrderPurchase> GetByLogIds(int[] logIds, params int[] syncStatuses);
        void Delete(OrderPurchase model);
        OrderPurchase GetById(int Id);
        IList<OrderPurchase> GetsTotalAmountOrderPurchaseByOrderCode(string orderCode);
        IList<OrderPurchase> GetsByOrderCode(string orderCode);
        IList<OrderPurchase> OrderPurchaseGetBylistId(int[] Id);
        void Update(OrderPurchase orderPurchase);
        IList<OrderPurchase> GetsOrderPurchasePOForJPMH(string keywork, string SyncAccNo, DateTime? StartTime, DateTime? EndTime, string type, string productTitle, int? syncAccStatus, string accCredit, string objectCodeCredit, string accDebit, string objectCodeDebit, Sorts sorts, Paging paging);
        IList<OrderPurchase> GetsOrderPurchasePO(string preCode, string keywork, string SyncAccNo, DateTime? StartTime, DateTime? EndTime, string type, string productTitle, int? syncAccStatus, string accCredit, string objectCodeCredit, string accDebit, string objectCodeDebit, string objectCode,Sorts sorts, Paging paging);
        IList<OrderPurchase> GetsOrderPurchasePO(string code,string preCode, string keywork, string SyncAccNo, DateTime? StartTime, DateTime? EndTime, string type, string productTitle, int? syncAccStatus, string accCredit, string objectCodeCredit, string accDebit, string objectCodeDebit, Sorts sorts, Paging paging);
        IList<OrderPurchase> GetsOrderPurchase(string[] accountIds,string keywork, string orderType, string SyncAccNo, DateTime? StartTime, DateTime? EndTime, string type, string productTitle, int? syncAccStatus, string accCredit, string objectCodeCredit, string accDebit, string objectCodeDebit, string objectCode,Sorts sorts, Paging paging);
        IList<OrderPurchase> GetsTotalAmountOrderPurchase(string[] accountIds,string keywork, string orderType, string SyncAccNo, DateTime? StartTime, DateTime? EndTime, string type, string productTitle, int? syncAccStatus, string accCredit, string objectCodeCredit, string accDebit, string objectCodeDebit, string objectCode);
        bool HasLogIdAndSyncStatus(int logId, params int[] syncStatuses);
        OrderPurchase GetByLogId(int logId);
        IList<OrderPurchase> GetsObjectCodeCredit(string[] objectCodeCredit,DateTime? startTime,DateTime? endTime, string Type);
        IList<OrderPurchase> GetsObjectCodeDebit(string[] objectCodeDebit, DateTime? startTime, DateTime? endTime, string Type);

        IList<OrderPurchase> GetBuyObjectCodeCredits(string objectCodeCredits,DateTime? startTime,DateTime? endTime);
        IList<OrderPurchase> GetBuyObjectCodeDebits(string objectCodeDebits, DateTime? startTime, DateTime? endTime);
        IList<OrderPurchase> GetsOrderPurchaseDebtCredit(string code,string objectCodeCredit, string keywork, DateTime? StartTime, DateTime? EndTime, string type, int? syncAccStatus,DateTime? startTimeDefault,DateTime? endTimeDefault, Sorts sorts,Paging paging);
        IList<OrderPurchase> GetsOrderPurchaseDebtDebit(string code, string objectCodeDedit, string keywork, DateTime? StartTime, DateTime? EndTime, string type, int? syncAccStatus, Sorts sorts, Paging paging);
        IList<OrderPurchase> GetsExportOrderPurchaseDebtCredit(string code, string objectCodeCredit, string keywork, DateTime? StartTime, DateTime? EndTime, string type, int? syncAccStatus, DateTime? startTimeDefault, DateTime? endTimeDefault);
        IList<OrderPurchase> GetsExportOrderPurchaseDebtDebitDebit(string code, string objectCodeDedit, string keywork, DateTime? StartTime, DateTime? EndTime, string type, int? syncAccStatus);
        IList<OrderPurchase> GetsHomeOrderPurchase(string code, string orderCode, DateTime? StartTime, DateTime? EndTime, string type, DateTime? startTime,DateTime? endTimeDefault,Sorts sorts, Paging paging);
        IList<OrderPurchase> GetsOrderPurchaseBuy(DateTime? startTime, DateTime? endTime, List<string> objectCodeCredit);
        IList<OrderPurchase> GetsOrderPurchaseCancel(DateTime? startTime, DateTime? endTime, List<string> objectCodeCredit);
        IList<OrderPurchase> GetsHomeOrderPurchaseTotalAmount(string code, string orderCode, DateTime? StartTime, DateTime? EndTime, string type, DateTime? startTimeDefault, DateTime? endTimeDefault);
        IList<OrderPurchase> GetOrderPurchaseBySupplier(List<string> code, DateTime? startTime, DateTime? endTime);
    }
}
