using Kroki.Json.Serialization;
using System.Text.Json.Serialization;

namespace Kroki.Ditaa;

public record DitaaOptions
{
    [JsonPropertyName("no-antialias")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonConverter(typeof(EmptyStringFlagJsonConverter))]
    public bool NoAntiAlias { get; init; }

    [JsonPropertyName("no-separation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonConverter(typeof(EmptyStringFlagJsonConverter))]
    public bool NoSeparation { get; init; }

    [JsonPropertyName("round-corners")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonConverter(typeof(EmptyStringFlagJsonConverter))]
    public bool RoundCorners { get; init; }

    [JsonPropertyName("scale")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public double? Scale { get; init; }

    [JsonPropertyName("no-shadows")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonConverter(typeof(EmptyStringFlagJsonConverter))]
    public bool NoShadows { get; init; }

    [JsonPropertyName("tabs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Tabs { get; init; }
}
