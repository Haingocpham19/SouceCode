using iChiba.Portal.Common;
using System;
using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class CustomerAddress
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string Ward { get; set; }
        public string Note { get; set; }
        public string PostalCode { get; set; }
        public bool Active { get; set; }
        public bool IsOrderReceive { get; set; } = false;
        public IList<Location> ProvinceList { get; set; }
        public IList<Location> DistrictList { get; set; }
        public IList<Location> WardList { get; set; }
        public CustomerAddress()
        {
            ProvinceList = new List<Location>();
            DistrictList = new List<Location>();
            WardList = new List<Location>();
        }
    }
}
