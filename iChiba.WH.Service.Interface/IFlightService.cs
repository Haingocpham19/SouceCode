using iChiba.WH.Model;
using System.Collections.Generic;

namespace iChiba.WH.Service.Interface
{
    public interface IFlightService
    {
        IEnumerable<Flight> GetById(List<int> ids);
    }
}
