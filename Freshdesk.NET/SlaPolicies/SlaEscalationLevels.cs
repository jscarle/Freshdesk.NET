using Newtonsoft.Json;

namespace Freshdesk.SlaPolicies;

/// <summary>
/// </summary>
public class SlaEscalationLevels
{
    /// <summary></summary>
    [JsonProperty("level_1")]
    public SlaEscalationAgents Level1 { get; set; }

    /// <summary></summary>
    [JsonProperty("level_2")]
    public SlaEscalationAgents Level2 { get; set; }

    /// <summary></summary>
    [JsonProperty("level_3")]
    public SlaEscalationAgents Level3 { get; set; }

    /// <summary></summary>
    [JsonProperty("level_4")]
    public SlaEscalationAgents Level4 { get; set; }
}