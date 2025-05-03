using Kroki.Json.Serialization;
using System.Text.Json.Serialization;

namespace Kroki.D2;

public record D2Options
{
    [JsonPropertyName("theme")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public D2Theme? Theme { get; init; }

    [JsonPropertyName("layout")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public D2Layout? Layout { get; init; }

    [JsonPropertyName("sketch")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonConverter(typeof(EmptyStringFlagJsonConverter))]
    public bool Sketch { get; init; }
}
