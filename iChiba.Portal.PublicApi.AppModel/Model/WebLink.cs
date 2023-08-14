using iChiba.Portal.Common;
using System;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class WebLink
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
        public string Route { get; set; }

        public string ImageFullUrl
        {
            get
            {
                return Utility.CreateFullFileUrl(Image);
            }
        }
    }
}
