using System;

namespace StenographNet.PayloadAccumulators
{
    public abstract class BaseFixedSizeAccumulator : IPayloadAccumulator
    {
        readonly byte[] _sizePayloadbuffer = new byte[sizeof(long)];
        bool _sizeRead;
        bool _isCompleted;
        long _size;
        long _currentIndex;
        
        public bool OnNext(byte value)
        {
            if (_isCompleted)
                return false;
            
            if (_sizeRead)
            {
                OnDataReceived(_currentIndex++, value);
                
                if (_currentIndex == _size)
                {
                    _isCompleted = true;
                    OnCompleted();

                    return false;
                }
            }
            else
            {
                _sizePayloadbuffer[_currentIndex++] = value;

                if (_currentIndex == sizeof(long))
                {
                    _sizeRead = true;
                    _size = BitConverter.ToInt64(_sizePayloadbuffer, 0);
                    _currentIndex = 0;
                    OnSizeReceived(_size);
                }
            }

            return true;
        }

        protected abstract void OnSizeReceived(long size);
        protected abstract void OnDataReceived(long index, byte value);

        public virtual void OnCompleted()
        {
        }
    }
}