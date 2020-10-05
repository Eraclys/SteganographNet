using System;
using System.Runtime.CompilerServices;

namespace SteganographNet.Common
{
    [Flags]
    public enum ColorChannel
    {
        R = 1,
        G = 2,
        B = 4,
        All = R | G | B
    }

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