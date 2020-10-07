using System.Collections.Generic;
using System.Linq;

namespace SteganographNet.Steganographers
{
    public class CompositeSteganographer<T> : ISteganographer<IEnumerable<T>> where T : class
    {
        readonly ISteganographer<T> _itemSteganographer;

        public CompositeSteganographer(ISteganographer<T> itemSteganographer)
        {
            _itemSteganographer = itemSteganographer;
        }

        public long CalculateBitCapacity(IEnumerable<T> target)
        {
            return target.Sum(item => _itemSteganographer.CalculateBitCapacity(item));
        }

        public bool Embed(IEnumerable<T> target, BitReader bitReader)
        {
            foreach (var item in target)
            {
                var hasDataLeftToEmbed = _itemSteganographer.Embed(item, bitReader);

                if (!hasDataLeftToEmbed)
                    return false;
            }

            return true;
        }

        public bool Extract(IEnumerable<T> target, BitWriter bitWriter)
        {
            foreach (var item in target)
            {
                var hasDataLeftToExtract = _itemSteganographer.Extract(item, bitWriter);

                if (!hasDataLeftToExtract)
                    return false;
            }

            return true;
        }
    }
}
