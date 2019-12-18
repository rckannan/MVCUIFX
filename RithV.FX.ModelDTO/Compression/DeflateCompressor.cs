using System.IO;
using System.IO.Compression;

namespace Mashreq.FXEgypt.EntityDTO.Compression
{
    public class DeflateCompressor : Compressor
    {
        private const string DeflateEncoding = "deflate";

        public override string EncodingType
        {
            get { return DeflateEncoding; }
        }

        public override Stream CreateCompressionStream(Stream output)
        {
            return new DeflateStream(output, CompressionMode.Compress, true);
        }

        public override Stream CreateDecompressionStream(Stream input)
        {
            return new DeflateStream(input, CompressionMode.Decompress, true);
        }
    }
}