using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SteganographNet.Common;
using SteganographNet.PayloadAccumulators;
using SteganographNet.Steganographers;

namespace SteganographNet.PerformanceTests
{
    [MemoryDiagnoser]
    [EtwProfiler]
    public class ImageRgba32SteganographerBenchmarks : IDisposable
    {
        readonly ISteganographer<Image<Rgba32>> _steganographer;
        readonly Image<Rgba32> _image;
        readonly byte[] _data;

        public ImageRgba32SteganographerBenchmarks()
        {
            _image = Image.Load<Rgba32>("resources/images/drawing.png");
            _data = File.ReadAllBytes("resources/data/LoremIpsum.txt");

            _steganographer = ImageRgba32Steganographer.Default;
        }
        
        [Benchmark]
        public long CalculateBitCapacity() => _steganographer.CalculateBitCapacity(_image);
        
        [Benchmark]
        public void Embed()
        {
            using var stream = new MemoryStream(_data);

            _steganographer.Embed(_image, new BitReader(stream));
        }

        [Benchmark]
        public long Extract()
        {
            var accumulator = new PayloadAccumulator();
            var payloadWriter = new BitWriter(accumulator);

            _steganographer.Extract(_image, payloadWriter);

            payloadWriter.Flush();

            return accumulator.Values.Count;
        }
        
        public void Dispose()
        {
            _image?.Dispose();
        }
    }
}