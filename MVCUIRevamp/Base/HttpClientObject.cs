using System.Net.Http;

namespace RithV.FX.Base
{
    public class HttpClientObject : IHttpClientObject
    {

        public ApiClientContext GetClient()
        {
            var apiClientContex =
                ApiClientContext.Create(cfg =>
                    cfg.SetCredentialsFromAppSetting().ConnectTo(), "Default");

            return apiClientContex;
        }

        public ApiClientContext GetClient(string userName, string password)
        {
            var apiClientContex =
                ApiClientContext.Create(cfg =>
                    cfg.SetCredentialsFromAppSetting(userName, password).ConnectTo(), "Default");

            return apiClientContex;
        }

        public ApiClientContext GetClient(string userName, string password, string baseUrl)
        {
            var apiClientContex =
                ApiClientContext.Create(cfg =>
                    cfg.SetCredentialsFromAppSetting(userName, password).ConnectTo(baseUrl), "Default");

            return apiClientContex;

        }


        public ApiClientContext GetClient(string userName, string password, string baseUrl, string objType)
        {
            var apiClientContex =
                ApiClientContext.Create(cfg =>
                    cfg.SetCredentialsFromAppSetting(userName, password).ConnectTo(baseUrl), objType);

            return apiClientContex;
        }


        public HttpClient GetHttpClient()
        {
            object client;
            if (ApiClientContext._clients.Value.IsEmpty) GetClient();
            ApiClientContext._clients.Value.TryGetValue("Default", out client);

            return (HttpClient)client;
        }


        public HttpClient GetHttpLoginClient()
        {
            object client;
            ApiClientContext._clients.Value.TryGetValue("Default", out client);
            return (HttpClient)client;
        }
    }
}