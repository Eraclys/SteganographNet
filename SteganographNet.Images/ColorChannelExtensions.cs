using System.Runtime.CompilerServices;

namespace SteganographNet.Images
{
    public static class ColorChannelExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Has(this ColorChannels first, ColorChannels second)
        {
            return (first & second) == second;
        }
        
        public static int Count(this ColorChannels value)
        {
            return ((int) value).GetSetBitsCount();
        }
    }
}