using System;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SteganographNet.Images;
using Xunit;
using Xunit.Abstractions;

namespace SteganographNet.Tests.Steganographers
{
    public class ImageRgba32SteganographerBuilderTests
    {
        readonly ITestOutputHelper _output;
        readonly ISteganographer<Image<Rgba32>> _sut;
        
        public ImageRgba32SteganographerBuilderTests(ITestOutputHelper output)
        {
            _output = output;
            _sut = ImageRgba32SteganographerBuilder.Default;
        }

        [Theory]
        [InlineData("drawing.png")]
        [InlineData("eclipse.png")]
        [InlineData("tranquility.png")]
        [InlineData("transparent.png")]
        [InlineData("white.png")]
        public Task ShouldBeAbleToEmbedAndExtractASmallMessage(string imageName)
        {
            const string message = @"This is a secret message";

            return ShouldBeAbleToEmbedAndExtractMessage(imageName, message);
        }
        
        [Theory]
        [InlineData("drawing.png")]
        [InlineData("eclipse.png")]
        [InlineData("tranquility.png")]
        [InlineData("transparent.png")]
        [InlineData("white.png")]
        public async Task ShouldBeAbleEmbedAndExtractTenThousandWords(string imageName)
        {
            var message = await File.ReadAllTextAsync("resources/data/TenThousandWords.txt");

            await ShouldBeAbleToEmbedAndExtractMessage(imageName, message);
        }

        async Task ShouldBeAbleToEmbedAndExtractMessage(string imageName, string message)
        {
            var outputPath = $"{Environment.CurrentDirectory}/embedded-{imageName}";
            _output.WriteLine(outputPath);

            using var image = await Image.LoadAsync<Rgba32>($"resources/images/{imageName}");

            _sut.EmbedMessage(image, message);

            await image.SaveAsStegoAsync(outputPath);

            using var imageWithPayload = await Image.LoadAsync<Rgba32>(outputPath);

            var actualMessage = _sut.ExtractMessage(imageWithPayload);

            actualMessage.Should().Be(message);
        }
    }
}
