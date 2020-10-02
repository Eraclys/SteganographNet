using System;
using System.IO;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using StenographNet.Common;
using StenographNet.Stenographers;

namespace StenographNet.PerformanceTests
{
    [MemoryDiagnoser]
    [EtwProfiler]
    public class ImageRgba32StenographerBenchmarks : IDisposable
    {
        readonly IStenographer<Image<Rgba32>> _stenographer;
        readonly Image<Rgba32> _image;
        readonly byte[] _data;

        public ImageRgba32StenographerBenchmarks()
        {
            _image = Image.Load<Rgba32>("resources/images/drawing.png");
            _data = GenerateData();

            _stenographer = new ImageRgba32Stenographer(1, ColorChannel.All);
        }
        
        [Benchmark]
        public long CalculateBitCapacity() => _stenographer.CalculateBitCapacity(_image);
        
        [Benchmark]
        public void Embed()
        {
            using var stream = new MemoryStream(_data);

            _stenographer.Embed(_image, new BitReader(stream));
        }

        [Benchmark]
        public long Extract()
        {
            using var stream = new MemoryStream();
            var payloadWriter = new BitWriter(stream);

            _stenographer.Extract(_image, payloadWriter);

            payloadWriter.Flush();

            return stream.Length;
        }

        static byte[] GenerateData()
        {
            return Encoding.Default.GetBytes("this is a hidden message");
        }
        
        public void Dispose()
        {
            _image?.Dispose();
        }
    }
}