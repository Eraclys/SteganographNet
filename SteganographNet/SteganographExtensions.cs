using System.IO;
using SteganographNet.Common;

namespace SteganographNet
{
    public static class SteganographExtensions
    {
        public static void Embed<T>(this Steganograph<T> steganograph, BitReader bitReader) where T : class
        {
            steganograph.Strategy.Embed(steganograph.Value, bitReader);
        }

        public static void Extract<T>(this Steganograph<T> steganograph, BitWriter bitWriter) where T : class
        {
            steganograph.Strategy.Extract(steganograph.Value, bitWriter);
        }

        public static void EmbedStream<T>(this Steganograph<T> steganograph, Stream dataStream) where T : class
        {
            steganograph.Strategy.EmbedStream(steganograph.Value, dataStream);
        }

        public static Stream ExtractStream<T>(this Steganograph<T> steganograph) where T : class
        {
            return steganograph.Strategy.ExtractStream(steganograph.Value);
        }

        public static void ExtractToStream<T>(this Steganograph<T> steganograph, Stream outputStream) where T : class
        {
            steganograph.Strategy.ExtractToStream(steganograph.Value, outputStream);
        }

        public static void EmbedBytes<T>(this Steganograph<T> steganograph, byte[] data) where T : class
        {
            steganograph.Strategy.EmbedBytes(steganograph.Value, data);
        }

        public static byte[] ExtractBytes<T>(this Steganograph<T> steganograph) where T : class
        {
            return steganograph.Strategy.ExtractBytes(steganograph.Value);
        }
        
        public static void EmbedMessage<T>(this Steganograph<T> steganograph, string message) where T : class
        {
            steganograph.Strategy.EmbedMessage(steganograph.Value, message);
        }

        public static string ExtractMessage<T>(this Steganograph<T> steganograph) where T : class
        {
            return steganograph.Strategy.ExtractMessage(steganograph.Value);
        }
    }
}