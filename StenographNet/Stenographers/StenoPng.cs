using System.IO;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;

namespace StenographNet.Stenographers
{
    public class StenoPng : DisposableStenograph<Image<Rgba32>>
    {
        static readonly IStenographer<Image<Rgba32>> DefaultStrategy = new ImageRgba32Stenographer();
        static readonly PngEncoder Encoder = new PngEncoder
        {
            ColorType = PngColorType.RgbWithAlpha,
            BitDepth = PngBitDepth.Bit8
        };

        StenoPng(Image<Rgba32> value, IStenographer<Image<Rgba32>> strategy) 
            : base(value, strategy)
        {
        }

        public static async Task<StenoPng> Load(Stream stream)
        {
            var image = await Image.LoadAsync<Rgba32>(stream);

            return new StenoPng(image, DefaultStrategy);
        }

        public static async Task<StenoPng> Load(string path)
        {
            var image = await Image.LoadAsync<Rgba32>(path);

            return new StenoPng(image, DefaultStrategy);
        }
        
        public Task Save(string path)
        {
            return Value.SaveAsPngAsync(path, Encoder);
        }
    }
}
