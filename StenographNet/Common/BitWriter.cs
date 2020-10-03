namespace StenographNet.Common
{
    public class BitWriter
    {
        readonly IPayloadAccumulator _accumulator;
        int _currentByte;
        int _currentBitIndex;
        bool _continue = true;
        
        public BitWriter(IPayloadAccumulator accumulator)
        {
            _accumulator = accumulator;
        }
        
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
                    _continue = _accumulator.OnNext((byte)_currentByte);

                    if (!_continue)
                    {
                        return;
                    }
                }
            }
        }

        public virtual void Flush()
        {
            if (_currentBitIndex > 0)
            {
                Write(0, (byte)(8 - _currentBitIndex));
                _continue = false;
                _accumulator.OnCompleted();
            }
        }
    }
}