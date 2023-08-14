using Core.Resilience.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.IS4.Api.Driver.Models.Response;

namespace iChiba.IS4.Api.Driver
{
    public class AccessConfig
    {
        public string GetResources { get; set; }
        public string CheckPermission { get; set; }
    }

    public class AccessClient : BaseClient
    {
        private readonly AccessConfig _accessConfig;

        public AccessClient(IHttpClient httpClient,
            IAuthorizeClient authorizeClient,
            AccessConfig accessConfig)
            : base(httpClient, authorizeClient)
        {
            _accessConfig = accessConfig;
        }

        public async Task<IList<Resource>> GetResources(string groupResourceKey)
        {
            var url = $"{_accessConfig.GetResources}/{groupResourceKey}";
            var response = await Get<IList<Resource>>(url);

            return response;
        }

        public async Task<bool> CheckPermission(string groupResourceKey, string resourceKey, params string[] actions)
        {
            var action = string.Join(',', actions);
            var url = $"{_accessConfig.CheckPermission}/{groupResourceKey}/{resourceKey}/{action}";
            var response = await Get<bool>(url);

            return response;
        }
    }
}
