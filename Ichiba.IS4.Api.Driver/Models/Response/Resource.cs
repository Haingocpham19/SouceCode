using System.Collections.Generic;

namespace iChiba.IS4.Api.Driver.Models.Response
{
    public class Resource
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int? ParentId { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public IList<string> Actions { get; set; }
        public int? Ord { get; set; }
    }
}
