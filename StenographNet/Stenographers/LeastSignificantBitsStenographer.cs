using System;
using StenographNet.Common;

namespace StenographNet.Stenographers
{
    public class LeastSignificantBitsStenographer : IRefStenographer<byte>
    {
        readonly byte _bitsToKeep;

        public LeastSignificantBitsStenographer(byte bitsToKeep)
        {
            if (8 % bitsToKeep != 0 || bitsToKeep > 8)
                throw new Exception("The number of bits must be less than 9 and must be a multiple of 8");

            _bitsToKeep = bitsToKeep;
        }

        public long CalculateBitCapacity(byte target)
        {
            return _bitsToKeep;
        }

        public void Embed(ref byte target, BitReader bitReader)
        {
            if (bitReader.IsAtEndOfStream)
                return;

            target = target.ReplaceTail(bitReader.Read(_bitsToKeep), _bitsToKeep);
        }

        public void Extract(byte target, BitWriter bitWriter)
        {
            bitWriter.Write(target, _bitsToKeep);
        }
    }
}