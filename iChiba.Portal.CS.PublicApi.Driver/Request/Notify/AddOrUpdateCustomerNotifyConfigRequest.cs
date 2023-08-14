namespace iChiba.Portal.CS.PublicApi.Driver.Request
{
    public class AddOrUpdateCustomerNotifyConfigRequest
    {
        public string AppId { get; set; }
        public string AccountId { get; set; }
        public string NotifyConfigCode { get; set; }
        public bool SendEmail { get; set; }
        public bool SendWeb { get; set; }
        public bool SendMobile { get; set; }
        public bool SendDesktop { get; set; }
    }
}