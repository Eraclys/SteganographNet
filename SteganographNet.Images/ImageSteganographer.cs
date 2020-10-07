using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace SteganographNet.Images
{
    public class ImageSteganographer<TPixel> : ISteganographer<Image<TPixel>> 
        where TPixel : unmanaged, IPixel<TPixel>
    {
        readonly IRefSteganographer<TPixel> _rgba32Steganographer;

        public ImageSteganographer(IRefSteganographer<TPixel> rgba32Steganographer)
        {
            _rgba32Steganographer = rgba32Steganographer;
        }

        public long CalculateBitCapacity(Image<TPixel> target)
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

        public bool Embed(Image<TPixel> target, BitReader bitReader)
        {
            if (bitReader.IsAtEndOfStream)
                return false;

            for (var y = 0; y < target.Height; y++)
            {
                var pixelRowSpan = target.GetPixelRowSpan(y);

                for (var x = 0; x < target.Width; x++)
                {
                    var hasDataLeftToEmbed = _rgba32Steganographer.Embed(ref pixelRowSpan[x], bitReader);

                    if (!hasDataLeftToEmbed)
                        return false;
                }
            }

            return true;
        }

        public bool Extract(Image<TPixel> target, BitWriter bitWriter)
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