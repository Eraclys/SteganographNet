using SixLabors.ImageSharp.PixelFormats;
using StenographNet.Common;

namespace StenographNet.Stenographers
{
    public class Rgba32Stenographer : IRefStenographer<Rgba32>
    {
        public static readonly Rgba32Stenographer Default = new Rgba32Stenographer();

        readonly Rgba32StenographerOptions _options;
        readonly IRefStenographer<byte> _lsbStenographer;
        readonly int _lsbCapacity;
        const int MaxCapacity = 3 * 8;

        public Rgba32Stenographer(Rgba32StenographerOptions options = null)
        {
            _options = options ?? Rgba32StenographerOptions.Default;

            _lsbStenographer = new LeastSignificantBitsStenographer(_options.BitsPerChannel);
            _lsbCapacity = _options.BitsPerChannel * _options.ColorChannelsToUse.Count();
        }

        public long CalculateBitCapacity(Rgba32 target) => _options.UseFullColorChannelTransparent && target.A == 0 ? MaxCapacity : _lsbCapacity;
        
        public void Embed(ref Rgba32 target, BitReader bitReader)
        {
            if (bitReader.IsAtEndOfStream)
                return;

            if (_options.UseFullColorChannelTransparent && target.A == 0)
            {
                FullEmbed(ref target, bitReader);
                return;
            }

            LsbEmbed(ref target, bitReader);
        }

        void FullEmbed(ref Rgba32 target, BitReader bitReader)
        {
            target.R = bitReader.Read(8);
            target.G = bitReader.Read(8);
            target.B = bitReader.Read(8);
        }

        void LsbEmbed(ref Rgba32 target,  BitReader bitReader)
        {
            if (_options.ColorChannelsToUse.Has(ColorChannel.R))
                _lsbStenographer.Embed(ref target.R, bitReader);

            if (_options.ColorChannelsToUse.Has(ColorChannel.G))
                _lsbStenographer.Embed(ref target.G, bitReader);

            if (_options.ColorChannelsToUse.Has(ColorChannel.B))
                _lsbStenographer.Embed(ref target.B, bitReader);
        }

        public void Extract(Rgba32 target, BitWriter bitWriter)
        {
            if (_options.UseFullColorChannelTransparent && target.A == 0)
            {
                FullExtract(ref target, bitWriter);
                return;
            }

            LsbExtract(ref target, bitWriter);
        }

        void FullExtract(ref Rgba32 target, BitWriter bitWriter)
        {
            bitWriter.Write(target.R, 8);
            bitWriter.Write(target.G, 8);
            bitWriter.Write(target.B, 8);
        }

        void LsbExtract(ref Rgba32 target, BitWriter bitWriter)
        {
            if (_options.ColorChannelsToUse.Has(ColorChannel.R))
                _lsbStenographer.Extract(target.R, bitWriter);

            if (_options.ColorChannelsToUse.Has(ColorChannel.G))
                _lsbStenographer.Extract(target.G, bitWriter);

            if (_options.ColorChannelsToUse.Has(ColorChannel.B))
                _lsbStenographer.Extract(target.B, bitWriter);
        }
    }
}