using System.Buffers;
using System.Buffers.Text;
using System.Diagnostics;

namespace Kroki;

internal static class Base64UrlEx
{
    internal const int MaximumEncodeLength = (int.MaxValue / 4) * 3;
    public static int EncodeToChars(ReadOnlySequence<byte> source, Span<char> destination)
    {
        OperationStatus status = EncodeToChars(source, destination, out _, out int charsWritten);

        if (status == OperationStatus.Done)
        {
            return charsWritten;
        }

        Debug.Assert(status == OperationStatus.DestinationTooSmall);
        throw new ArgumentException($"{nameof(destination)} is too short.", nameof(destination));
    }

    public static bool TryEncodeToChars(ReadOnlySequence<byte> source, Span<char> destination, out int charsWritten)
    {
        OperationStatus status = EncodeToChars(source, destination, out _, out charsWritten);

        return status == OperationStatus.Done;
    }


    public static string EncodeToString(ReadOnlySequence<byte> source)
    {
        if (source.Length > MaximumEncodeLength)
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
    public static OperationStatus EncodeToChars(ReadOnlySequence<byte> source, Span<char> destination, out int bytesConsumed, out int charsWritten, bool isFinalBlock = true)
    {
        const int BlockSize = 3;
        var reader = new SequenceReader<byte>(source);
        bytesConsumed = 0;
        charsWritten = 0;

        var bytesToEncode = isFinalBlock ? reader.Length : reader.Length - (reader.Length % BlockSize);

        if (MaximumEncodeLength < bytesToEncode)
        {
            return OperationStatus.DestinationTooSmall;
        }

        if (destination.Length < Base64Url.GetEncodedLength((int)bytesToEncode))
        {
            return OperationStatus.DestinationTooSmall;
        }

        Span<byte> processBorderBuffer = stackalloc byte[BlockSize];


        while (true)
        {
            while (reader.UnreadSpan.Length >= BlockSize)
            {
                var operationStatus = Base64Url.EncodeToChars(reader.UnreadSpan, destination[charsWritten..], out var spanBytesConsumed, out var spanCharsWritten, isFinalBlock && reader.UnreadSequence.IsSingleSegment);

                Debug.Assert(operationStatus is OperationStatus.Done or OperationStatus.NeedMoreData);

                bytesConsumed += spanBytesConsumed;
                charsWritten += spanCharsWritten;


                reader.Advance(spanBytesConsumed);
            }
            {
                // Done or need to process border.

                if (reader.TryCopyTo(processBorderBuffer))
                {
                    reader.Advance(BlockSize);
                }
                else
                {
                    if (reader.End || !isFinalBlock)
                    {
                        goto ReturnSuccessfully;
                    }
                    else
                    {
                        // No longer need to maintain buffer, operation is almost over
                        processBorderBuffer = processBorderBuffer[..(int)reader.Remaining];

                        var result = reader.TryCopyTo(processBorderBuffer);

                        Debug.Assert(result);

                        reader.AdvanceToEnd();
                    }
                }

                var operationStatus = Base64Url.EncodeToChars(processBorderBuffer, destination[charsWritten..], out var spanBytesConsumed, out var spanCharsWritten, isFinalBlock && reader.End);

                Debug.Assert(operationStatus is OperationStatus.Done or OperationStatus.NeedMoreData);

                bytesConsumed += spanBytesConsumed;
                charsWritten += spanCharsWritten;


            }
        }
    ReturnSuccessfully:

        return reader.End ? OperationStatus.Done : OperationStatus.NeedMoreData;
    }
}
