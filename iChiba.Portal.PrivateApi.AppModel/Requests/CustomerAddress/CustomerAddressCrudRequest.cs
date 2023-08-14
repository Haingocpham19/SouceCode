namespace iChiba.Portal.PrivateApi.AppModel.Requests
{
    public class CustomerAddressAddRequest
    {
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
    }

    public class CustomerAddressUpdateRequest
    {
        public int Id { get; set; }
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
    }

    public class CustomerAddressDeleteRequest
    {
        public int Id { get; set; }
    }
}
