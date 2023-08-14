using iChiba.Portal.Common;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class Bankinfo
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string BankFullName { get; set; }
        public string Picture { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string Branch { get; set; }
        public string Province { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public int? ForDeposit { get; set; }
        public int? ForWithDrawal { get; set; }
        public string BankType { get; set; }
        public string ImageFullUrl
        {
            get
            {
                return Utility.CreateFullFileUrl(Picture);
            }
        }
    }
}
