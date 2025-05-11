using Microsoft.IO;
using System.Buffers;
using System.Buffers.Text;
using System.IO.Compression;
using System.Text;

namespace Kroki;

public static class DiagramEncoder
{
    const int DefaultMaxUrlLength = 4096;
    internal static RecyclableMemoryStreamManager MemoryStreamManager { get; } = new(new()
    {
        // 3072 means
        // - Base64Url.GetMaxDecodedLength(DefaultMaxUrlLength)
        // - Multiple of 3 (Efficient for Base 64 encoding)
        BlockSize = 3072,
        // We cannot create encoded string longer than int.MaxValue
        MaximumStreamCapacity = Base64Url.GetMaxDecodedLength(int.MaxValue),
        MaximumSmallPoolFreeBytes = Base64Url.GetMaxDecodedLength(DefaultMaxUrlLength) * Environment.ProcessorCount,
        ThrowExceptionOnToArray = true,
    });
    public static string EncodeToString(ReadOnlySpan<char> diagramSource, CompressionLevel compressionLevel)
    {
        var maxUtf8Size = Encoding.UTF8.GetMaxByteCount(diagramSource.Length);
        var buffer = ArrayPool<byte>.Shared.Rent(maxUtf8Size);
        try
        {
            var utf8Size = Encoding.UTF8.GetBytes(diagramSource, buffer);
            var utf8DiagramSource = buffer.AsSpan()[..utf8Size];
            return EncodeToString(utf8DiagramSource, compressionLevel);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }

    }
    public static string EncodeToString(ReadOnlySpan<byte> utf8DiagramSource, CompressionLevel compressionLevel)
    {
        using var memoryStream = MemoryStreamManager.GetStream();


        using (ZLibStream zLibStream = new(memoryStream, compressionLevel, leaveOpen: true))
        {
            zLibStream.Write(utf8DiagramSource);
        }

        var compressedSequence = memoryStream.GetReadOnlySequence();

        return Base64UrlEx.EncodeToString(compressedSequence);
    }
    
}
