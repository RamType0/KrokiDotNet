using System.Text.Json.Serialization;

namespace Kroki.D2;

[JsonConverter(typeof(JsonNumberEnumConverter<D2Theme>))]
public enum D2Theme
{
    Default = 0,
    NeutralGray = 1,
    FlagshipTerrastruct = 3,
    CoolClassics = 4,
    MixedBerryBlue = 5,
    GrapeSoda = 6,
    Aubergine = 7,
    ColorblindClear = 8,
    VanillaNitroCola = 100,
    OrangeCreamsicle = 101,
    ShirleyTemple = 102,
    EarthTones = 103,
    EvergladeGreen = 104,
    ButteredToast = 105,
    DarkMauve = 200,
    Terminal = 300,
    TerminalGrayscale = 301,
}
