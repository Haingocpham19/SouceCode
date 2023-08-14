using iChiba.Portal.Common;
using System;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public partial class Settings
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
