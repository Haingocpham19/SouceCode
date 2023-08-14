using System;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class Advisory
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Supported { get; set; }
    }
}
