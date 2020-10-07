using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace SteganographNet.Images
{
    public class ImageRgba32Steganographer
    {
        byte _bitsPerChannel = 1;
        ColorChannel _colorChannelsToUse = ColorChannel.All;
        bool _useAllBitsWhenPixelIsTransparent = true;

        ImageRgba32Steganographer()
        {
        }

        public static ImageRgba32Steganographer New()
        {
            return new ImageRgba32Steganographer();
        }

        public static ISteganographer<Image<Rgba32>> Default = new ImageSteganographer<Rgba32>(Rgba32Steganographer.Default);

        public ImageRgba32Steganographer BitsPerChannel(byte bitsPerChannel)
        {
            _bitsPerChannel = bitsPerChannel;
            return this;
        }

        public ImageRgba32Steganographer ColorChannelsToUse(ColorChannel colorChannelsToUse)
        {
            _colorChannelsToUse = colorChannelsToUse;
            return this;
        }

        public ImageRgba32Steganographer UseAllBitsWhenPixelIsTransparent(bool useAllBitsWhenPixelIsTransparent)
        {
            _useAllBitsWhenPixelIsTransparent = useAllBitsWhenPixelIsTransparent;
            return this;
        }

        public ISteganographer<Image<Rgba32>> Build()
        {
            return new ImageSteganographer<Rgba32>(new Rgba32Steganographer(new Rgba32SteganographerOptions
            {
                BitsPerChannel = _bitsPerChannel,
                ColorChannelsToUse = _colorChannelsToUse,
                UseFullColorChannelTransparent = _useAllBitsWhenPixelIsTransparent
            }));
        }
    }
}