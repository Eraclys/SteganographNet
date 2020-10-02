using StenographNet.Common;

namespace StenographNet.Stenographers
{
    public class Rgba32StenographerOptions
    {
        public static readonly Rgba32StenographerOptions Default = new Rgba32StenographerOptions();

        public byte BitsPerChannel { get; set; } = 2;
        public ColorChannel ColorChannelsToUse { get; set; } = ColorChannel.All;
        public bool UseFullColorChannelTransparent { get; set; } = true;
    }
}