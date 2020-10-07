using System.IO;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;

namespace SteganographNet.Images
{
    public static class ImageExtensions
    {
        static readonly PngEncoder Encoder = new PngEncoder
        {
            ColorType = PngColorType.RgbWithAlpha,
            BitDepth = PngBitDepth.Bit8,
            CompressionLevel = PngCompressionLevel.BestCompression,
            FilterMethod = PngFilterMethod.Adaptive,
            IgnoreMetadata = true
        };

        public static Task SaveAsStegoAsync(this Image<Rgba32> image, string path) => image.SaveAsPngAsync(path, Encoder);

        public static Task SaveAsStegoAsync(this Image<Rgba32> image, Stream outputStream) => image.SaveAsPngAsync(outputStream, Encoder);
    }
}
