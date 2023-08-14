namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class WithDrawalAddRequest
    {
        public long Amount { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string Branch { get; set; }
        public string Province { get; set; }
        public string Note { get; set; }
    }
}
