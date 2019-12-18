using System.Net.Http;

namespace RithV.FX.Base
{
    public interface IHttpClientObject
    {
        ApiClientContext GetClient();
        ApiClientContext GetClient(string userName, string password);
        ApiClientContext GetClient(string userName, string password, string baseUrl);
        ApiClientContext GetClient(string userName, string password, string baseUrl, string objType);
        HttpClient GetHttpClient();
        HttpClient GetHttpLoginClient();
    }
}