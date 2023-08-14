using AutoMapper;
using iChiba.OM.Model;
using iChiba.Portal.PrivateApi.AppModel.Models;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class EmployeeAdapter
    {
        public static EmployeeViewModel ToModel(this Employee model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Employee, EmployeeViewModel>(model);
        }
    }
}
