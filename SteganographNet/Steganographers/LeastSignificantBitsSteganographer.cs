using System;
using SteganographNet.Common;

namespace SteganographNet.Steganographers
{
    public class LeastSignificantBitsSteganographer : IRefSteganographer<byte>
    {
        readonly byte _bitsToKeep;

        public LeastSignificantBitsSteganographer(byte bitsToKeep)
        {
            if (8 % bitsToKeep != 0 || bitsToKeep > 8)
                throw new Exception("The number of bits must be less than 9 and must be a multiple of 8");

            _bitsToKeep = bitsToKeep;
        }

        public long CalculateBitCapacity(byte target)
        {
            return _bitsToKeep;
        }

        public bool Embed(ref byte target, BitReader bitReader)
        {
            if (bitReader.IsAtEndOfStream)
                return false;

            target = target.ReplaceTail(bitReader.Read(_bitsToKeep), _bitsToKeep);

            return !bitReader.IsAtEndOfStream;
        }

        public bool Extract(byte target, BitWriter bitWriter)
        {
            if (bitWriter.IsFinished)
                return false;

            bitWriter.Write(target, _bitsToKeep);

            return !bitWriter.IsFinished;
        }
    }
}