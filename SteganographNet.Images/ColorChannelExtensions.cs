using System.Runtime.CompilerServices;

namespace SteganographNet.Images
{
    public static class ColorChannelExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Has(this ColorChannel first, ColorChannel second)
        {
            return (first & second) == second;
        }
        
        public static int Count(this ColorChannel value)
        {
            return ((int) value).GetSetBitsCount();
        }
    }
}