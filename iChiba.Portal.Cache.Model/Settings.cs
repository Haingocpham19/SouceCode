using ProtoBuf;
using System;

namespace iChiba.Portal.Cache.Model
{
    [ProtoContract]
    public class Settings
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Key { get; set; }
        [ProtoMember(3)]
        public string Description { get; set; }
        [ProtoMember(4)]
        public string Body { get; set; }
        [ProtoMember(5)]
        public string CreatedBy { get; set; }
        [ProtoMember(6)]
        public DateTime? CreatedDate { get; set; }
        [ProtoMember(7)]
        public string ModifiedBy { get; set; }
        [ProtoMember(8)]
        public DateTime? ModifiedDate { get; set; }
    }
}
