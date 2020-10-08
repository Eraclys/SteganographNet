namespace SteganographNet.Images
{
    public class Rgba32SteganographerOptions
    {
        public byte BitsPerChannel { get; set; } = 2;
        public ColorChannels ColorChannelsToUse { get; set; } = ColorChannels.All;
        public bool UseFullColorChannelTransparent { get; set; } = true;
    }
}