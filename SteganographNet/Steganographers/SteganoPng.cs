using System.IO;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;

namespace SteganographNet.Steganographers
{
    public class SteganoPng : DisposableSteganograph<Image<Rgba32>>
    {
        static readonly ISteganographer<Image<Rgba32>> DefaultStrategy = new ImageRgba32Steganographer();
        static readonly PngEncoder Encoder = new PngEncoder
        {
            ColorType = PngColorType.RgbWithAlpha,
            BitDepth = PngBitDepth.Bit8
        };

        SteganoPng(Image<Rgba32> value, ISteganographer<Image<Rgba32>> strategy) 
            : base(value, strategy ?? DefaultStrategy)
        {
        }

        public static async Task<SteganoPng> Load(Stream stream, ISteganographer<Image<Rgba32>> strategy = null)
        {
            var image = await Image.LoadAsync<Rgba32>(stream);

            return new SteganoPng(image, strategy);
        }

        public static async Task<SteganoPng> Load(string path, ISteganographer<Image<Rgba32>> strategy = null)
        {
            var image = await Image.LoadAsync<Rgba32>(path);

            return new SteganoPng(image, strategy);
        }
        
        public Task Save(string path)
        {
            return Value.SaveAsPngAsync(path, Encoder);
        }
    }
}
