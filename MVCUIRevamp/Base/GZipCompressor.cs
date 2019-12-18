using System.IO;
using System.IO.Compression;

namespace RithV.FX.Base
{
    public class GZipCompressor : Compressor
    {
        private const string GZipEncoding = "gzip";
        public override string EncodingType
        {
            get
            {
                return "gzip";
            }
        }
        public override Stream CreateCompressionStream(Stream output)
        {
            return new GZipStream(output, CompressionMode.Compress, true);
        }
        public override Stream CreateDecompressionStream(Stream input)
        {
            return new GZipStream(input, CompressionMode.Decompress, true);
        }
    }
}