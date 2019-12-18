using System.Net.Http;
using System.Threading.Tasks;

namespace RithV.FX.Base
{
    public interface IHttpClientHelper
    {
        Task<ResultValue<T>> GetAsync<T>(string path);
        Task<ResultValue<T>> GetAsync<T>(HttpClient client, string path);
        ResultValue<T> Get<T>(string path);
        Task<ResultValue<T>> PostAsync<T>(string path, T reqObj);
        Task<ResultValue<T>> PostFilterAsync<TRq, T>(string path, TRq reqObj);
        Task<ResultValue<T>> PutAsync<T>(string path, T reqObj);
        Task<ResultValue<T>> DeleteAsync<T>(string path);
    }
}