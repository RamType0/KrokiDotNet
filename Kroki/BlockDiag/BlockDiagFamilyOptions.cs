using Kroki.Json.Serialization;
using System.Text.Json.Serialization;

namespace Kroki.BlockDiag;
public record BlockDiagFamilyOptions
{
    [JsonPropertyName("antialias")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonConverter(typeof(EmptyStringFlagJsonConverter))]
    public bool AntiAlias { get; init; }

    [JsonPropertyName("no-transparency")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonConverter(typeof(EmptyStringFlagJsonConverter))]
    public bool NoTransparency { get; init; }

    [JsonPropertyName("size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DimensionFormat? Size { get; init; }

    [JsonPropertyName("no-doctype")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonConverter(typeof(EmptyStringFlagJsonConverter))]
    public bool NoDocType { get; init; }
}
