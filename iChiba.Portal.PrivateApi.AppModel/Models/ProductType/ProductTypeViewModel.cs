using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class ProductTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? GroupId { get; set; }
        public long? PriceStandardUs { get; set; }
        public long? PriceStandardJp { get; set; }
        public long? PriceStandardKr { get; set; }
        public long? PriceStandardUk { get; set; }
        public long? PriceStandardGe { get; set; }
    }

    public class ProductTypeList
    {
        public List<ProductTypeViewModel> ProductTypes { get; set; }
        public List<ProductTypeGroupViewModel> ProductTypeGroups { get; set; }
    }
}
