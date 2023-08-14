﻿using iChiba.Portal.Common;
using System;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class Guidelines
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public int? Order { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public int? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? GroupId { get; set; }
        public string ImageFullUrl
        {
            get
            {
                return Utility.CreateFullFileUrl(Image);
            }
        }
    }
}
