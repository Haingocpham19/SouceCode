using Core.Specification.Abstract;
using iChiba.WH.Model;
using iChiba.WH.Repository.Interface;
using iChiba.WH.Service.Interface;
using System.Collections.Generic;

namespace iChiba.WH.Service.Implement
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;

        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public IEnumerable<Flight> GetById(List<int> ids)
        {
            var spec = new Specification<Flight>(m => ids != null && ids.Count > 0 && ids.Contains(m.Id));
            return _flightRepository.Find(spec);
        }
    }
}
