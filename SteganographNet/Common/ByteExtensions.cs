using System;
using System.Runtime.CompilerServices;

namespace SteganographNet.Common
{
    public static class ByteExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ReplaceTail(this byte value, byte newTailData, byte tailSize)
        {
            return (byte) (((value >> tailSize) << tailSize) | newTailData);
        }

        public static string ToBinaryString(this byte value)
        {
            return Convert.ToString(value, 2).PadLeft(8, '0');
        }

        public static byte[] FromBinaryString(string value)
        {
            var numOfBytes = value.Length / 8;
            var bytes = new byte[numOfBytes];

            for (var i = 0; i < numOfBytes; ++i)
            {
                bytes[i] = Convert.ToByte(value.Substring(8 * i, 8), 2);
            }

            return bytes;
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