using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace Kroki.BlockDiag;

internal sealed class DimensionFormatJsonConverter : JsonConverter<DimensionFormat>
{
    // int.MinValue.ToString().Length == 11
    // 11 + "x".Length + 11 < 32
    const int BufferSize = 32;
    public override DimensionFormat Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        Span<byte> buffer = stackalloc byte[BufferSize];
        var length = reader.CopyString(buffer);
        var sizeText = buffer[..length];
        var separatorIndex = sizeText.IndexOf((byte)'x');
        if (separatorIndex == -1)
        {
            throw new JsonException($"Invalid {nameof(DimensionFormat)}: {reader.GetString()}");
        }
        var widthText = sizeText[..separatorIndex];
        var heightText = sizeText[(separatorIndex + 1)..];
        return new(int.Parse(widthText), int.Parse(heightText));
    }

    public override void Write(Utf8JsonWriter writer, DimensionFormat value, JsonSerializerOptions options)
    {
        Span<byte> buffer = stackalloc byte[BufferSize];
        if (!Utf8.TryWrite(buffer, $"{value.Width}x{value.Height}", out var bytesWritten))
        {
            throw new UnreachableException();
        }
        writer.WriteStringValue(buffer[..bytesWritten]);
    }
}
