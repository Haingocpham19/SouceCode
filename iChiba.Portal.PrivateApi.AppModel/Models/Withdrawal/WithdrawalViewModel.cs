using System;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class WithdrawalViewModel
    {
        public int Id { get; set; }
        public long Amount { get; set; }
        public long? Fee { get; set; }
        public string AccountId { get; set; }
        public string BankNumber { get; set; }
        public string BankAccountName { get; set; }
        public string BankName { get; set; }
        public string BankProvince { get; set; }
        public string BankBranch { get; set; }
        public DateTime CreatedDate { get; set; }
        public int WithDrawalStatus { get; set; }
        public int ConfirmStatus { get; set; }
        public string WalletId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ProcessDate { get; set; }
        public string Note { get; set; }
        public string ProofImage { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public string Code { get; set; }
        public string Ftcode { get; set; }
        public string WithDrawalType { get; set; }
        public string BankContent { get; set; }
        public DateTime? BankDate { get; set; }
        public string CreateDateStr { get; set; }
    }

    public class WithdrawalHistoryViewModel
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedDateDisplay { get; set; }
        public string DayOfWeek { get; set; }
        public List<WithdrawalViewModel> Withdrawals { get; set; }
    }
}
