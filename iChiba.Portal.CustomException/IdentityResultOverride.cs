using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.CustomException
{
    public class IdentityResultOverride
    {
        public static IdentityResultOverride Success { get; }
        public bool Succeeded { get; set; }
        public IEnumerable<IdentityError> Errors { get; set; }
    }

    public class IdentityError
    { 
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
