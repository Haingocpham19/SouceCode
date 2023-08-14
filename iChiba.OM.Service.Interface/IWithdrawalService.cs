using Core.Common;
using iChiba.OM.Model;
using System;
using System.Collections.Generic;

namespace iChiba.OM.Service.Interface
{
    public interface IWithdrawalService
    {
        IEnumerable<Withdrawal> GetByAccountId(string accountId, Sorts sorts = null, Paging paging = null);
        IEnumerable<Withdrawal> GetListWithdrawal(string accountId, DateTime? fromDate, DateTime? toDate, int? status, Sorts sorts = null, Paging paging = null);
    }
}
