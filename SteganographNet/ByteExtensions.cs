using System.Runtime.CompilerServices;

namespace SteganographNet
{
    public static class ByteExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ReplaceTail(this byte value, byte newTailData, byte tailSize)
        {
            return (byte) (((value >> tailSize) << tailSize) | newTailData);
        }
        
        public static int GetSetBitsCount(this int value)
        {
            var v = (uint)value;
            v = v - ((v >> 1) & 0x55555555); // reuse input as temporary
            v = (v & 0x33333333) + ((v >> 2) & 0x33333333); // temp
            var c = ((v + (v >> 4) & 0xF0F0F0F) * 0x1010101) >> 24; // count
            return (int)c;
        }
    }
}