using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Freshdesk.Companies;

[JsonConverter(typeof(StringEnumConverter))]
public enum CompanyHealthScore
{
    [EnumMember(Value = "")]
    Unknown,

    [EnumMember(Value = "At risk")]
    AtRisk,

    [EnumMember(Value = "Doing okay")]
    DoingOkay,

    [EnumMember(Value = "Happy")]
    Happy
}