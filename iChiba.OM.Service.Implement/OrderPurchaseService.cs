using Core.Common;
using Core.Specification.Abstract;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using iChiba.OM.Service.Interface;
using iChiba.OM.Specification.Implement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iChiba.OM.Service.Implement
{
    public class OrderPurchaseService : IOrderPurchaseService
    {
        private readonly IOrderPurchaseRepository orderPurchaseRepository;
        public OrderPurchaseService(IOrderPurchaseRepository orderPurchaseRepository)
        {
            this.orderPurchaseRepository = orderPurchaseRepository;
        }

        public IList<OrderPurchase> Gets(string keywork, string SyncAccNo, DateTime? StartTime, DateTime? EndTime, string type, string productTitle, int? syncAccStatus, string accCredit, string objectCodeCredit, string accDebit, string objectCodeDebit, Sorts sorts, Paging paging)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetBy(keywork, SyncAccNo, StartTime, EndTime, type, productTitle, syncAccStatus, accCredit, objectCodeCredit, accDebit, objectCodeDebit), sorts, paging).ToList();
        }

        public IList<OrderPurchase> GetsByOrderCode(string orderCode)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetByCode(orderCode)).ToList();
        }

        public IList<OrderPurchase> GetsOrderPurchase(string[] accountIds,string keywork, string orderType, string SyncAccNo, DateTime? StartTime, DateTime? EndTime, string type, string productTitle, int? syncAccStatus, string accCredit, string objectCodeCredit, string accDebit, string objectCodeDebit, string objectCode,Sorts sorts, Paging paging)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGet(accountIds,keywork, orderType, SyncAccNo, StartTime, EndTime, type, productTitle, syncAccStatus, accCredit, objectCodeCredit, accDebit, objectCodeDebit, objectCode), sorts, paging).ToList();
        }

        public IList<OrderPurchase> GetsTotalAmountOrderPurchaseByOrderCode(string orderCode)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGet(orderCode)).ToList();
        }

        public IList<OrderPurchase> GetsTotalAmountOrderPurchase(string[] accountIds,string keywork, string orderType, string SyncAccNo, DateTime? StartTime, DateTime? EndTime, string type, string productTitle, int? syncAccStatus, string accCredit, string objectCodeCredit, string accDebit, string objectCodeDebit,string objectCode)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGet(accountIds,keywork, orderType, SyncAccNo, StartTime, EndTime, type, productTitle, syncAccStatus, accCredit, objectCodeCredit, accDebit, objectCodeDebit, objectCode)).ToList();
        }

        public IList<OrderPurchase> GetsOrderPurchasePO(string preCode, string keywork, string SyncAccNo, DateTime? StartTime, DateTime? EndTime, string type, string productTitle, int? syncAccStatus, string accCredit, string objectCodeCredit, string accDebit, string objectCodeDebit, string objectCode,Sorts sorts, Paging paging)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetBy(preCode, keywork, SyncAccNo, StartTime, EndTime, type, productTitle, syncAccStatus, accCredit, objectCodeCredit, accDebit, objectCodeDebit, objectCode), sorts, paging).ToList();
        }
        public IList<OrderPurchase> GetsOrderPurchasePO(string code, string preCode, string keywork, string SyncAccNo, DateTime? StartTime, DateTime? EndTime, string type, string productTitle, int? syncAccStatus, string accCredit, string objectCodeCredit, string accDebit, string objectCodeDebit, Sorts sorts, Paging paging)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetBy(code, preCode, keywork, SyncAccNo, StartTime, EndTime, type, productTitle, syncAccStatus, accCredit, objectCodeCredit, accDebit, objectCodeDebit), sorts, paging).ToList();
        }

        public IList<OrderPurchase> GetsHomeOrderPurchase(string code, string orderCode, DateTime? StartTime, DateTime? EndTime, string type, DateTime? startTimeDefault,DateTime? endTimeDefault,Sorts sorts,Paging paging)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetBy(code, orderCode, StartTime, EndTime, type, startTimeDefault, endTimeDefault), sorts, paging).ToList();
        }

        public IList<OrderPurchase> GetsHomeOrderPurchaseTotalAmount(string code, string orderCode, DateTime? StartTime, DateTime? EndTime, string type, DateTime? startTimeDefault, DateTime? endTimeDefault)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetBy(code, orderCode, StartTime, EndTime, type, startTimeDefault, endTimeDefault)).ToList();
        }

        public IList<OrderPurchase> GetOrderPurchaseBySupplier(List<string> code, DateTime? startTime, DateTime? endTime)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetBy(code, startTime, endTime)).ToList();
        }

        public IList<OrderPurchase> GetsOrderPurchaseDebtCredit(string code, string objectCodeCredit,string keywork, DateTime? StartTime, DateTime? EndTime, string type, int? syncAccStatus, DateTime? startTimeDefault,DateTime? endTimeDefault,Sorts sorts,Paging paging)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetDebt(code,objectCodeCredit, keywork, StartTime, EndTime, type, syncAccStatus, startTimeDefault, endTimeDefault), sorts, paging).ToList();
        }

        public IList<OrderPurchase> GetsOrderPurchaseDebtDebit(string code, string objectCodeDedit, string keywork, DateTime? StartTime, DateTime? EndTime, string type, int? syncAccStatus, Sorts sorts, Paging paging)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetDebtDebit(code, objectCodeDedit, keywork, StartTime, EndTime, type, syncAccStatus), sorts, paging).ToList();
        }

        public IList<OrderPurchase> GetsExportOrderPurchaseDebtCredit(string code, string objectCodeCredit, string keywork, DateTime? StartTime, DateTime? EndTime, string type, int? syncAccStatus, DateTime? startTimeDefault, DateTime? endTimeDefault)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetDebt(code, objectCodeCredit, keywork, StartTime, EndTime, type, syncAccStatus, startTimeDefault, endTimeDefault)).ToList();
        }

        public IList<OrderPurchase> GetsExportOrderPurchaseDebtDebitDebit(string code, string objectCodeDedit, string keywork, DateTime? StartTime, DateTime? EndTime, string type, int? syncAccStatus)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetDebtDebit(code, objectCodeDedit, keywork, StartTime, EndTime, type, syncAccStatus)).ToList();
        }

        public IList<OrderPurchase> GetsOrderPurchasePOForJPMH(string keywork, string SyncAccNo, DateTime? StartTime, DateTime? EndTime, string type, string productTitle, int? syncAccStatus, string accCredit, string objectCodeCredit, string accDebit, string objectCodeDebit, Sorts sorts, Paging paging)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetJPMH(keywork, SyncAccNo, StartTime, EndTime, type, productTitle, syncAccStatus, accCredit, objectCodeCredit, accDebit, objectCodeDebit), sorts, paging).ToList();
        }

        public IList<OrderPurchase> GetsObjectTpeDebit(string objectTypeDebit)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetByObjectTypeDebit(objectTypeDebit)).ToList();
        }

        public IList<OrderPurchase> GetsObjectCodeDebit(string[] objectCodeDebit)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetByObjectCodeDebit(objectCodeDebit)).ToList();
        }

        public IList<OrderPurchase> OrderPurchaseGetBylistId(int[] Id)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetBylistId(Id)).ToList();
        }


        public IList<OrderPurchase> GetsObjectTpeCredited(string objectTypeCredited)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetByObjectTypeCredit(objectTypeCredited)).ToList();
        }

        public IList<OrderPurchase> GetsObjectCodeCredit(string[] objectCodeCredit)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetByObjectCodeCredit(objectCodeCredit)).ToList();
        }

        public IList<OrderPurchase> GetsOrderPurchaseBuy(DateTime? startTime,DateTime? endTime,List<string> objectCodeCredit)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetByObjectCodeCredit(startTime, endTime,objectCodeCredit)).ToList();
        }

        public IList<OrderPurchase> GetsOrderPurchaseCancel(DateTime? startTime, DateTime? endTime, List<string> objectCodeCredit)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetByObjectCodeDebit(startTime, endTime, objectCodeCredit)).ToList();
        }

        public IList<OrderPurchase> GetsObjectCodeCredit(string[] objectCodeCredit,DateTime? startTime,DateTime? endTime,string Type)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetByObjectCodeCredit(objectCodeCredit, startTime, endTime, Type)).ToList();
        }

        public IList<OrderPurchase> GetsObjectCodeDebit(string[] objectCodeDebit, DateTime? startTime, DateTime? endTime,string Type)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetByObjectCodeDebit(objectCodeDebit,startTime, endTime, Type)).ToList();
        }

        public OrderPurchase GetById(int Id)
        {
            return orderPurchaseRepository.FindById(Id);
        }

        public void Update(OrderPurchase orderPurchase)
        {
            orderPurchaseRepository.Update(orderPurchase);
        }

        public IList<OrderPurchase> GetBuyObjectCodeCredits(string objectCodeCredits,DateTime? startTime,DateTime? endTime)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetByObjectCodeCredit(objectCodeCredits, startTime,endTime)).ToList();
        }

        public IList<OrderPurchase> GetBuyObjectCodeDebits(string objectCodeDebits, DateTime? startTime, DateTime? endTime)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetByObjectCodeDebit(objectCodeDebits, startTime, endTime)).ToList();
        }

        public IList<OrderPurchase> GetCodes(string[] codes)
        {
            return orderPurchaseRepository.Find(new OrderPurchaseGetByCodes(codes)).ToList();
        }

        public IList<OrderPurchase> GetByLogIds(int[] logIds, params int[] syncStatuses)
        {
            var spec = new Specification<OrderPurchase>(m => true)
                   .And(new OrderPurchaseGetByLogIds(logIds))
                   .And(new OrderPurchaseGetBySyncStatuses(syncStatuses));

            return orderPurchaseRepository.Find(spec).ToList();
        }

        public bool HasLogIdAndSyncStatus(int logId, params int[] syncStatuses)
        {
            var spec = new Specification<OrderPurchase>(m => true)
                   .And(new OrderPurchaseGetByLogId(logId))
                   .And(new OrderPurchaseGetBySyncStatuses(syncStatuses));

            return orderPurchaseRepository.Find(spec).Any();
        }

        public OrderPurchase GetByLogId(int logId)
        {
            return orderPurchaseRepository.FindSingleBySpec(new OrderPurchaseGetByLogId(logId));
        }

        public void Delete(OrderPurchase model) => orderPurchaseRepository.Delete(model);
    }
}
