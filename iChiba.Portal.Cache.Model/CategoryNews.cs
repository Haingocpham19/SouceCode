using ProtoBuf;
using System;

namespace iChiba.Portal.Cache.Model
{
    [ProtoContract]
    public  class CategoryNews
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Title { get; set; }
        [ProtoMember(3)]
        public string Description { get; set; }
        [ProtoMember(4)]
        public string Code { get; set; }
        [ProtoMember(5)]
        public string Url { get; set; }
        [ProtoMember(6)]
        public string Image { get; set; }
        [ProtoMember(7)]
        public string CreatedBy { get; set; }
        [ProtoMember(8)]
        public DateTime? CreatedDate { get; set; }
        [ProtoMember(9)]
        public string ModifiedBy { get; set; }
        [ProtoMember(10)]
        public DateTime? ModifiedDate { get; set; }
        [ProtoMember(11)]
        public int? Status { get; set; }
        [ProtoMember(12)]
        public int? Order { get; set; }
        [ProtoMember(13)]
        public string MetaTitle { get; set; }
        [ProtoMember(14)]
        public string MetaKeywords { get; set; }
        [ProtoMember(15)]
        public string MetaDescription { get; set; }
        [ProtoMember(16)]
        public int? Parent { get; set; }
    }
}
