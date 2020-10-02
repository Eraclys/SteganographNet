using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using StenographNet.Common;

namespace StenographNet.Stenographers
{
    public class ImageRgba32Stenographer : IStenographer<Image<Rgba32>>
    {
        readonly IStenographer<Rgba32> _rgba32Stenographer;

        public ImageRgba32Stenographer(byte bitsPerChannel, ColorChannel colorChannelsToUse)
        {
            _rgba32Stenographer = new Rgba32Stenographer(bitsPerChannel, colorChannelsToUse);
        }

        public long CalculateBitCapacity(Image<Rgba32> target)
        {
            long totalCapacity = 0;

            for (var y = 0; y < target.Height; y++)
            {
                var pixelRowSpan = target.GetPixelRowSpan(y);

                for (var x = 0; x < target.Width; x++)
                {
                    totalCapacity += _rgba32Stenographer.CalculateBitCapacity(pixelRowSpan[x]);
                }
            }

            return totalCapacity;
        }

        public Image<Rgba32> Embed(Image<Rgba32> target, BitReader bitReader)
        {
            if (bitReader.IsAtEndOfStream)
                return target;

            for (var y = 0; y < target.Height; y++)
            {
                var pixelRowSpan = target.GetPixelRowSpan(y);

                for (var x = 0; x < target.Width; x++)
                {
                    pixelRowSpan[x] = _rgba32Stenographer.Embed(pixelRowSpan[x], bitReader);
                }
            }

            return target;
        }

        public void Extract(Image<Rgba32> target, BitWriter bitWriter)
        {
            for (var y = 0; y < target.Height; y++)
            {
                var pixelRowSpan = target.GetPixelRowSpan(y);

                for (var x = 0; x < target.Width; x++)
                {
                    _rgba32Stenographer.Extract(pixelRowSpan[x], bitWriter);
                }
            }
        }
    }
}
