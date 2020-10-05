using System.IO;
using System.Text;
using SteganographNet.Common;
using SteganographNet.PayloadAccumulators;

namespace SteganographNet
{
    public static class SteganographerExtensions
    {
        public static void EmbedStream<T>(this ISteganographer<T> steganographer, T target, Stream dataStream) where T : class
        {
            var targetCapacity = steganographer.CalculateBitCapacity(target) / 8;
            var requiredCapacity = sizeof(int) + dataStream.Length;

            if (requiredCapacity > targetCapacity)
            {
                throw new SteganographException($"The target does not have enough storage capacity, required:{requiredCapacity} bytes, available: {targetCapacity} bytes");
            }
            
            using var memoryStream = new MemoryStream();
            using var binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(dataStream.Length);
            binaryWriter.Flush();
            dataStream.CopyTo(memoryStream);

            memoryStream.Seek(0, SeekOrigin.Begin);

            var bitReader = new BitReader(memoryStream);

            steganographer.Embed(target, bitReader);
        }
        
        public static Stream ExtractStream<T>(this ISteganographer<T> steganographer, T target) where T : class
        {
            var outputStream = new MemoryStream();

            steganographer.ExtractToStream(target, outputStream);

            return outputStream;
        }

        public static void ExtractToStream<T>(this ISteganographer<T> steganographer, T target, Stream outputStream) where T : class
        {
            var accumulator = new FixedSizeStreamAccumulator(outputStream);
            var bitWriter = new BitWriter(accumulator);

            steganographer.Extract(target, bitWriter);
        }

        public static void EmbedBytes<T>(this ISteganographer<T> steganographer, T target, byte[] data) where T : class
        {
            using var dataStream = new MemoryStream(data);
            steganographer.EmbedStream(target, dataStream);
        }

        public static byte[] ExtractBytes<T>(this ISteganographer<T> steganographer, T target) where T : class
        {
            var accumulator = new FixedSizeByteArrayAccumulator();
            var bitWriter = new BitWriter(accumulator);

            steganographer.Extract(target, bitWriter);

            return accumulator.Payload;
        }

        public static void EmbedMessage<T>(this ISteganographer<T> steganographer, T target, string message) where T : class
        {
            steganographer.EmbedBytes(target, Encoding.UTF8.GetBytes(message));
        }

        public static string ExtractMessage<T>(this ISteganographer<T> steganographer, T target) where T : class
        {
            return Encoding.UTF8.GetString(steganographer.ExtractBytes(target));
        }
    }
}