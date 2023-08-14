using iChiba.Portal.Common;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class Bankic
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string BankFullName { get; set; }
        public string Picture { get; set; }
        public string Icon { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string Branch { get; set; }
        public string Province { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public string ImageFullUrl => Utility.CreateFullFileUrl(Picture);
    }
}
