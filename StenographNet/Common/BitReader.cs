using System.IO;

namespace StenographNet.Common
{
    public class BitReader
    {
        readonly Stream _stream;
        int _currentBitIndex;
        int _currentByte;
        bool _isAtEndOfStream;

        public BitReader(Stream stream)
        {
            _stream = stream;
            _currentBitIndex = 8;
        }
        
        public virtual bool IsAtEndOfStream => _isAtEndOfStream;

        public virtual byte Read(byte size)
        {
            var value = 0;

            for (var i = 0; i < size; i++)
            {
                var bitValue = ReadBit();

                if (bitValue)
                {
                    var bitMask = 1 << i;
                    value |= bitMask;
                }
            }
            
            return (byte)value;
        }

        bool ReadBit()
        {
            if (_currentBitIndex == 8)
            {
                var r = _stream.ReadByte();

                if (r == -1)
                {
                    _isAtEndOfStream = true;
                    return false;
                }

                _currentBitIndex = 0;
                _currentByte = r;
            }

            var value = (_currentByte & (1 << _currentBitIndex)) > 0;
            _currentBitIndex++;

            return value;
        }
    }
}