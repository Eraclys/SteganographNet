using System;
using System.IO;
using System.Text;
using FluentAssertions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using StenographNet.Common;
using StenographNet.Payload;
using StenographNet.Stenographers;
using Xunit;
using Xunit.Abstractions;
using Image = SixLabors.ImageSharp.Image;

namespace StenographNet.Tests.Stenographers
{
    public class BitmapStenographerTests
    {
        readonly ITestOutputHelper _output;
        readonly IStenographer<Image<Rgba32>> _sut;
        
        public BitmapStenographerTests(ITestOutputHelper output)
        {
            _output = output;
            _sut = new ImageRgba32Stenographer(bitsPerChannel: 1, ColorChannel.R | ColorChannel.G | ColorChannel.B);
        }

        [Theory]
        [InlineData("drawing.png")]
        [InlineData("eclipse.png")]
        [InlineData("tranquility.png")]
        [InlineData("transparent.png")]
        [InlineData("white.png")]
        public void ShouldBeAbleEmbedAndExtractPayload(string imageName)
        {
            var inputPath = $"resources/images/{imageName}";
            var outputPath = $"{Environment.CurrentDirectory}/embedded-{imageName}";
            var message = "this is a hidden message";

            using var image = Image.Load<Rgba32>(inputPath);
            using var payload = Encoding.Default.GetBytes(message).ToStream();

            _sut.Embed(image, new PayloadReader(payload));

            image.SaveAsPng(outputPath, new PngEncoder
            {
                ColorType = PngColorType.RgbWithAlpha,
                BitDepth = PngBitDepth.Bit8
            });

            using var imageWithPayload = Image.Load<Rgba32>(outputPath);
            using var outputStream = new MemoryStream();
            
            var payloadWriter = new PayloadWriter(outputStream);

            _sut.Extract(imageWithPayload, payloadWriter);

            payloadWriter.Flush();

            var actualMessage = Encoding.Default.GetString(outputStream.ToArray());
            
            actualMessage.Substring(0, message.Length).Should().Be(message);

            _output.WriteLine(outputPath);
        }
    }
}
