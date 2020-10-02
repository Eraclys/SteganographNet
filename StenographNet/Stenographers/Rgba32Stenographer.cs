using SixLabors.ImageSharp.PixelFormats;
using StenographNet.Common;

namespace StenographNet.Stenographers
{
    public class Rgba32Stenographer : IStenographer<Rgba32>
    {
        readonly ColorChannel _colorChannelsToUse;
        readonly IStenographer<byte> _lsbStenographer;
        readonly int _lsbCapacity;
        const int MaxCapacity = 3 * 8;

        public Rgba32Stenographer(byte bitsPerChannel, ColorChannel colorChannelsToUse)
        {
            _lsbStenographer = new LeastSignificantBitsStenographer(bitsPerChannel);
            _colorChannelsToUse = colorChannelsToUse;
            _lsbCapacity = bitsPerChannel * colorChannelsToUse.Count();
        }

        public long CalculateBitCapacity(Rgba32 target) => target.A == 0 ? MaxCapacity : _lsbCapacity;
        
        public Rgba32 Embed(Rgba32 target, IPayloadReader payloadReader)
        {
            if (payloadReader.RemainingBits == 0)
                return target;

            if (target.A == 0)
            {
                target.R = payloadReader.Read(8);
                target.G = payloadReader.Read(8);
                target.B = payloadReader.Read(8);

                return target;
            }

            if (_colorChannelsToUse.Has(ColorChannel.R))
                target.R = _lsbStenographer.Embed(target.R, payloadReader);

            if (_colorChannelsToUse.Has(ColorChannel.G))
                target.G = _lsbStenographer.Embed(target.G, payloadReader);

            if (_colorChannelsToUse.Has(ColorChannel.B))
                target.B = _lsbStenographer.Embed(target.B, payloadReader);

            return target;
        }

        public void Extract(Rgba32 target, IPayloadWriter payloadWriter)
        {
            if (target.A == 0)
            {
                payloadWriter.Write(target.R, 8);
                payloadWriter.Write(target.G, 8);
                payloadWriter.Write(target.B, 8);
                return;
            }

            if (_colorChannelsToUse.Has(ColorChannel.R))
                _lsbStenographer.Extract(target.R, payloadWriter);

            if (_colorChannelsToUse.Has(ColorChannel.G))
                _lsbStenographer.Extract(target.G, payloadWriter);

            if (_colorChannelsToUse.Has(ColorChannel.B))
                _lsbStenographer.Extract(target.B, payloadWriter);
        }
    }
}