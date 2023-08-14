using Core.Common;
using Core.Specification.Abstract;
using iChiba.WH.Model;
using iChiba.WH.Repository.Interface;
using iChiba.WH.Service.Interface;
using iChiba.WH.Specification.Implement;
using System.Collections.Generic;
using System.Linq;

namespace iChiba.WH.Service.Implement
{
    public class PackageDetailQuoteService : IPackageDetailQuoteService
    {
        private readonly IPackageDetailQuoteRepository _packageDetailQuoteRepository;

        public PackageDetailQuoteService(IPackageDetailQuoteRepository packageDetailQuoteRepository)
        {
            _packageDetailQuoteRepository = packageDetailQuoteRepository;
        }

        public IEnumerable<PackageDetailQuote> Gets(string accountId, string billCode, string poNumber, bool? paymentStatus, List<int> quoteType, int? status, Sorts sorts = null, Paging paging = null)
        {
            var spec = new Specification<PackageDetailQuote>(
                m => !string.IsNullOrEmpty(accountId) && m.CustomerId == accountId
                && (string.IsNullOrEmpty(billCode) || m.Code == billCode)
                && (string.IsNullOrEmpty(poNumber) || m.PoNumber == poNumber)
                && (paymentStatus == null || m.PaymentStatus == paymentStatus)
                && (quoteType == null || quoteType.Count <= 0 || quoteType.Contains(m.Type.Value))
                && (status == null || m.Status == status)
                && m.PackageDetail.Count > 0
            );
            return _packageDetailQuoteRepository.Find(spec, sorts, paging);
        }

        public PackageDetailQuote GetById(int id)
        {
            var spec = new Specification<PackageDetailQuote>(m => m.Id == id);
            return _packageDetailQuoteRepository.Find(spec).FirstOrDefault();
        }

        public IEnumerable<PackageDetailQuote> GetById(List<int> ids)
        {
            var spec = new Specification<PackageDetailQuote>(m => ids != null && ids.Count > 0 && ids.Contains(m.Id));
            return _packageDetailQuoteRepository.Find(spec);
        }

        public PackageDetailQuote GetByCode(string code)
        {
            var spec = new Specification<PackageDetailQuote>(m => m.Code == code);
            return _packageDetailQuoteRepository.Find(spec).FirstOrDefault();
        }

        public IEnumerable<PackageDetailQuote> GetByCode(List<string> codes)
        {
            var spec = new Specification<PackageDetailQuote>(m => codes != null && codes.Count > 0 && codes.Contains(m.Code));
            return _packageDetailQuoteRepository.Find(spec);
        }
    }
}
