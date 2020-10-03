using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using StenographNet.Common;
using StenographNet.PayloadAccumulators;
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
            _data = File.ReadAllBytes("resources/data/LoremIpsum.txt");

            _stenographer = ImageRgba32Stenographer.Default;
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
            var accumulator = new PayloadAccumulator();
            var payloadWriter = new BitWriter(accumulator);

            _stenographer.Extract(_image, payloadWriter);

            payloadWriter.Flush();

            return accumulator.Values.Count;
        }
        
        public void Dispose()
        {
            _image?.Dispose();
        }
    }
}