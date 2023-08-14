namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class DepositAddRequest
    {
        public long Amount { get; set; }
        public string BankName { get; set; }
        public string BankNumber { get; set; }
        public string CustomerBankName { get; set; }
        public string CustomerBankNumber { get; set; }
        public string CustomerBankOwner { get; set; }
    }
}
