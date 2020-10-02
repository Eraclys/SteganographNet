using System;
using System.IO;

namespace StenographNet.Common
{
    public class BitWriter : IDisposable
    {
        readonly Stream _stream;
        int _currentByte;
        int _currentBitIndex;
        
        public BitWriter(Stream stream)
        {
            _stream = stream;
        }
        
        public virtual void Write(byte target, byte bitsToKeep)
        {
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
                    _stream.WriteByte((byte)_currentByte);
                }
            }
        }

        public virtual void Flush()
        {
            if (_currentBitIndex > 0)
            {
                Write(0, (byte)(8 - _currentBitIndex));
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Flush();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}