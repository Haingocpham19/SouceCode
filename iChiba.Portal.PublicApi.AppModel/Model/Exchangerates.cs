using iChiba.Portal.Common;
using System;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public partial class Exchangerates
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double? Buy { get; set; }
        public double? Transfer { get; set; }
        public double? Sell { get; set; }
        public double? Add { get; set; }
    }
}
