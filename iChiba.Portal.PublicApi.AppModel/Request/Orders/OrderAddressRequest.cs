using Core.AppModel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class OrderAddressRequest 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
    }
}
