using System;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class OrderMessageViewModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Message { get; set; }
        public string Action { get; set; }
        public int OrderId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AuthorDisplay { get; set; }
        public string CreatedDateDisplay => CreatedDate.ToString("dd/MM/yyyy HH:mm:ss");
    }
}
