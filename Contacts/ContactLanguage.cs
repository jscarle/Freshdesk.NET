using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Freshdesk
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContactLanguage
    {
        Unknown,

        [EnumMember(Value = "ar")]
        Arabic,

        [EnumMember(Value = "bs")]
        Bosnian,

        [EnumMember(Value = "bg")]
        Bulgarian,

        [EnumMember(Value = "ca")]
        Catalan,

        [EnumMember(Value = "zh-CN")]
        Chinese,

        [EnumMember(Value = "zh-TW")]
        ChineseTraditional,

        [EnumMember(Value = "hr")]
        Croatian,

        [EnumMember(Value = "cs")]
        Czech,

        [EnumMember(Value = "da")]
        Danish,

        [EnumMember(Value = "nl")]
        Dutch,

        [EnumMember(Value = "en")]
        English,

        [EnumMember(Value = "et")]
        Estonian,

        [EnumMember(Value = "fi")]
        Finnish,

        [EnumMember(Value = "fr")]
        French,

        [EnumMember(Value = "de")]
        German,

        [EnumMember(Value = "el")]
        Greek,

        [EnumMember(Value = "he")]
        Hebrew,

        [EnumMember(Value = "hu")]
        Hungarian,

        [EnumMember(Value = "id")]
        Indonesian,

        [EnumMember(Value = "it")]
        Italian,

        [EnumMember(Value = "ja")]
        Japanese,

        [EnumMember(Value = "ko")]
        Korean,

        [EnumMember(Value = "lv-LV")]
        Latvian,

        [EnumMember(Value = "lt")]
        Lithuanian,

        [EnumMember(Value = "ms")]
        Malay,

        [EnumMember(Value = "nb-NO")]
        Norwegian,

        [EnumMember(Value = "pl")]
        Polish,

        [EnumMember(Value = "pt-BR")]
        PortugueseBrazil,

        [EnumMember(Value = "pt-PT")]
        PortuguesePortugal,

        [EnumMember(Value = "ro")]
        Romanian,

        [EnumMember(Value = "ru-RU")]
        Russian,

        [EnumMember(Value = "sr")]
        Serbian,

        [EnumMember(Value = "sk")]
        Slovak,

        [EnumMember(Value = "sl")]
        Slovenian,

        [EnumMember(Value = "es")]
        Spanish,

        [EnumMember(Value = "es-LA")]
        SpanishLatinAmerica,

        [EnumMember(Value = "sv-SE")]
        Swedish,

        [EnumMember(Value = "th")]
        Thai,

        [EnumMember(Value = "tr")]
        Turkish,

        [EnumMember(Value = "uk")]
        Ukrainian,

        [EnumMember(Value = "vi")]
        Vietnamese
    }
}
