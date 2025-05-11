using System.IO.Compression;

namespace Kroki;

internal struct EncodedDiagram(string diagramSource, CompressionLevel compressionLevel) : ISpanFormattable
{
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return DiagramEncoder.EncodeToString(diagramSource, compressionLevel);
    }

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        return DiagramEncoder.TryEncodeToChars(diagramSource, compressionLevel, destination, out charsWritten);
    }
}