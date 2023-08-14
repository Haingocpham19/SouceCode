using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Models;

namespace iChiba.Portal.PrivateApi.AppModel.Responses
{
    public class DebtResponse : BaseEntityResponse<DebtViewModel>
    {
        public DebtResponse()
        {
            Data = new DebtViewModel();
        }
    }
}
