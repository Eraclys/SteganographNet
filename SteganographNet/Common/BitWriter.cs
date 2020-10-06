using System;
using System.IO;

namespace SteganographNet.Common
{
    public class BitWriter
    {
        readonly byte[] _contentLengthBuffer;
        readonly Stream _stream;
        readonly bool _contentIncludesLengthHeader;
        int _currentByte;
        int _currentBitIndex;
        int _contentLengthIndex;
        bool _continue = true;
        long _contentLength;
        long _currentIndex;

        public BitWriter(Stream stream, bool contentIncludesLengthHeader = true)
        {
            if (!stream.CanWrite)
                throw new SteganographException("Stream must be writable");

            _stream = stream;
            _contentIncludesLengthHeader = contentIncludesLengthHeader;
            _contentLengthBuffer = contentIncludesLengthHeader ? new byte[sizeof(long)] : Array.Empty<byte>();
        }
        
        public virtual bool IsFinished => !_continue;

        public virtual void Write(byte target, byte bitsToKeep)
        {
            if (!_continue)
                return;

            for (var i = 0; i < bitsToKeep; i++)
            {
                var bitValue = (target & (1 << i)) != 0;
                var bitMask  = 1 << _currentBitIndex++;
                
                if (bitValue)
                {
                    _currentByte |= bitMask;
                }
                else
                {
                    _currentByte &= ~bitMask;
                }
                
                if (_currentBitIndex == 8)
                {
                    _currentBitIndex = 0;
                    _continue = WriteByte((byte)_currentByte);

                    if (!_continue)
                    {
                        return;
                    }
                }
            }
        }

        protected virtual bool WriteByte(byte value)
        {
            if (_contentIncludesLengthHeader &&_contentLengthIndex < _contentLengthBuffer.Length)
            {
                _contentLengthBuffer[_contentLengthIndex++] = value;

                if (_contentLengthIndex != _contentLengthBuffer.Length)
                    return true;

                _contentLength = BitConverter.ToInt64(_contentLengthBuffer, 0);

                return _contentLength != 0;
            }
            
            _stream.WriteByte(value);
            _currentIndex++;

            return !_contentIncludesLengthHeader || _currentIndex != _contentLength;
        }

        public virtual void Flush()
        {
            if (_continue && _currentBitIndex > 0)
            {
                Write(0, (byte)(8 - _currentBitIndex));
                _continue = false;
            }
        }
    }
}