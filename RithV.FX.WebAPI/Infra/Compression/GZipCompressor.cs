using System.IO;
using System.IO.Compression;

namespace RithV.FX.WebAPI.Infra.Compression
{
    public class GZipCompressor : Infra.Compression.Compressor
    {
        private const string GZipEncoding = "gzip";

        public override string EncodingType => GZipEncoding;

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