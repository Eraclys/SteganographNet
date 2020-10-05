using System.IO;

namespace SteganographNet.PayloadAccumulators
{
    public class FixedSizeStreamAccumulator : BaseFixedSizeAccumulator
    {
        readonly Stream _stream;

        public FixedSizeStreamAccumulator(Stream stream)
        {
            _stream = stream;
        }

        protected override void OnSizeReceived(long size)
        {
        }

        protected override void OnDataReceived(long index, byte value)
        {
            _stream.WriteByte(value);
        }
    }
}