using System;
using System.Collections.Generic;

namespace SteganographNet.Steganographers
{
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