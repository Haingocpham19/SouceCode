using System;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class WithDrawal
    {
        public int Id { get; set; }
        public long Amount { get; set; }
        public string BankNumber { get; set; }
        public string BankAccountName { get; set; }
        public string BankName { get; set; }
        public string BankProvince { get; set; }
        public string BankBranch { get; set; }
        public DateTime CreatedDate { get; set; }
        public int WithDrawalStatus { get; set; }
        public int ConfirmStatus { get; set; }
        public string Note { get; set; }
    }
}
