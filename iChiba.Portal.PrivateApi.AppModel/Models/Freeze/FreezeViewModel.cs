using System;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class FreezeViewModel
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public string WalletId { get; set; }
        public long Amount { get; set; }
        public string Type { get; set; }
        public string Ref { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string RefType { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreateDateStr { get; set; }
    }

    public class FreezeHistoryViewModel
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedDateDisplay { get; set; }
        public string DayOfWeek { get; set; }
        public List<FreezeViewModel> Freezes { get; set; }
    }
}
