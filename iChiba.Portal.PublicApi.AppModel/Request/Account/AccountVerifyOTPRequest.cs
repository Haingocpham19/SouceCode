namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class AccountVerifyOTPRequest
    {
        public string Code { get; set; }
        public string State { get; set; }
        public bool IsPhone { get; set; }
        public string AppId { get; set; }
        public string AccountKitAppSecret { get; set; }
        public string AccountKitVersion { get; set; }
    }
}
