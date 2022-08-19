using Newtonsoft.Json;

namespace Freshdesk.SlaPolicies;

/// <summary>
/// </summary>
public class SlaTargetDetails
{
    /// <summary></summary>
    [JsonProperty("business_hours")]
    public bool BusinessHours { get; set; }

    /// <summary></summary>
    [JsonProperty("escalation_enabled")]
    public bool EscalationEnabled { get; set; }

    /// <summary></summary>
    [JsonProperty("resolve_within")]
    public int ResolveWithin { get; set; }

    /// <summary></summary>
    [JsonProperty("respond_within")]
    public int RespondWithin { get; set; }
}