using System.IO;
using System.Text;
using StenographNet.Common;

namespace StenographNet
{
    public static class StenographerExtensions
    {
        public static void EmbedMessage<T>(this IStenographer<T> stenographer, T target, string message) where T : class
        {
            var messageData = Encoding.UTF8.GetBytes(message);
            var targetCapacity = stenographer.CalculateBitCapacity(target) / 8;
            var requiredCapacity = sizeof(int) + messageData.Length;

            if (requiredCapacity > targetCapacity)
            {
                throw new StenographException($"The target does not have enough storage capacity, required:{requiredCapacity} bytes, available: {targetCapacity} bytes");
            }

            using var memoryStream = new MemoryStream();
            using var binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(messageData.Length);
            binaryWriter.Write(messageData);
            binaryWriter.Flush();

            memoryStream.Seek(0, SeekOrigin.Begin);

            var bitReader = new BitReader(memoryStream);

            stenographer.Embed(target, bitReader);
        }

        public static string ExtractMessage<T>(this IStenographer<T> stenographer, T target) where T : class
        {
            using var memoryStream = new MemoryStream();
            using var bitWriter = new BitWriter(memoryStream);

            stenographer.Extract(target, bitWriter);
            bitWriter.Flush();

            memoryStream.Seek(0, SeekOrigin.Begin);
            using var binaryReader = new BinaryReader(memoryStream);

            var messageSize = binaryReader.ReadInt32();
            var messageData = binaryReader.ReadBytes(messageSize);

            return Encoding.UTF8.GetString(messageData);
        }
    }
}