using System;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class DepositUpdatePayImageRequest
    {
        public int Id { get; set; }
        public string PayImage { get; set; }
        public string CustomerTranCode { get; set; }
        public DateTime? CustomerTranDate { get; set; }
    }
}
