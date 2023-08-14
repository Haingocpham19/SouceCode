using System.Text.RegularExpressions;

namespace iChiba.Portal.Common.Helpers
{
    public class OrderHelper
    {
        public static Regex RegexTracking = new Regex(@"^[a-zA-Z0-9]{6,60}$");
    }
}
