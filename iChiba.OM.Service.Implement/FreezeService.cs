using Core.Common;
using Core.Specification.Abstract;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using iChiba.OM.Service.Interface;
using System;
using System.Collections.Generic;

namespace iChiba.OM.Service.Implement
{
    public class FreezeService : IFreezeService
    {
        private readonly IFreezeRepository _freezeRepository;

        public FreezeService(IFreezeRepository freezeRepository)
        {
            _freezeRepository = freezeRepository;
        }

        public IEnumerable<Freeze> GetByAccountId(string accountId, Sorts sorts = null, Paging paging = null)
        {
            var spec = new Specification<Freeze>(
                m => !string.IsNullOrEmpty(accountId) && m.AccountId == accountId
            );

            return _freezeRepository.Find(spec, sorts, paging);
        }

        public IEnumerable<Freeze> GetListFreeze(string accountId, DateTime? fromDate, DateTime? toDate, int? status, Sorts sorts = null, Paging paging = null)
        {
            var spec = new Specification<Freeze>(
                m => !string.IsNullOrEmpty(accountId) && m.AccountId == accountId
                && (fromDate == null || m.CreatedDate >= fromDate)
                && (toDate == null || m.CreatedDate <= toDate)
                && (status == null || m.Status == status)
            );

            return _freezeRepository.Find(spec, sorts, paging);
        }
    }
}
