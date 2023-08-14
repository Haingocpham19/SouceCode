using System;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class ShipquocteNews
    {
        public string Title { get; set; }
        public string Sapo { get; set; }
        public string Picture { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
    }
}
