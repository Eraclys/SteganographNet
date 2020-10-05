using System.IO;
using System.Text;
using StenographNet.Common;
using StenographNet.PayloadAccumulators;

namespace StenographNet
{
    public static class StenographerExtensions
    {
        public static void EmbedStream<T>(this IStenographer<T> stenographer, T target, Stream dataStream) where T : class
        {
            var targetCapacity = stenographer.CalculateBitCapacity(target) / 8;
            var requiredCapacity = sizeof(int) + dataStream.Length;

            if (requiredCapacity > targetCapacity)
            {
                throw new StenographException($"The target does not have enough storage capacity, required:{requiredCapacity} bytes, available: {targetCapacity} bytes");
            }
            
            using var memoryStream = new MemoryStream();
            using var binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(dataStream.Length);
            binaryWriter.Flush();
            dataStream.CopyTo(memoryStream);

            memoryStream.Seek(0, SeekOrigin.Begin);

            var bitReader = new BitReader(memoryStream);

            stenographer.Embed(target, bitReader);
        }
        
        public static Stream ExtractStream<T>(this IStenographer<T> stenographer, T target) where T : class
        {
            var outputStream = new MemoryStream();

            stenographer.ExtractToStream(target, outputStream);

            return outputStream;
        }

        public static void ExtractToStream<T>(this IStenographer<T> stenographer, T target, Stream outputStream) where T : class
        {
            var accumulator = new FixedSizeStreamAccumulator(outputStream);
            var bitWriter = new BitWriter(accumulator);

            stenographer.Extract(target, bitWriter);
        }

        public static void EmbedBytes<T>(this IStenographer<T> stenographer, T target, byte[] data) where T : class
        {
            using var dataStream = new MemoryStream(data);
            stenographer.EmbedStream(target, dataStream);
        }

        public static byte[] ExtractBytes<T>(this IStenographer<T> stenographer, T target) where T : class
        {
            var accumulator = new FixedSizeByteArrayAccumulator();
            var bitWriter = new BitWriter(accumulator);

            stenographer.Extract(target, bitWriter);

            return accumulator.Payload;
        }

        public static void EmbedMessage<T>(this IStenographer<T> stenographer, T target, string message) where T : class
        {
            stenographer.EmbedBytes(target, Encoding.UTF8.GetBytes(message));
        }

        public static string ExtractMessage<T>(this IStenographer<T> stenographer, T target) where T : class
        {
            return Encoding.UTF8.GetString(stenographer.ExtractBytes(target));
        }
    }
}