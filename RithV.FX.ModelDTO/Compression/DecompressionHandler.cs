using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Mashreq.FXEgypt.EntityDTO.Compression
{
    public class DecompressionHandler : DelegatingHandler
    {
        private readonly Collection<ICompressor> _compressors;

        public DecompressionHandler()
        {
            _compressors = new Collection<ICompressor> {new GZipCompressor(), new DeflateCompressor()};
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
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
                }
            }

            return response;
        }

        private static async Task<HttpContent> DecompressContentAsync(HttpContent compressedContent,
            ICompressor compressor)
        {
            using (compressedContent)
            {
                var decompressed = new MemoryStream();
                await
                    compressor.Decompress(await compressedContent.ReadAsStreamAsync(), decompressed)
                        .ConfigureAwait(false);

                // set position back to 0 so it can be read again
                decompressed.Position = 0;

                var newContent = new StreamContent(decompressed);
                // copy content type so we know how to load correct formatter
                newContent.Headers.ContentType = compressedContent.Headers.ContentType;
                return newContent;
            }
        }
    }
}