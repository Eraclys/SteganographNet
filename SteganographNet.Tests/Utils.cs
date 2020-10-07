using System.IO;
using System;

namespace SteganographNet.Tests
{
    public static class Utils
    {
        public static Stream ToStream(this byte[] bytes)
        {
            return new MemoryStream(bytes);
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
    }
}
