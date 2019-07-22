using System.Collections.Generic;
using Newtonsoft.Json;

namespace Freshdesk
{
    /// <summary>
    /// </summary>
    public class SlaEscalationAgents
    {
        /// <summary></summary>
        [JsonProperty("agent_ids")]
        public List<long> AgentIDs { get; set; } = new List<long>();

        /// <summary></summary>
        [JsonProperty("escalation_time")]
        public int EscalationTime { get; set; } = 0;
    }
}
