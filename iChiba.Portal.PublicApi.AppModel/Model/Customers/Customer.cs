using System;
using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class Customer
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public string TranCode { get; set; }
        public bool? TranActive { get; set; }
        public string Phone { get; set; }
        public int? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string Avatar { get; set; }
        public string IdImages { get; set; }
        public string IdName { get; set; }
        public string IdImageFront { get; set; }
        public string IdImageBack { get; set; }
        public bool BypassSignEContract { get; set; }
        public string Area { get; set; }

        public IList<SurveyShippingRoute> SurveyShippingRoutes { get; set; }

        public IList<SurveyProductTypeGroup> SurveyProductTypeGroups { get; set; }

        public IList<ShippingRoute> ShippingRoutes { get; set; }

        public IList<ProductTypeGroup> ProductTypeGroups { get; set; }

        public Customer()
        {
            SurveyShippingRoutes = new List<SurveyShippingRoute>();
            SurveyProductTypeGroups = new List<SurveyProductTypeGroup>();
            ShippingRoutes = new List<ShippingRoute>();
            ProductTypeGroups = new List<ProductTypeGroup>();
        }
    }
}
