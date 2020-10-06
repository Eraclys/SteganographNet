using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SteganographNet.Steganographers;

namespace SteganographNet.PerformanceTests
{
    [MemoryDiagnoser]
    [EtwProfiler]
    public class ImageRgba32SteganographerBenchmarks : IDisposable
    {
        readonly ISteganographer<Image<Rgba32>> _steganographer;
        readonly Image<Rgba32> _image;
        readonly Image<Rgba32> _imageWithMessage;
        readonly string _message;

        public ImageRgba32SteganographerBenchmarks()
        {
            _image = Image.Load<Rgba32>("resources/images/drawing.png");
            _imageWithMessage = Image.Load<Rgba32>("resources/images/drawing.png");
            _message = File.ReadAllText("resources/data/TenThousandWords.txt");

            _steganographer = ImageRgba32Steganographer.Default;
            _steganographer.EmbedMessage(_imageWithMessage, _message);
        }
        
        [Benchmark]
        public long CalculateBitCapacity() => _steganographer.CalculateBitCapacity(_image);
        
        [Benchmark]
        public void EmbedMessage()
        {
            _steganographer.EmbedMessage(_image, _message);
        }

        [Benchmark]
        public long ExtractMessage()
        {
            return _steganographer.ExtractMessage(_imageWithMessage).Length;
        }
        
        public void Dispose()
        {
            _imageWithMessage?.Dispose();
            _image?.Dispose();
        }
    }
}