using System;
using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
