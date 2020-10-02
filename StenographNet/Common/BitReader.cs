using System.IO;

namespace StenographNet.Common
{
    public class BitReader
    {
        readonly Stream _stream;
        int _currentBitIndex;
        byte _currentByte;
        int _position;

        public BitReader(Stream stream)
        {
            _stream = stream;
            _currentBitIndex = 8;
        }

        public virtual long PayloadSizeInBits => _stream.Length * 8;
        public virtual long RemainingBits => PayloadSizeInBits - _position;

        public virtual byte Read(byte size)
        {
            var data = new bool[size];

            for (var i = 0; i < size; i++)
            {
                data[size - 1 - i] = ReadBit();
            }

            var asByte = data.ConvertBoolArrayToByte();

            _position += size;

            return asByte;
        }

        bool ReadBit()
        {
            if (_currentBitIndex == 8)
            {
                var r = _stream.ReadByte();
                if (r == -1) return false;
                _currentBitIndex = 0;
                _currentByte = (byte)r;
            }

            var value = (_currentByte & (1 << _currentBitIndex)) > 0;
            _currentBitIndex++;

            return value;
        }
    }
}