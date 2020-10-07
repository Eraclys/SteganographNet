namespace SteganographNet.Images
{
    public class Rgba32SteganographerOptions
    {
        public static readonly Rgba32SteganographerOptions Default = new Rgba32SteganographerOptions();

        public byte BitsPerChannel { get; set; } = 2;
        public ColorChannel ColorChannelsToUse { get; set; } = ColorChannel.All;
        public bool UseFullColorChannelTransparent { get; set; } = true;
    }
}