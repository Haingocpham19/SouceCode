using ProtoBuf;
using System;

namespace iChiba.Portal.Cache.Model
{
    [ProtoContract]
    public  class Recruitment
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Title { get; set; }
        [ProtoMember(3)]
        public string Description { get; set; }
        [ProtoMember(4)]
        public string Body { get; set; }
        [ProtoMember(5)]
        public string Image { get; set; }
        [ProtoMember(6)]
        public string MetaTitle { get; set; }
        [ProtoMember(7)]
        public string MetaKeywords { get; set; }
        [ProtoMember(8)]
        public string MetaDescription { get; set; }
        [ProtoMember(9)]
        public int? Status { get; set; }
        [ProtoMember(10)]
        public string CreatedBy { get; set; }
        [ProtoMember(11)]
        public DateTime? CreatedDate { get; set; }
        [ProtoMember(12)]
        public string ModifiedBy { get; set; }
        [ProtoMember(13)]
        public DateTime? ModifiedDate { get; set; }
    }
}
