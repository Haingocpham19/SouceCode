using System;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class Deposit
    {
        public int Id { get; set; }
        public long Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string BankName { get; set; }
        public string BankDescription { get; set; }
        public string BankNumber { get; set; }
        public string PayImage { get; set; }
        public int PayStatus { get; set; }
        public int ConfirmStatus { get; set; }
        public string DepositType { get; set; }
        public string CustomerBankName { get; set; }
        public string CustomerBankNumber { get; set; }
        public string CustomerBankOwner { get; set; }
        public DateTime? CustomerTranDate { get; set; }
        public string CustomerTranCode { get; set; }
        public string Note { get; set; }
        public string PayImageFullUrl => Common.Utility.CreateFullFileUrl(PayImage);
    }
}
