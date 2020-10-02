using System.IO;
using System.Linq;
using FluentAssertions;
using StenographNet.Common;
using StenographNet.Payload;
using StenographNet.Stenographers;
using Xunit;

namespace StenographNet.Tests.Stenographers
{
    public class LeastSignificantBitsStenographerTests
    {
        public class OneBitStenographer
        {
            readonly IStenographer<byte> _sut;

            public OneBitStenographer()
            {
                _sut = new LeastSignificantBitsStenographer(1);
            }

            [Theory]
            [InlineData("11111111", "00000000", "11111110")]
            [InlineData("11111111", "00000001", "11111111")]
            [InlineData("00000000", "00000000", "00000000")]
            [InlineData("00000000", "00000001", "00000001")]
            [InlineData("01010101", "00000000", "01010100")]
            [InlineData("01010101", "00000001", "01010101")]
            public void ShouldBeAbleEmbedAndExtractPayload(string target, string inject, string expected)
            {
                var toEmbed = ByteExtensions.FromBinaryString(target).First();
                using var payload =  ByteExtensions.FromBinaryString(inject).ToStream();

                var byteWithPayload = _sut.Embed(toEmbed, new PayloadReader(payload));

                byteWithPayload.ToBinaryString().Should().Be(expected);

                using var outputStream = new MemoryStream();

                var payloadWriter = new PayloadWriter(outputStream);

                _sut.Extract(byteWithPayload, payloadWriter);

                payloadWriter.Flush();

                var actualPayload = outputStream.ToArray().First();

                actualPayload.ToBinaryString().Should().Be(inject);
            }
        }

        public class TwoBitStenographer
        {
            readonly IStenographer<byte> _sut;

            public TwoBitStenographer()
            {
                _sut = new LeastSignificantBitsStenographer(2);
            }

            [Theory]
            [InlineData("11111111", "00000000", "11111100")]
            [InlineData("11111111", "00000001", "11111101")]
            [InlineData("11111111", "00000010", "11111110")]
            [InlineData("11111111", "00000011", "11111111")]
            [InlineData("00000000", "00000000", "00000000")]
            [InlineData("00000000", "00000001", "00000001")]
            [InlineData("00000000", "00000010", "00000010")]
            [InlineData("00000000", "00000011", "00000011")]
            public void ShouldBeAbleEmbedAndExtractPayload(string target, string inject, string expected)
            {
                var toEmbed = ByteExtensions.FromBinaryString(target).First();
                using var payload = ByteExtensions.FromBinaryString(inject).ToStream();

                var byteWithPayload = _sut.Embed(toEmbed, new PayloadReader(payload));

                byteWithPayload.ToBinaryString().Should().Be(expected);

                using var outputStream = new MemoryStream();

                var payloadWriter = new PayloadWriter(outputStream);

                _sut.Extract(byteWithPayload, payloadWriter);

                payloadWriter.Flush();

                var actualPayload = outputStream.ToArray().First();

                actualPayload.ToBinaryString().Should().Be(inject);
            }
        }
    }
}