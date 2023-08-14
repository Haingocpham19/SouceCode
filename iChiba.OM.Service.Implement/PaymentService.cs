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
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public IEnumerable<Payment> GetByAccountId(string accountId, Sorts sorts = null, Paging paging = null)
        {
            var spec = new Specification<Payment>(m => !string.IsNullOrEmpty(accountId) && m.AccountId == accountId);
            return _paymentRepository.Find(spec, sorts, paging);
        }

        public IEnumerable<Payment> GetListPayment(string accountId, DateTime? fromDate, DateTime? toDate, bool? isRefund, int? status, Sorts sorts = null, Paging paging = null)
        {
            var spec = new Specification<Payment>(
                m => !string.IsNullOrEmpty(accountId) && m.AccountId == accountId
                && m.Status != PaymentStatus.WaitProcess.GetHashCode()
                && (fromDate == null || m.CreatedDate >= fromDate)
                && (toDate == null || m.CreatedDate <= toDate)
                && (isRefund == null || (isRefund == true && m.Refund == true) || (isRefund == false && (m.Refund == false || m.Refund == null)))
                && (status == null || m.Status == status)
            );
            return _paymentRepository.Find(spec, sorts, paging);
        }
    }
}
