using System.Collections.Generic;
using iChiba.Portal.PublicApi.AppModel.Model;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class UpdateSurveyRequest
    {
        public IList<SurveyShippingRoute> SurveyShippingRoutes { get; set; }

        public IList<SurveyProductTypeGroup> SurveyProductTypeGroups { get; set; }

        public UpdateSurveyRequest()
        {
            SurveyShippingRoutes = new List<SurveyShippingRoute>();
            SurveyProductTypeGroups = new List<SurveyProductTypeGroup>();
        }
    }
}
