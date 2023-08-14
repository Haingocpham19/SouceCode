namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public partial class SurveyProductTypeGroup
    {
        public string Id { get; set; }

        public int CustomerId { get; set; }

        public string UserId { get; set; }

        public int ProductTypeGroupId { get; set; }

        public bool Active { get; set; }

        public int DisplayOrder { get; set; }

        public Customer Customer { get; set; }

        public ProductTypeGroup ProductTypeGroup { get; set; }
    }
}
