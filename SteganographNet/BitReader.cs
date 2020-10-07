using System;
using System.IO;

namespace SteganographNet
{
    public class BitReader
    {
        readonly Stream _stream;
        readonly byte[] _contentLengthBuffer;
        int _currentBitIndex;
        int _currentByte;
        bool _isAtEndOfStream;
        int _contentLengthIndex;

        public BitReader(Stream stream, bool includeLengthHeader = true)
        {
            if (includeLengthHeader && !stream.CanSeek)
                throw new SteganographException("Stream must be seek-able");

            _stream = stream;
            _currentBitIndex = 8;
            _contentLengthBuffer = includeLengthHeader ? BitConverter.GetBytes(stream.Length) : Array.Empty<byte>();
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
        
        protected virtual bool ReadBit()
        {
            if (_currentBitIndex == 8)
            {
                var r = ReadByte();

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

        protected virtual int ReadByte()
        {
            return _contentLengthIndex < _contentLengthBuffer.Length 
                ? _contentLengthBuffer[_contentLengthIndex++] 
                : _stream.ReadByte();
        }
    }
}