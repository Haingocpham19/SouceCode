using ProtoBuf;

namespace iChiba.Portal.Cache.Model
{
    [ProtoContract]
    public class Metaconfig
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Page { get; set; }
        [ProtoMember(3)]
        public string MetaTitle { get; set; }
        [ProtoMember(4)]
        public string MetaKeywords { get; set; }
        [ProtoMember(5)]
        public string MetaDescription { get; set; }
    }
}
