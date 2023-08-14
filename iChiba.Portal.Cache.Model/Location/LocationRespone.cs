using System.Collections.Generic;

namespace iChiba.Portal.Cache.Model
{
    public class LocationResponse
    {
        public ResultLocation Result { get; set; }
    }

    public class ResultLocation
    {
        public Location Location { get; set; }
    }

    public class LocationList
    {
        public CurrentLocation Current { get; set; }
        public ChildrenLocation Children { get; set; }
    }

    public class CurrentLocation
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string IsAdult { get; set; }
    }

    public class ChildrenLocation
    {
        public IList<ChildrenItemLocation> ChildrenItem { get; set; }
    }

    public class ChildrenItemLocation
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string IsAdult { get; set; }
    }

}
