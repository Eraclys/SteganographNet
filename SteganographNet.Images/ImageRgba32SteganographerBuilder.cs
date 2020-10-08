using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace SteganographNet.Images
{
    public class ImageRgba32SteganographerBuilder
    {
        readonly Rgba32SteganographerOptions _options = new Rgba32SteganographerOptions();

        ImageRgba32SteganographerBuilder()
        {
        }

        public static ImageRgba32SteganographerBuilder New()
        {
            return new ImageRgba32SteganographerBuilder();
        }

        public static ISteganographer<Image<Rgba32>> Default = new ImageSteganographer<Rgba32>(Rgba32Steganographer.Default);

        public ImageRgba32SteganographerBuilder BitsPerChannel(byte bitsPerChannel)
        {
            _options.BitsPerChannel = bitsPerChannel;
            return this;
        }

        public ImageRgba32SteganographerBuilder ColorChannelsToUse(ColorChannels colorChannelsToUse)
        {
            _options.ColorChannelsToUse = colorChannelsToUse;
            return this;
        }

        public ImageRgba32SteganographerBuilder ColorChannelsToUse(bool red, bool green, bool blue)
        {
            var channels = ColorChannels.None;

            if (red) channels |= ColorChannels.R;
            if (green) channels |= ColorChannels.G;
            if (blue) channels |= ColorChannels.B;

            _options.ColorChannelsToUse = channels;

            return this;
        }

        public ImageRgba32SteganographerBuilder UseAllBitsWhenPixelIsTransparent(bool useAllBitsWhenPixelIsTransparent)
        {
            _options.UseFullColorChannelTransparent = useAllBitsWhenPixelIsTransparent;
            return this;
        }

        public ISteganographer<Image<Rgba32>> Build()
        {
            return new ImageSteganographer<Rgba32>(new Rgba32Steganographer(_options));
        }
    }
}