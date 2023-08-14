using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Models;

namespace iChiba.Portal.PrivateApi.AppModel.Responses
{
    public class EmployeeResponse : BaseEntityResponse<EmployeeViewModel>
    {
        public EmployeeResponse()
        {
            Data = new EmployeeViewModel();
        }
    }
}
