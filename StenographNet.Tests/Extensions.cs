using System.IO;

namespace StenographNet.Tests
{
    public static class Extensions
    {
        public static Stream ToStream(this byte[] bytes)
        {
            return new MemoryStream(bytes);
        }
    }
}
