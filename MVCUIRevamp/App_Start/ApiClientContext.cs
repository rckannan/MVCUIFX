using RithV.FX.Base;
using System;
using System.Collections.Concurrent;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace RithV.FX
{
    public sealed class ApiClientContext
    {
        internal static readonly Lazy<ConcurrentDictionary<string, object>> _clients = new Lazy<ConcurrentDictionary<string, object>>(() => new ConcurrentDictionary<string, object>(), true);
        private static readonly Lazy<HttpClient> _httpClient = new Lazy<HttpClient>(delegate
        {
            HttpClient httpClient = HttpClientFactory.Create(new DelegatingHandler[]
            {
                new CompressionHandler(),
                new DecompressionHandler()
            });
            string uriString = ConfigurationManager.AppSettings["BaseURL"];
            httpClient.BaseAddress = new Uri(uriString);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8"));
            httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            return httpClient;
        }, true);
        internal ConcurrentDictionary<string, object> Clients
        {
            get
            {
                return ApiClientContext._clients.Value;
            }
        }
        internal Uri BaseUri
        {
            get;
            set;
        }
        internal string AuthorizationValue
        {
            get;
            set;
        }
        internal string AffiliateKey
        {
            get;
            set;
        }
        internal HttpClient HttpClient
        {
            get
            {
                if (!ApiClientContext._httpClient.IsValueCreated)
                {
                    this.InitializeHttpClient();
                }
                return ApiClientContext._httpClient.Value;
            }
        }
        private ApiClientContext()
        {
        }
        public static ApiClientContext Create(Action<ApiClientConfigurationExpression> action, string clientType)
        {
            ApiClientContext apiClientContext = new ApiClientContext();
            ApiClientConfigurationExpression obj = new ApiClientConfigurationExpression(apiClientContext);
            action(obj);
            ApiClientContext._clients.Value.AddOrUpdate(clientType, apiClientContext.HttpClient, (string s, object context) => context);
            return apiClientContext;
        }
        private void InitializeHttpClient()
        {
            if (this.BaseUri == null)
            {
                throw new ArgumentNullException("BaseUri");
            }
            if (string.IsNullOrEmpty(this.AuthorizationValue))
            {
                throw new ArgumentNullException("AuthorizationValue");
            }
            ApiClientContext._httpClient.Value.BaseAddress = this.BaseUri;
            ApiClientContext._httpClient.Value.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", this.AuthorizationValue);
        }
    }

    public class ApiClientConfigurationExpression
    {
        private readonly ApiClientContext _apiClientContext;
        internal ApiClientConfigurationExpression(ApiClientContext apiClientContext)
        {
            if (apiClientContext == null)
            {
                throw new ArgumentNullException("apiClientContext");
            }
            this._apiClientContext = apiClientContext;
        }
        public ApiClientConfigurationExpression SetCredentialsFromAppSetting(string usernameAppSettingKey, string passwordAppSettingKey)
        {
            this._apiClientContext.AuthorizationValue = ApiClientConfigurationExpression.EncodeToBase64(string.Format("{0}:{1}", usernameAppSettingKey, passwordAppSettingKey));
            return this;
        }
        public ApiClientConfigurationExpression SetCredentialsFromAppSetting()
        {
            string text = ConfigurationManager.AppSettings["LoginUser"];
            if (text == null)
            {
                throw new ArgumentNullException("LoginUser");
            }
            string text2 = ConfigurationManager.AppSettings["LoginPwd"];
            if (text2 == null)
            {
                throw new ArgumentNullException("LoginPwd");
            }
            string arg = text;
            string arg2 = text2;
            this._apiClientContext.AuthorizationValue = ApiClientConfigurationExpression.EncodeToBase64(string.Format("{0}:{1}", arg, arg2));
            return this;
        }
        public ApiClientConfigurationExpression ConnectTo(string baseUri)
        {
            if (string.IsNullOrEmpty(baseUri))
            {
                throw new ArgumentNullException("baseUri");
            }
            this._apiClientContext.BaseUri = new Uri(baseUri);
            return this;
        }
        public ApiClientConfigurationExpression ConnectTo()
        {
            string text = ConfigurationManager.AppSettings["BaseURL"];
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("baseurl");
            }
            this._apiClientContext.BaseUri = new Uri(text);
            return this;
        }
        private static string EncodeToBase64(string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }
    }
}