using ProtoBuf;
using System.Collections.Generic;
using System.Linq;

namespace iChiba.Portal.Cache.Model
{
    [ProtoContract]
    public class LocationNode
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string Code { get; set; }

        [ProtoMember(3)]
        public int? Status { get; set; }

        [ProtoMember(4)]
        public LocationNode Parent { get; set; }

        [ProtoMember(5)]
        public IList<LocationNode> Childs { get; set; }

        private IList<LocationNode> allMembers;
        private IList<LocationNode> AllMembers
        {
            get
            {
                if (allIdMembers != null
                    && allIdMembers.Any())
                {
                    return allMembers;
                }

                allMembers = GetAllMembers(this);

                return allMembers;
            }
        }

        private IList<int> allIdMembers;
        public IList<int> AllIdMembers
        {
            get
            {
                if (allIdMembers != null 
                    && allIdMembers.Any())
                {
                    return allIdMembers;
                }

                allIdMembers = AllMembers.Select(m => m.Id)
                    .ToList();

                return allIdMembers;
            }
        }

        private IList<string> allCodeMembers;
        public IList<string> AllCodeMembers
        {
            get
            {
                if (allCodeMembers != null
                    && allCodeMembers.Any())
                {
                    return allCodeMembers;
                }

                allCodeMembers = AllMembers.Select(m => m.Code)
                    .ToList();

                return allCodeMembers;
            }
        }

        public LocationNode()
        {
            Childs = new List<LocationNode>();
        }

        private IList<LocationNode> GetAllMembers(LocationNode node)
        {
            IList<LocationNode> results = new List<LocationNode>();

            results.Add(node);

            if (node.Parent != null)
            {
                results.Add(node.Parent);
            }

            node.Childs
               .Select(m => GetAllMembers(m))
               .SelectMany(m => m)
               .ToList()
               .ForEach(m => results.Add(m));

            return results;
        }
    }
}
