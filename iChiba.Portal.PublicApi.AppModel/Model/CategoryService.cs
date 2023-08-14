using iChiba.Portal.Common;
using System;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class CategoryService
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Parent { get; set; }
        public string Code { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? Status { get; set; }
        public int? Order { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string ImageFullUrl
        {
            get
            {
                return Utility.CreateFullFileUrl(Image);
            }
        }
    }
}
