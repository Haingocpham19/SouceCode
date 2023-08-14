using iChiba.Portal.Common;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class AdvBanner
    {        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public int PositionId { get; set; }
        public int Order { get; set; }
        public string Image { get; set; }
        //public string ImageFullLink => Constant.CDN_BEFORE_FULL_LINK + Image;
        public string ImageFullLink
        {
            get
            {
                return Utility.CreateFullFileUrl(Image);
            }
        }
    }
}
