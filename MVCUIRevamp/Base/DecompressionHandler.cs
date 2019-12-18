using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RithV.FX.Base
{
    public class DecompressionHandler : DelegatingHandler
    {
        private readonly Collection<ICompressor> _compressors;
        public DecompressionHandler()
        {
            this._compressors = new Collection<ICompressor>
            {
                new GZipCompressor()
            };
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            //if (response.IsSuccessStatusCode)
            //{
            if (response.Content.Headers.ContentEncoding != null && response.Content != null &&
                response.Content.Headers.ContentEncoding.Any())
            {
                string encoding = response.Content.Headers.ContentEncoding.First();

                ICompressor compressor =
                    _compressors.FirstOrDefault(
                        c => c.EncodingType.Equals(encoding, StringComparison.InvariantCultureIgnoreCase));

                if (compressor != null)
                {
                    response.Content =
                        await DecompressContentAsync(response.Content, compressor).ConfigureAwait(false);
                }
                //}
            }

            return response;
        }
        private static async Task<HttpContent> DecompressContentAsync(HttpContent compressedContent, ICompressor compressor)
        {
            HttpContent result;
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                await compressor.Decompress(await compressedContent.ReadAsStreamAsync(), memoryStream).ConfigureAwait(false);
                memoryStream.Position = 0L;
                result = new StreamContent(memoryStream)
                {
                    Headers =
                    {
                        ContentType = compressedContent.Headers.ContentType
                    }
                };
            }
            finally
            {
                if (compressedContent != null)
                {
                    ((IDisposable)compressedContent).Dispose();
                }
            }
            return result;
        }
    }
}