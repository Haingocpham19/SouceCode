using ProtoBuf;
using System;

namespace iChiba.Portal.Cache.Model
{
    [ProtoContract]
    public class Exchangerates
    {
        [ProtoMember(1)]
        public string Code { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public double? Buy { get; set; }
        [ProtoMember(4)]
        public double? Transfer { get; set; }
        public string Body { get; set; }
        [ProtoMember(5)]
        public double? Sell { get; set; }
        [ProtoMember(6)]
        public double? Add { get; set; }
    }
}
