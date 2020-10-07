using SixLabors.ImageSharp.PixelFormats;

namespace SteganographNet.Steganographers
{
    public class ImageRgba32Steganographer : ImageSteganographer<Rgba32>
    {
        public static readonly ImageRgba32Steganographer Default = new ImageRgba32Steganographer();

        public ImageRgba32Steganographer(IRefSteganographer<Rgba32>? rgba32Steganographer = null) 
            : base(rgba32Steganographer ?? Rgba32Steganographer.Default)
        {
        }
    }
}