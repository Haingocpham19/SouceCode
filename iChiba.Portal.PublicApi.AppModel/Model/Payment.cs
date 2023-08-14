using System;
using iChiba.Portal.Common;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class Payment
    {
        public int Id { get; set; }
        public string WalletId { get; set; }
        public string AccountId { get; set; }
        public long Amount { get; set; }
        public string Ref { get; set; }
        public string RefType { get; set; }
        public string RefCode { get; set; }
        public string PaymentType { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string PaymentForm { get; set; }
        public bool? Refund { get; set; }
        //PaymentForm == null ? "" : (PaymentForm.Contains("WALLET") ? PaymentForm + "-" + WalletId : PaymentForm);
        public string AmountDisplay => Amount.StringDisplayLong();
    } 
}
