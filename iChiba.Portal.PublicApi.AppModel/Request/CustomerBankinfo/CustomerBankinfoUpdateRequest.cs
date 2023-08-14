using System;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class CustomerBankinfoUpdateRequest
    {
        public int Id { get; set; }
        public string BankAccountName { get; set; }
        public string BankNumber { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string BankProvince { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string BankType { get; set; }
    }
}
