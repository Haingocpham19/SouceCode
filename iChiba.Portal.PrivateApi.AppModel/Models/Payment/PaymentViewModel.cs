using System;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class PaymentViewModel
    {
        public int Id { get; set; }
        public string WalletId { get; set; }
        public string AccountId { get; set; }
        public long Amount { get; set; }
        public string RefCode { get; set; }
        public string Ref { get; set; }
        public string RefType { get; set; }
        public string PaymentType { get; set; }
        public string PaymentForm { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ProcessDate { get; set; }
        public string ApproveBy { get; set; }
        public DateTime? ApproveDate { get; set; }
        public string Type { get; set; }
        public bool? Refund { get; set; }
        public int? PayCount { get; set; }
        public string OrderType { get; set; }
        public string CreateDateStr { get; set; }
    }

    public class PaymentTransactionHistoryViewModel
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedDateDisplay { get; set; }
        public string DayOfWeek { get; set; }
        public List<PaymentViewModel> Payments { get; set; }
    }
}
