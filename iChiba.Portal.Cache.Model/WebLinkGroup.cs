using ProtoBuf;
using System;
using System.Collections.Generic;

namespace iChiba.Portal.Cache.Model
{
    [ProtoContract]
    public class WebLinkGroup
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
        public string Image { get; set; }
        [ProtoMember(6)]
        public string CreatedBy { get; set; }
        [ProtoMember(7)]
        public DateTime CreatedDate { get; set; }
        [ProtoMember(8)]
        public string ModifiedBy { get; set; }
        [ProtoMember(9)]
        public DateTime? ModifiedDate { get; set; }
        [ProtoMember(10)]
        public int? Order { get; set; }
        //[ProtoMember(11)]
    }
}
