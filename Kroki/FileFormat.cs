using System.Text.Json.Serialization;

namespace Kroki;


/// <summary>
/// Represents the output file format of the diagram.
/// </summary>
/// <remarks>
/// <see href="https://github.com/yuzutech/kroki/blob/b1ffc560284a37f34ded9cc10e362faed70b38f2/server/src/main/java/io/kroki/server/format/FileFormat.java#L17C33-L17C53">Kroki server's format detection is case-insensitive.</see> <br/>
/// So we don't need to use <see cref="System.Text.Json.Serialization.JsonStringEnumMemberNameAttribute"/> which is not supported in .NET 8.0.
/// </remarks>
[JsonConverter(typeof(JsonStringEnumConverter<FileFormat>))]
public enum FileFormat
{
    Png,
    Svg,
    Jpeg,
    Pdf,
    Base64,
    Txt,
    UTxt,
}
