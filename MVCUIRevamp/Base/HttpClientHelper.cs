using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;

namespace RithV.FX.Base
{
    public class HttpClientHelper : IHttpClientHelper
    {
        private readonly IHttpClientObject _httpClientObject;
        public HttpClientHelper(IHttpClientObject httpClientObject)
        {
            this._httpClientObject = httpClientObject;
        }
        public async Task<ResultValue<T>> GetAsync<T>(HttpClient client, string path)
        {
            ResultValue<T> outObject = null;
            try
            {
                HttpResponseMessage httpResponseMessage = await client.GetAsync(path);
                if (httpResponseMessage.StatusCode == HttpStatusCode.Found)
                {
                    await httpResponseMessage.Content.ReadAsStreamAsync().ContinueWith(res =>
                    {
                        using (GZipStream stream2 = new GZipStream(res.Result, CompressionMode.Decompress, true))
                        {
                            JsonSerializer jsonSerializer = new JsonSerializer();
                            JsonTextReader reader = new JsonTextReader(new StreamReader(stream2));
                            T result = jsonSerializer.Deserialize<T>(reader);
                            outObject = new ResultValue<T>
                            {
                                Result = result,
                                Code = httpResponseMessage.StatusCode
                            };
                        }
                    });
                }
                else
                {
                    outObject = new ResultValue<T>
                    {
                        Code = httpResponseMessage.StatusCode,
                        Exceptions = httpResponseMessage.ReasonPhrase
                    };
                }
            }
            catch (Exception ex)
            {

            }
            return outObject;
        }


        public async Task<ResultValue<T>> GetAsync<T>(string path)
        {
            return await this.GetAsync<T>(this._httpClientObject.GetHttpClient(), path);
        }

        public async Task<ResultValue<T>> PostAsync<T>(string path, T reqObj)
        {
            ResultValue<T> rest = null;
            ObjectContent<T> content = new ObjectContent<T>(reqObj, new JsonMediaTypeFormatter());
            HttpResponseMessage httpResponseMessage = await this._httpClientObject.GetHttpClient().PostAsync(path, content);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                await httpResponseMessage.Content.ReadAsStreamAsync().ContinueWith(res =>
                {
                    using (GZipStream stream2 = new GZipStream(res.Result, CompressionMode.Decompress, true))
                    {
                        JsonSerializer jsonSerializer = new JsonSerializer();
                        JsonTextReader reader = new JsonTextReader(new StreamReader(stream2));
                        T result = jsonSerializer.Deserialize<T>(reader);
                        rest = new ResultValue<T>
                        {
                            Result = result,
                            Code = httpResponseMessage.StatusCode
                        };
                    }
                });
            }
            else
            {
                await httpResponseMessage.Content.ReadAsStreamAsync().ContinueWith(res =>
                {
                    using (GZipStream stream2 = new GZipStream(res.Result, CompressionMode.Decompress, true))
                    {
                        JsonSerializer jsonSerializer = new JsonSerializer();
                        JsonTextReader reader = new JsonTextReader(new StreamReader(stream2));
                        HttpError result = jsonSerializer.Deserialize<HttpError>(reader);
                        rest = new ResultValue<T>
                        {
                            Code = httpResponseMessage.StatusCode,
                            Exceptions = httpResponseMessage.ReasonPhrase + " - " + result.Message
                        };
                    }
                });
            }
            return rest;
        }

        public async Task<ResultValue<T>> PostFilterAsync<TRq, T>(string path, TRq reqObj)
        {
            ResultValue<T> rest = null;
            var content = new ObjectContent<TRq>(reqObj, new JsonMediaTypeFormatter());
            HttpResponseMessage httpResponseMessage = await this._httpClientObject.GetHttpClient().PostAsync(path, content);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                await httpResponseMessage.Content.ReadAsStreamAsync().ContinueWith(res =>
                {
                    using (GZipStream stream2 = new GZipStream(res.Result, CompressionMode.Decompress, true))
                    {
                        JsonSerializer jsonSerializer = new JsonSerializer();
                        JsonTextReader reader = new JsonTextReader(new StreamReader(stream2));
                        T result = jsonSerializer.Deserialize<T>(reader);
                        rest = new ResultValue<T>
                        {
                            Result = result,
                            Code = httpResponseMessage.StatusCode
                        };
                    }
                });
            }
            else
            {
                await httpResponseMessage.Content.ReadAsStreamAsync().ContinueWith(res =>
                {
                    using (GZipStream stream2 = new GZipStream(res.Result, CompressionMode.Decompress, true))
                    {
                        JsonSerializer jsonSerializer = new JsonSerializer();
                        JsonTextReader reader = new JsonTextReader(new StreamReader(stream2));
                        HttpError result = jsonSerializer.Deserialize<HttpError>(reader);
                        rest = new ResultValue<T>
                        {
                            Code = httpResponseMessage.StatusCode,
                            Exceptions = httpResponseMessage.ReasonPhrase + " - " + result.Message
                        };
                    }
                });
            }
            return rest;
        }

        public async Task<ResultValue<T>> PutAsync<T>(string path, T reqObj)
        {
            ObjectContent<T> content = new ObjectContent<T>(reqObj, new JsonMediaTypeFormatter());
            ResultValue<T> rest = null;
            HttpResponseMessage httpResponseMessage = await this._httpClientObject.GetHttpClient().PutAsync(path, content);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                await httpResponseMessage.Content.ReadAsStreamAsync().ContinueWith(res =>
                {
                    using (GZipStream stream2 = new GZipStream(res.Result, CompressionMode.Decompress, true))
                    {
                        JsonSerializer jsonSerializer = new JsonSerializer();
                        JsonTextReader reader = new JsonTextReader(new StreamReader(stream2));
                        T result = jsonSerializer.Deserialize<T>(reader);
                        rest = new ResultValue<T>
                        {
                            Result = result,
                            Code = httpResponseMessage.StatusCode
                        };
                    }
                });
            }
            else
            {
                await httpResponseMessage.Content.ReadAsStreamAsync().ContinueWith(res =>
                {
                    using (GZipStream stream2 = new GZipStream(res.Result, CompressionMode.Decompress, true))
                    {
                        JsonSerializer jsonSerializer = new JsonSerializer();
                        JsonTextReader reader = new JsonTextReader(new StreamReader(stream2));
                        HttpError result = jsonSerializer.Deserialize<HttpError>(reader);
                        rest = new ResultValue<T>
                        {
                            Code = httpResponseMessage.StatusCode,
                            Exceptions = httpResponseMessage.ReasonPhrase + " - " + result.Message
                        };
                    }
                });
            }
            return rest;
        }
        public async Task<ResultValue<T>> DeleteAsync<T>(string path)
        {
            ResultValue<T> rest = null;
            using (HttpResponseMessage httpResponseMessage = await this._httpClientObject.GetHttpClient().DeleteAsync(path))
            {
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    await httpResponseMessage.Content.ReadAsStreamAsync().ContinueWith(res =>
                    {
                        using (GZipStream stream2 = new GZipStream(res.Result, CompressionMode.Decompress, true))
                        {
                            JsonSerializer jsonSerializer = new JsonSerializer();
                            JsonTextReader reader = new JsonTextReader(new StreamReader(stream2));
                            //T result = jsonSerializer.Deserialize<T>(reader);
                            rest = new ResultValue<T>
                            {
                                Code = httpResponseMessage.StatusCode
                            };
                        }
                    });
                }
                else
                {
                    await httpResponseMessage.Content.ReadAsStreamAsync().ContinueWith(res =>
                    {
                        using (GZipStream stream2 = new GZipStream(res.Result, CompressionMode.Decompress, true))
                        {
                            JsonSerializer jsonSerializer = new JsonSerializer();
                            JsonTextReader reader = new JsonTextReader(new StreamReader(stream2));
                            HttpError result = jsonSerializer.Deserialize<HttpError>(reader);
                            rest = new ResultValue<T>
                            {
                                Code = httpResponseMessage.StatusCode,
                                Exceptions = httpResponseMessage.ReasonPhrase + " - " + result.Message
                            };
                        }
                    });
                }
            }
            return rest;
        }
        public ResultValue<T> Get<T>(string path)
        {
            HttpResponseMessage result = this._httpClientObject.GetHttpClient().GetAsync(path).Result;
            if (result.IsSuccessStatusCode)
            {
                Stream result2 = result.Content.ReadAsStreamAsync().Result;
                GZipStream stream = new GZipStream(result2, CompressionMode.Decompress, true);
                JsonSerializer jsonSerializer = new JsonSerializer();
                JsonTextReader reader = new JsonTextReader(new StreamReader(stream));
                T result3 = jsonSerializer.Deserialize<T>(reader);
                return new ResultValue<T>
                {
                    Result = result3,
                    Code = result.StatusCode
                };
            }
            return new ResultValue<T>
            {
                Code = result.StatusCode,
                Exceptions = result.ReasonPhrase
            };
        }
    }
}