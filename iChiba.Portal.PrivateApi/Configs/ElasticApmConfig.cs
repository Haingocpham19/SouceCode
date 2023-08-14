namespace iChiba.Portal.PrivateApi.Configs
{
    public class ElasticApmConfig
    {
        public string SecretToken { get; set; }
        public bool Active { get; set; }
        public string ServerUrls { get; set; }
        public string ServiceName { get; set; }
    }
}
