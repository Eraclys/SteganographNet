using SixLabors.ImageSharp.PixelFormats;
using SteganographNet.Steganographers;

namespace SteganographNet.Images
{
    public class Rgba32Steganographer : IRefSteganographer<Rgba32>
    {
        public static readonly Rgba32Steganographer Default = new Rgba32Steganographer();

        readonly Rgba32SteganographerOptions _options;
        readonly IRefSteganographer<byte> _lsbSteganographer;
        readonly int _lsbCapacity;
        const int MaxCapacity = 3 * 8;

        public Rgba32Steganographer(Rgba32SteganographerOptions? options = null)
        {
            _options = options ?? Rgba32SteganographerOptions.Default;

            _lsbSteganographer = new LeastSignificantBitsSteganographer(_options.BitsPerChannel);
            _lsbCapacity = _options.BitsPerChannel * _options.ColorChannelsToUse.Count();
        }

        public long CalculateBitCapacity(Rgba32 target) => _options.UseFullColorChannelTransparent && target.A == 0 ? MaxCapacity : _lsbCapacity;
        
        public bool Embed(ref Rgba32 target, BitReader bitReader)
        {
            if (bitReader.IsAtEndOfStream)
                return false;

            return _options.UseFullColorChannelTransparent && target.A == 0
                ? FullEmbed(ref target, bitReader)
                : LsbEmbed(ref target, bitReader);
        }

        public bool Extract(Rgba32 target, BitWriter bitWriter)
        {
            if (bitWriter.IsFinished)
                return false;

            return _options.UseFullColorChannelTransparent && target.A == 0
                ? FullExtract(ref target, bitWriter)
                : LsbExtract(ref target, bitWriter);
        }

        static bool FullEmbed(ref Rgba32 target, BitReader bitReader)
        {
            return FullEmbed(out target.R, bitReader) &&
                   FullEmbed(out target.G, bitReader) &&
                   FullEmbed(out target.B, bitReader);
        }

        static bool FullEmbed(out byte value, BitReader bitReader)
        {
            value = bitReader.Read(8);
            return !bitReader.IsAtEndOfStream;
        }

        bool LsbEmbed(ref Rgba32 target,  BitReader bitReader)
        {
            return LsbEmbed(ColorChannel.R, ref target.R, bitReader) &&
                   LsbEmbed(ColorChannel.G, ref target.G, bitReader) && 
                   LsbEmbed(ColorChannel.B, ref target.B, bitReader);
        }

        bool LsbEmbed(ColorChannel channel, ref byte value, BitReader bitReader)
        {
            if (!_options.ColorChannelsToUse.Has(channel))
                return true;

            return _lsbSteganographer.Embed(ref value, bitReader);
        }

        static bool FullExtract(ref Rgba32 target, BitWriter bitWriter)
        {
            return FullExtract(ref target.R, bitWriter) &&
                   FullExtract(ref target.G, bitWriter) &&
                   FullExtract(ref target.B, bitWriter);
        }

        static bool FullExtract(ref byte value, BitWriter bitWriter)
        {
            bitWriter.Write(value, 8);
            return !bitWriter.IsFinished;
        }

        bool LsbExtract(ref Rgba32 target, BitWriter bitWriter)
        {
            return LsbExtract(ColorChannel.R, ref target.R, bitWriter) &&
                   LsbExtract(ColorChannel.G, ref target.G, bitWriter) &&
                   LsbExtract(ColorChannel.B, ref target.B, bitWriter);
        }

        bool LsbExtract(ColorChannel channel, ref byte value, BitWriter bitWriter)
        {
            if (!_options.ColorChannelsToUse.Has(channel))
                return true;

            return _lsbSteganographer.Extract(value, bitWriter);
        }
    }
}