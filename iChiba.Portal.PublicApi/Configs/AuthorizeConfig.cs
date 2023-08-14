namespace iChiba.Portal.PublicApi.Configs
{
    public class AuthorizeConfig
    {
        public string Issuer { get; set; }
        public bool RequireHttpsMetadata { get; set; }
        public string ApiName { get; set; }
    }
}
