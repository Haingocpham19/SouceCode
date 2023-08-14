namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class Location
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? Parent { get; set; }
    }
}
