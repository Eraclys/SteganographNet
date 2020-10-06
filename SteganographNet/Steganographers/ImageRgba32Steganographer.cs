using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SteganographNet.Common;

namespace SteganographNet.Steganographers
{
    public class ImageRgba32Steganographer : ISteganographer<Image<Rgba32>>
    {
        public static readonly ImageRgba32Steganographer Default = new ImageRgba32Steganographer();

        readonly IRefSteganographer<Rgba32> _rgba32Steganographer;

        public ImageRgba32Steganographer(IRefSteganographer<Rgba32> rgba32Steganographer = null)
        {
            _rgba32Steganographer = rgba32Steganographer ?? Rgba32Steganographer.Default;
        }

        public long CalculateBitCapacity(Image<Rgba32> target)
        {
            long totalCapacity = 0;

            for (var y = 0; y < target.Height; y++)
            {
                var pixelRowSpan = target.GetPixelRowSpan(y);

                for (var x = 0; x < target.Width; x++)
                {
                    totalCapacity += _rgba32Steganographer.CalculateBitCapacity(pixelRowSpan[x]);
                }
            }

            return totalCapacity;
        }

        public bool Embed(Image<Rgba32> target, BitReader bitReader)
        {
            if (bitReader.IsAtEndOfStream)
                return false;

            for (var y = 0; y < target.Height; y++)
            {
                var pixelRowSpan = target.GetPixelRowSpan(y);

                for (var x = 0; x < target.Width; x++)
                {
                    var hasDataLeftToEmbed =_rgba32Steganographer.Embed(ref pixelRowSpan[x], bitReader);

                    if (!hasDataLeftToEmbed)
                        return false;
                }
            }

            return true;
        }

        public bool Extract(Image<Rgba32> target, BitWriter bitWriter)
        {
            if (bitWriter.IsFinished)
                return false;

            for (var y = 0; y < target.Height; y++)
            {
                var pixelRowSpan = target.GetPixelRowSpan(y);

                for (var x = 0; x < target.Width; x++)
                {
                    var hasDataLeftToExtract = _rgba32Steganographer.Extract(pixelRowSpan[x], bitWriter);

                    if (!hasDataLeftToExtract)
                        return false;
                }
            }

            return true;
        }
    }
}