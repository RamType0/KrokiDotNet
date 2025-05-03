using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kroki.Json.Serialization;

public sealed class EmptyStringFlagJsonConverter : JsonConverter<bool>
{
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.String => true,
            JsonTokenType.Null => false,
            _ => throw new JsonException($"Expected string or null."),
        };
    }

    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
    {
        if (value)
        {
            writer.WriteStringValue(""u8);
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
