using System;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class DepositsViewModel
    {
        public int Id { get; set; }
        public long Amount { get; set; }
        public int DepositStatus { get; set; }
        public string AccountId { get; set; }
        public DateTime? BankDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Ftcode { get; set; }
        public string BankName { get; set; }
        public string BankDescription { get; set; }
        public string BankNumber { get; set; }
        public string BankContent { get; set; }
        public int PayStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ProcessDate { get; set; }
        public int ConfirmStatus { get; set; }
        public string DepositType { get; set; }
        public string WalletId { get; set; }
        public string State { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public string Ref { get; set; }
        public DateTime? CustomerTranDate { get; set; }
        public string CustomerTranCode { get; set; }
        public string ConfirmBy { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public string CreateDateStr { get; set; }
    }

    public class DepositsHistoryViewModel
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedDateDisplay { get; set; }
        public string DayOfWeek { get; set; }
        public List<DepositsViewModel> Deposits { get; set; }
    }
}
