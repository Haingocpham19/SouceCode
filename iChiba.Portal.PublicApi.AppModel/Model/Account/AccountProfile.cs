using System;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class AccountProfile
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsPhoneNumberConfirmed { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime? Birthday { get; set; }
    }

    public class UserResponse
    {
        public string id { get; set; }
        public PhoneResponse phone { get; set; }
        public EmailResponse email { get; set; }
        public ApplicationResponse application { get; set; }
    }
    public class PhoneResponse
    {
        public string number { get; set; }
        public string country_prefix { get; set; }
        public string national_number { get; set; }
    }

    public class EmailResponse
    {
        public string address { get; set; }
    }

    public class ApplicationResponse
    {
        public string id { get; set; }
    }
}
