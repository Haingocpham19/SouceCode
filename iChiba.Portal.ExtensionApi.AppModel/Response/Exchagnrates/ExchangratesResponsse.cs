using Core.AppModel.Response;
using iChiba.Portal.ExtensionApi.AppModel.Model;
using System.Collections.Generic;

namespace iChiba.Portal.ExtensionApi.AppModel.Response
{
    public class ExchangratesResponsse : BaseEntityResponse<IList<ExchangeratesViewModel>>
    {
        public ExchangratesResponsse()
        {
            Data = new List<ExchangeratesViewModel>();
        }
    }
}
