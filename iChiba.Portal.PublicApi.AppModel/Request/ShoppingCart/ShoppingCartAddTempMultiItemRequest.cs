    using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class ShoppingCartAddTempMultiItemRequest
    {
        public IList<ShoppingCartAddTempRequest> Items { get; set; }
    }
}
