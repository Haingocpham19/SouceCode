namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class CustomerAddressViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Note { get; set; }
        public bool Active { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string Ward { get; set; }
        public string PostalCode { get; set; }
        public string FullAddress => string.Join(", ", Address, Ward, District, Province);
    }
}
