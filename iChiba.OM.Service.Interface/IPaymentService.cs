using Core.Common;
using iChiba.OM.Model;
using System;
using System.Collections.Generic;

namespace iChiba.OM.Service.Interface
{
    public interface IPaymentService
    {
        IEnumerable<Payment> GetByAccountId(string accountId, Sorts sorts = null, Paging paging = null);
        IEnumerable<Payment> GetListPayment(string accountId, DateTime? fromDate, DateTime? toDate, bool? isRefund, int? status, Sorts sorts = null, Paging paging = null);
    }
}
