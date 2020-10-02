using System.IO;
using System.Text;
using StenographNet.Common;

namespace StenographNet
{
    public static class StenographerExtensions
    {
        public static void Embed<T>(this IStenographer<T> stenographer, T target, byte[] data) where T : class
        {
            var targetCapacity = stenographer.CalculateBitCapacity(target) / 8;
            var requiredCapacity = sizeof(int) + data.Length;

            if (requiredCapacity > targetCapacity)
            {
                throw new StenographException($"The target does not have enough storage capacity, required:{requiredCapacity} bytes, available: {targetCapacity} bytes");
            }
            
            using var memoryStream = new MemoryStream();
            using var binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(data.Length);
            binaryWriter.Write(data);
            binaryWriter.Flush();

            memoryStream.Seek(0, SeekOrigin.Begin);

            var bitReader = new BitReader(memoryStream);

            stenographer.Embed(target, bitReader);
        }

        public static byte[] Extract<T>(this IStenographer<T> stenographer, T target) where T : class
        {
            using var memoryStream = new MemoryStream();
            using var bitWriter = new BitWriter(memoryStream);

            stenographer.Extract(target, bitWriter);
            bitWriter.Flush();

            memoryStream.Seek(0, SeekOrigin.Begin);
            using var binaryReader = new BinaryReader(memoryStream);

            var messageSize = binaryReader.ReadInt32();
            return binaryReader.ReadBytes(messageSize);
        }

        public static void EmbedMessage<T>(this IStenographer<T> stenographer, T target, string message) where T : class
        {
            stenographer.Embed(target, Encoding.UTF8.GetBytes(message));
        }

        public static string ExtractMessage<T>(this IStenographer<T> stenographer, T target) where T : class
        {
            return Encoding.UTF8.GetString(stenographer.Extract(target));
        }
    }
}