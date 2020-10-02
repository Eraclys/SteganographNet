using System;
using System.Threading.Tasks;
using FluentAssertions;
using StenographNet.Stenographers;
using Xunit;
using Xunit.Abstractions;

namespace StenographNet.Tests.Stenographers
{
    public class ImageRgba32StenographerTests
    {
        readonly ITestOutputHelper _output;
        
        public ImageRgba32StenographerTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData("drawing.png")]
        [InlineData("eclipse.png")]
        [InlineData("tranquility.png")]
        [InlineData("transparent.png")]
        [InlineData("white.png")]
        public async Task ShouldBeAbleEmbedAndExtractPayload(string imageName)
        {
            var outputPath = $"{Environment.CurrentDirectory}/embedded-{imageName}";
            _output.WriteLine(outputPath);

            using var image = await StenoPng.Load($"resources/images/{imageName}");

            const string message = @"
                Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                Suspendisse egestas nunc odio, in dictum felis consequat sit amet. 
                Vivamus eget commodo risus. Etiam vitae eros nibh. Duis in turpis 
                fringilla, lacinia massa sed, vulputate nisi. Cras eu justo eros. 

                Quisque consequat eleifend posuere. Maecenas porta fringilla quam. 
                Mauris quis viverra metus. Suspendisse ullamcorper hendrerit turpis, 
                eget malesuada mi consequat et. Proin eleifend neque ut orci aliquet, 
                ac accumsan nisl aliquam. Nam consequat eros id dolor molestie, 
                sit amet lacinia diam dignissim. Aliquam erat volutpat. 

                Vestibulum sem lacus, efficitur id ultrices quis, hendrerit et nisi. 
                In ornare erat nec tortor tempus.";

            image.EmbedMessage(message);

            await image.Save(outputPath);

            using var imageWithPayload = await StenoPng.Load(outputPath);

            var actualMessage = imageWithPayload.ExtractMessage();

            actualMessage.Should().Be(message);
        }
    }
}
