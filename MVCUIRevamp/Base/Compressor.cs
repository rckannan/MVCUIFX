using System.IO;
using System.Threading.Tasks;

namespace RithV.FX.Base
{
    public abstract class Compressor : ICompressor
    {
        public abstract string EncodingType
        {
            get;
        }
        public virtual Task Compress(Stream source, Stream destination)
        {
            Stream compressed = this.CreateCompressionStream(destination);
            return this.Pump(source, compressed).ContinueWith(delegate (Task task)
            {
                compressed.Dispose();
            });
        }
        public virtual Task Decompress(Stream source, Stream destination)
        {
            Stream decompressed = this.CreateDecompressionStream(source);
            return this.Pump(decompressed, destination).ContinueWith(delegate (Task task)
            {
                decompressed.Dispose();
            });
        }
        public abstract Stream CreateCompressionStream(Stream output);
        public abstract Stream CreateDecompressionStream(Stream input);
        protected virtual Task Pump(Stream input, Stream output)
        {
            return input.CopyToAsync(output);
        }
    }
}