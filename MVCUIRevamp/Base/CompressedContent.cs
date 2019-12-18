using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RithV.FX.Base
{
    public class CompressedContent : HttpContent
    {
        private readonly ICompressor compressor;
        private readonly HttpContent _content;
        public CompressedContent(HttpContent content, ICompressor compressor)
        {
            this._content = content;
            this.compressor = compressor;
            this.AddHeaders();
        }
        protected override bool TryComputeLength(out long length)
        {
            length = -1L;
            return false;
        }
        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            using (this._content)
            {
                Stream source = await this._content.ReadAsStreamAsync();
                await this.compressor.Compress(source, stream);
            }
        }
        private void AddHeaders()
        {
            foreach (KeyValuePair<string, IEnumerable<string>> current in this._content.Headers)
            {
                base.Headers.TryAddWithoutValidation(current.Key, current.Value);
            }
            base.Headers.ContentEncoding.Add(this.compressor.EncodingType);
        }
    }
}