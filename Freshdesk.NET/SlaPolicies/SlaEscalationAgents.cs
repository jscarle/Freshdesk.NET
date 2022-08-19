using System.Collections.Generic;
using Newtonsoft.Json;

namespace Freshdesk.SlaPolicies;

/// <summary>
/// </summary>
public class SlaEscalationAgents
{
    /// <summary></summary>
    [JsonProperty("agent_ids")]
    public List<long> AgentIds { get; set; } = new();

    /// <summary></summary>
    [JsonProperty("escalation_time")]
    public int EscalationTime { get; set; }
}