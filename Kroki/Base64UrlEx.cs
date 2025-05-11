using System.Buffers;
using System.Buffers.Text;
using System.Diagnostics;

namespace Kroki;

internal static class Base64UrlEx
{
    public static int EncodeToChars(ReadOnlySequence<byte> source, Span<char> destination)
    {
        const int BlockSize = 3;

        Span<byte> processBorderBuffer = stackalloc byte[BlockSize];

        var reader = new SequenceReader<byte>(source);
        var totalCharsWritten = 0;
        while (true)
        {
            while (reader.UnreadSpan.Length < BlockSize)
            {
                // Need to process border.

                if (reader.TryCopyTo(processBorderBuffer))
                {
                    reader.Advance(BlockSize);
                }
                else
                {
                    // No longer need to maintain buffer, operation is almost over
                    processBorderBuffer = processBorderBuffer[..(int)reader.Remaining];

                    var result = reader.TryCopyTo(processBorderBuffer);

                    Debug.Assert(result);

                    reader.AdvanceToEnd();
                }

                var operationStatus = Base64Url.EncodeToChars(processBorderBuffer, destination, out var bytesConsumed, out var charsWritten, reader.End);

                Debug.Assert(operationStatus is OperationStatus.NeedMoreData or OperationStatus.Done);

                destination = destination[charsWritten..];
                totalCharsWritten += charsWritten;

                if (reader.End)
                {
                    break;
                }

            }
            {
                var operationStatus = Base64Url.EncodeToChars(reader.UnreadSpan, destination, out var bytesConsumed, out var charsWritten, reader.UnreadSequence.IsSingleSegment);
                Debug.Assert(operationStatus is OperationStatus.NeedMoreData or OperationStatus.Done);

                reader.Advance(bytesConsumed);
                destination = destination[charsWritten..];
                totalCharsWritten += charsWritten;

                if (reader.End)
                {
                    break;
                }
            }
            

            

        }
        return totalCharsWritten;
    }
    public static string EncodeToString(ReadOnlySequence<byte> source)
    {
        if (source.Length > int.MaxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(source), "Encoded string length will be larger than int.MaxValue.");
        }

        var encodedLength = Base64Url.GetEncodedLength((int)source.Length);

        return string.Create(encodedLength, source, static (buffer, source) =>
        {
            var charsWritten = EncodeToChars(source, buffer);
            Debug.Assert(buffer.Length == charsWritten);
        });
    }
}
