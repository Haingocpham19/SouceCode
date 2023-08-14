using System.Linq;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class AspNetUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }

        public string DisplayInfo
        {
            get
            {
                var infos = new string[]
                { 
                    FullName, 
                    UserName, 
                    PhoneNumber, 
                    Email
                }
                .Where(item => !string.IsNullOrWhiteSpace(item)).ToArray();

                var display = string.Join(" - ", infos);

                return display;
            }
        }
    }
}
