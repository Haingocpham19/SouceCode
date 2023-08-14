using System;
using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class WebLinkGroup
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public int GroupId { get; set; }
        public int Order { get; set; }
        public string Image { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string WeblinkGroupID { get; set; }
        public string Type { get; set; }

        public virtual IList<WebLink> Weblinks { get; set; }

        public WebLinkGroup()
        {
            Weblinks = new List<WebLink>();
        }
    }
}
