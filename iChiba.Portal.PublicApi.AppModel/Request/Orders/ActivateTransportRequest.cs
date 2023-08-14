using System.Collections.Generic;
using iChiba.Portal.PublicApi.AppModel.Model;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class ActivateTransportRequest
    {
        public string IdImageFront { get; set; }

        public string IdImageBack { get; set; }

        public IList<SurveyShippingRoute> SurveyShippingRoutes { get; set; }

        public IList<SurveyProductTypeGroup> SurveyProductTypeGroups { get; set; }

        public ActivateTransportRequest()
        {
            SurveyShippingRoutes = new List<SurveyShippingRoute>();
            SurveyProductTypeGroups = new List<SurveyProductTypeGroup>();
        }
    }
}
