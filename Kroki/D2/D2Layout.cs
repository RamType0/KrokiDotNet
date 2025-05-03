using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kroki.D2;

#if NET9_0_OR_GREATER
[JsonConverter(typeof(JsonStringEnumConverter<D2Layout>))]
#else
[JsonConverter(typeof(D2LayoutJsonConverter))]
#endif
public enum D2Layout
{
#if NET9_0_OR_GREATER
    [JsonStringEnumMemberName("dagre")]
#endif
    Dagre,
#if NET9_0_OR_GREATER
    [JsonStringEnumMemberName("elk")]
#endif
    Elk,
}


#if !NET9_0_OR_GREATER
internal sealed class D2LayoutJsonConverter : JsonStringEnumConverter<D2Layout>
{
    public D2LayoutJsonConverter() : base(new D2LayoutJsonNamingPolicy())
    {
    }
}


internal sealed class D2LayoutJsonNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) => name switch
    {
        nameof(D2Layout.Dagre) => "dagre",
        nameof(D2Layout.Elk) => "elk",
        _ => name,
    };
}
#endif
