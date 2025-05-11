using System.Buffers;

namespace Kroki.Tests;

public class DiagramEncoderTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(3073)]
    [InlineData(3074)]
    [InlineData(6145)]
    [InlineData(6146)]
    public void AlwaysEncodeSegmentsWithLengthOfMultipleOf3(int size)
    {
        using var memoryStream = DiagramEncoder.MemoryStreamManager.GetStream(new byte[size]);
        var sequence = memoryStream.GetReadOnlySequence();
        SequenceReader<byte> reader = new(sequence);
        while (!reader.End)
        {
            
            if(reader.CurrentSpan.Length % 3 == 0)
            {
                reader.Advance(reader.CurrentSpan.Length);
            }
            else
            {
                reader.Advance(reader.CurrentSpan.Length);
                Assert.True(reader.End, "Non-last segment has length of non-multiple of 3");
            }
        }
    }
}
