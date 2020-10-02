using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace StenographNet.Common
{
    public static class ByteExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte TruncateTail(this byte value, byte size)
        {
            return (byte) ((value >> size) << size);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte TruncateHead(this byte value, byte size)
        {
            return (byte)((value << size) >> size);
        }

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

        public static byte ConvertBoolArrayToByte(this IReadOnlyCollection<bool> source)
        {
            byte result = 0;
            // This assumes the array never contains more than 8 elements!
            var index = 8 - source.Count;

            // Loop through the array
            foreach (var b in source)
            {
                // if the element is 'true' set the bit at that position
                if (b)
                    result |= (byte)(1 << (7 - index));

                index++;
            }

            return result;
        }

        public static byte[] ConvertToBytes(this BitArray bits)
        {
            // Make sure we have enough space allocated even when number of bits is not a multiple of 8
            var bytes = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(bytes, 0);
            return bytes;
        }

        public static bool[] ConvertByteToBoolArray(byte b)
        {
            // prepare the return result
            var result = new bool[8];

            // check each bit in the byte. if 1 set to true, if 0 set to false
            for (var i = 0; i < 8; i++)
                result[i] = (b & (1 << i)) != 0;

            // reverse the array
            Array.Reverse(result);

            return result;
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