using System.Text.Json.Serialization;

namespace Kroki.BlockDiag;

[JsonConverter(typeof(DimensionFormatJsonConverter))]
public record struct DimensionFormat(int Width, int Height);