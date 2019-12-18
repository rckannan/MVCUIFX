using System.IO;
using System.Threading.Tasks;

namespace Mashreq.FXEgypt.EntityDTO.Compression
{
    public abstract class Compressor : ICompressor
    {
        public abstract string EncodingType { get; }

        public virtual Task Compress(Stream source, Stream destination)
        {
            Stream compressed = CreateCompressionStream(destination);

            return Pump(source, compressed)
                .ContinueWith(task => compressed.Dispose());
        }

        public virtual Task Decompress(Stream source, Stream destination)
        {
            Stream decompressed = CreateDecompressionStream(source);

            return Pump(decompressed, destination)
                .ContinueWith(task => decompressed.Dispose());
        }

        public abstract Stream CreateCompressionStream(Stream output);
        public abstract Stream CreateDecompressionStream(Stream input);

        protected virtual Task Pump(Stream input, Stream output)
        {
            return input.CopyToAsync(output);
        }
    }
}