using SteganographNet.Common;

namespace SteganographNet.Steganographers
{
    public class ImageSteganographerOptions
    {
        public static readonly ImageSteganographerOptions Default = new ImageSteganographerOptions();

        public byte BitsPerChannel { get; set; } = 2;
        public ColorChannel ColorChannelsToUse { get; set; } = ColorChannel.All;
        public bool UseFullColorChannelTransparent { get; set; } = true;
    }
}