using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Kroki;
public class KrokiRequest
{
    [JsonPropertyName("diagram_source")]
    public required string DiagramSource { get; set; }
    [JsonPropertyName("diagram_type")]
    public required string DiagramType { get; set; }
    [JsonPropertyName("output_format")]
    public required FileFormat OutputFormat { get; set; }
    [JsonPropertyName("diagram_options")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public JsonObject? DiagramOptions { get; set; }
}
