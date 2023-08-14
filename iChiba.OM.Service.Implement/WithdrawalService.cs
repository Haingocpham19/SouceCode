using Core.Common;
using Core.Specification.Abstract;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using iChiba.OM.Service.Interface;
using System;
using System.Collections.Generic;

namespace iChiba.OM.Service.Implement
{
    public class WithdrawalService : IWithdrawalService
    {
        private readonly IWithdrawalRepository _withdrawalRepository;

        public WithdrawalService(IWithdrawalRepository withdrawalRepository)
        {
            _withdrawalRepository = withdrawalRepository;
        }

        public IEnumerable<Withdrawal> GetByAccountId(string accountId, Sorts sorts = null, Paging paging = null)
        {
            var spec = new Specification<Withdrawal>(
                m => !string.IsNullOrEmpty(accountId) && m.AccountId == accountId
            );

            return _withdrawalRepository.Find(spec, sorts, paging);
        }

        public IEnumerable<Withdrawal> GetListWithdrawal(string accountId, DateTime? fromDate, DateTime? toDate, int? status, Sorts sorts = null, Paging paging = null)
        {
            var spec = new Specification<Withdrawal>(
                m => !string.IsNullOrEmpty(accountId) && m.AccountId == accountId
                && (fromDate == null || m.CreatedDate >= fromDate)
                && (toDate == null || m.CreatedDate <= toDate)
                && (status == null || m.WithDrawalStatus == status)
            );

            return _withdrawalRepository.Find(spec, sorts, paging);
        }
    }
}
