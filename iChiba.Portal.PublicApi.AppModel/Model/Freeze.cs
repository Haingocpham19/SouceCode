using System;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class Freeze
    {
        public int Id { get; set; }
        public long Amount { get; set; }
        public string Type { get; set; }
        public string Ref { get; set; }
        public int Status { get; set; }
        public string RefType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
