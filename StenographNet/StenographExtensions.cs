using System.IO;
using StenographNet.Common;

namespace StenographNet
{
    public static class StenographExtensions
    {
        public static void Embed<T>(this Stenograph<T> stenograph, BitReader bitReader) where T : class
        {
            stenograph.Strategy.Embed(stenograph.Value, bitReader);
        }

        public static void Extract<T>(this Stenograph<T> stenograph, BitWriter bitWriter) where T : class
        {
            stenograph.Strategy.Extract(stenograph.Value, bitWriter);
        }

        public static void EmbedStream<T>(this Stenograph<T> stenograph, Stream dataStream) where T : class
        {
            stenograph.Strategy.EmbedStream(stenograph.Value, dataStream);
        }

        public static Stream ExtractStream<T>(this Stenograph<T> stenograph) where T : class
        {
            return stenograph.Strategy.ExtractStream(stenograph.Value);
        }

        public static void ExtractToStream<T>(this Stenograph<T> stenograph, Stream outputStream) where T : class
        {
            stenograph.Strategy.ExtractToStream(stenograph.Value, outputStream);
        }

        public static void EmbedBytes<T>(this Stenograph<T> stenograph, byte[] data) where T : class
        {
            stenograph.Strategy.EmbedBytes(stenograph.Value, data);
        }

        public static byte[] ExtractBytes<T>(this Stenograph<T> stenograph) where T : class
        {
            return stenograph.Strategy.ExtractBytes(stenograph.Value);
        }
        
        public static void EmbedMessage<T>(this Stenograph<T> stenograph, string message) where T : class
        {
            stenograph.Strategy.EmbedMessage(stenograph.Value, message);
        }

        public static string ExtractMessage<T>(this Stenograph<T> stenograph) where T : class
        {
            return stenograph.Strategy.ExtractMessage(stenograph.Value);
        }
    }
}