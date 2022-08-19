using System;
using Newtonsoft.Json;

namespace Freshdesk.SlaPolicies;

/// <summary>
/// </summary>
public class SlaPolicy
{
    /// <summary></summary>
    [JsonProperty("active")]
    public bool Active { get; set; }

    /// <summary></summary>
    [JsonProperty("applicable_to")]
    public SlaApplicableTo ApplicableTo { get; set; }

    /// <summary></summary>
    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary></summary>
    [JsonProperty("description")]
    public string Description { get; set; } = "";

    /// <summary></summary>
    [JsonProperty("escalation")]
    public SlaEscalation Escalation { get; set; }

    /// <summary></summary>
    [JsonProperty("id")]
    public long Id { get; set; }

    /// <summary></summary>
    [JsonProperty("is_default")]
    public bool IsDefault { get; set; }

    /// <summary></summary>
    [JsonProperty("name")]
    public string Name { get; set; } = "";

    /// <summary></summary>
    [JsonProperty("position")]
    public int Position { get; set; }

    /// <summary></summary>
    [JsonProperty("sla_target")]
    public SlaTarget SlaTarget { get; set; }

    /// <summary></summary>
    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}