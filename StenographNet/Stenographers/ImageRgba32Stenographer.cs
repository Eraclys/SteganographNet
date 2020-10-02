using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using StenographNet.Common;

namespace StenographNet.Stenographers
{
    public class ImageRgba32Stenographer : IStenographer<Image<Rgba32>>
    {
        public static readonly ImageRgba32Stenographer Default = new ImageRgba32Stenographer();

        readonly IRefStenographer<Rgba32> _rgba32Stenographer;

        public ImageRgba32Stenographer(IRefStenographer<Rgba32> rgba32Stenographer = null)
        {
            _rgba32Stenographer = rgba32Stenographer ?? Rgba32Stenographer.Default;
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

        public void Embed(Image<Rgba32> target, BitReader bitReader)
        {
            if (bitReader.IsAtEndOfStream)
                return;

            for (var y = 0; y < target.Height; y++)
            {
                var pixelRowSpan = target.GetPixelRowSpan(y);

                for (var x = 0; x < target.Width; x++)
                {
                    _rgba32Stenographer.Embed(ref pixelRowSpan[x], bitReader);
                }
            }
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