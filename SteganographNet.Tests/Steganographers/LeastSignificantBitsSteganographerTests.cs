using System.IO;
using System.Linq;
using FluentAssertions;
using SteganographNet.Steganographers;
using Xunit;

namespace SteganographNet.Tests.Steganographers
{
    public class LeastSignificantBitsSteganographerTests
    {
        public class OneBitSteganographer
        {
            readonly IRefSteganographer<byte> _sut;

            public OneBitSteganographer()
            {
                _sut = new LeastSignificantBitsSteganographer(1);
            }

            [Theory]
            [InlineData("11111111", "00000000", "11111110")]
            [InlineData("11111111", "00000001", "11111111")]
            [InlineData("00000000", "00000000", "00000000")]
            [InlineData("00000000", "00000001", "00000001")]
            [InlineData("01010101", "00000000", "01010100")]
            [InlineData("01010101", "00000001", "01010101")]
            public void ShouldBeAbleEmbedAndExtractPayload(string targetBinaryString, string payloadBinaryString, string expectedBinaryString)
            {
                var target = Utils.FromBinaryString(targetBinaryString).First();
                using var payload = Utils.FromBinaryString(payloadBinaryString).ToStream();

                _sut.Embed(ref target, new BitReader(payload, includeLengthHeader: false));

                target.ToBinaryString().Should().Be(expectedBinaryString);
                
                using var outputStream = new MemoryStream();
                var payloadWriter = new BitWriter(outputStream, contentIncludesLengthHeader: false);

                _sut.Extract(target, payloadWriter);

                payloadWriter.Flush();

                var actualPayload = outputStream.ToArray().First();

                actualPayload.ToBinaryString().Should().Be(payloadBinaryString);
            }
        }

        public class TwoBitSteganographer
        {
            readonly IRefSteganographer<byte> _sut;

            public TwoBitSteganographer()
            {
                _sut = new LeastSignificantBitsSteganographer(2);
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
            public void ShouldBeAbleEmbedAndExtractPayload(string targetBinaryString, string payloadBinaryString, string expectedBinaryString)
            {
                var target = Utils.FromBinaryString(targetBinaryString).First();
                using var payload = Utils.FromBinaryString(payloadBinaryString).ToStream();

                _sut.Embed(ref target, new BitReader(payload, includeLengthHeader: false));

                target.ToBinaryString().Should().Be(expectedBinaryString);
                
                using var outputStream = new MemoryStream();
                var payloadWriter = new BitWriter(outputStream, contentIncludesLengthHeader: false);

                _sut.Extract(target, payloadWriter);

                payloadWriter.Flush();

                var actualPayload = outputStream.ToArray().First();

                actualPayload.ToBinaryString().Should().Be(payloadBinaryString);
            }
        }
    }
}