using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Freshdesk.Companies;

[JsonConverter(typeof(StringEnumConverter))]
public enum CompanyAccountTier
{
    [EnumMember(Value = "")]
    Unknown,

    [EnumMember(Value = "Basic")]
    Basic,

    [EnumMember(Value = "Enterprise")]
    Enterprise,

    [EnumMember(Value = "Premium")]
    Premium
}