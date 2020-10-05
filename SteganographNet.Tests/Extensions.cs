using System.IO;

namespace SteganographNet.Tests
{
    public static class Extensions
    {
        public static Stream ToStream(this byte[] bytes)
        {
            return new MemoryStream(bytes);
        }
    }
}
