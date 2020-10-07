using System;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using SteganographNet.Steganographers;
using Xunit;
using Xunit.Abstractions;

namespace SteganographNet.Tests.Steganographers
{
    public class ImageRgba32SteganographerTests
    {
        readonly ITestOutputHelper _output;
        
        public ImageRgba32SteganographerTests(ITestOutputHelper output)
        {
            _output = output;
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

            using var image = await SteganoPng.Load($"resources/images/{imageName}");

            image.EmbedMessage(message);

            await image.Save(outputPath);

            using var imageWithPayload = await SteganoPng.Load(outputPath);

            var actualMessage = imageWithPayload.ExtractMessage();

            actualMessage.Should().Be(message);
        }
    }
}
