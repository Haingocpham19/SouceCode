using System;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class ProfileUpdateRequest
    {
        public string Username { get; set; } 
        public string Email { get; set; }
        public string PhoneNumber { get; set; } 
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; } 
    }
}
