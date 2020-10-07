using System;
using System.Collections.Generic;
using System.Linq;
using SteganographNet.Common;

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

    public class CompositeSteganographer : ISteganographer<IEnumerable<object>>
    {
        readonly Func<Type, ISteganographer<object>> _steganographerFactory;
        
        public CompositeSteganographer(Func<Type, ISteganographer<object>> steganographerFactory)
        {
            _steganographerFactory = steganographerFactory;
        }
        
        public long CalculateBitCapacity(IEnumerable<object> target)
        {
            long totalCapacity = 0;

            foreach (var item in target)
            {
                totalCapacity += GetSteganographer(item).CalculateBitCapacity(item);
            }

            return totalCapacity;
        }

        public bool Embed(IEnumerable<object> target, BitReader bitReader)
        {
            foreach (var item in target)
            {
                var hasDataLeftToEmbed = GetSteganographer(item).Embed(item, bitReader);

                if (!hasDataLeftToEmbed)
                    return false;
            }

            return true;
        }

        public bool Extract(IEnumerable<object> target, BitWriter bitWriter)
        {
            foreach (var item in target)
            {
                var hasDataLeftToExtract = GetSteganographer(item).Extract(item, bitWriter);

                if (!hasDataLeftToExtract)
                    return false;
            }

            return true;
        }
        
        ISteganographer<object> GetSteganographer(object item)
        {
            return _steganographerFactory(item.GetType());
        }
    }
}
