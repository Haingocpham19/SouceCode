using AutoMapper;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.WH.Model;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class FlightAdapter
    {
        public static FlightViewModel ToModel(this Flight model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Flight, FlightViewModel>(model);
        }
    }
}
