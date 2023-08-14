using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.ExtensionApi.AppModel.Request
{
    public class ShoppingListIdRequest
    {
        public List<string> ListId { get; set; }
    }
    public class ShoppingItemIdRequest
    {
        public string Id { get; set; }
    }
}
