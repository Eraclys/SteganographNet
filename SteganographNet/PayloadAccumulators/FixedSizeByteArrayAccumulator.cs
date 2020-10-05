using System;

namespace SteganographNet.PayloadAccumulators
{
    public class FixedSizeByteArrayAccumulator : BaseFixedSizeAccumulator
    {
        public byte[] Payload { get; private set; } = Array.Empty<byte>();

        protected override void OnSizeReceived(long size)
        {
            Payload = new byte[size];
        }

        protected override void OnDataReceived(long index, byte value)
        {
            Payload[index] = value;
        }
    }
}