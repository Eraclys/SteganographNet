using System.Collections.Generic;

namespace SteganographNet.PayloadAccumulators
{
    public class PayloadAccumulator : IPayloadAccumulator
    {
        readonly List<byte> _values = new List<byte>();

        public IReadOnlyCollection<byte> Values => _values;
        
        public bool OnNext(byte value)
        {
            _values.Add(value);
            return true;
        }

        public virtual void OnCompleted()
        {
        }
    }
}
