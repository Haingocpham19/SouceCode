using Core.Common;
using Core.Specification.Abstract;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using iChiba.OM.Service.Interface;
using iChiba.Portal.Common;
using System;
using System.Collections.Generic;

namespace iChiba.OM.Service.Implement
{
    public class DepositsService : IDepositsService
    {
        private readonly IDepositsRepository _depositsRepository;

        public DepositsService(IDepositsRepository depositsRepository)
        {
            _depositsRepository = depositsRepository;
        }

        public IEnumerable<Deposits> GetByAccountId(string accountId, Sorts sorts = null, Paging paging = null)
        {
            var spec = new Specification<Deposits>(
                m => !string.IsNullOrEmpty(accountId) && m.AccountId == accountId
                && m.DepositType != DepositType.REFUND
            );

            return _depositsRepository.Find(spec, sorts, paging);
        }

        public IEnumerable<Deposits> GetListDeposits(string accountId, DateTime? fromDate, DateTime? toDate, int? status, Sorts sorts = null, Paging paging = null)
        {
            var spec = new Specification<Deposits>(
                m => !string.IsNullOrEmpty(accountId) && m.AccountId == accountId
                && m.DepositType != DepositType.REFUND
                && (fromDate == null || m.CreatedDate >= fromDate)
                && (toDate == null || m.CreatedDate <= toDate)
                && (status == null || m.DepositStatus == status)
            );

            return _depositsRepository.Find(spec, sorts, paging);
        }
    }
}
