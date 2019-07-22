using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Freshdesk
{
    /// <summary>
    /// Agents in Freshdesk can be “full-time” or “occasional”. Full time agents are those in your core support team who will log in to your help desk every day. Occasional agents are those who would only need to log in a few times every month, such as the CEO or field staff.
    /// https://developers.freshdesk.com/api/#agents
    /// </summary>
    public class Agent
    {
        /// <summary>If the agent is in a group that has enabled "Automatic Ticket Assignment", this attribute will be set to true if the agent is accepting new tickets.</summary>
        [JsonProperty("available")]
        public bool Available { get; set; } = false;

        /// <summary>Timestamp that denotes when the agent became available/unavailable.</summary>
        [JsonProperty("available_since")]
        public DateTime? AvailableSince { get; set; } = null;

        /// <summary></summary>
        [JsonProperty("contact")]
        public AgentContact Contact { get; set; } = new AgentContact();

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; } = null;
        
        /// <summary>Group IDs associated with the agent.</summary>
        [JsonProperty("group_ids")]
        public List<long> GroupIDs { get; set; } = new List<long>();

        /// <summary>User ID of the agent.</summary>
        [JsonProperty("id")]
        public long ID { get; set; } = 0;

        /// <summary>Set to true if this is an occasional agent.</summary>
        [JsonProperty("occasional")]
        public bool Occasional { get; set; } = false;

        /// <summary>Role IDs associated with the agent.</summary>
        [JsonProperty("role_ids")]
        public List<long> RoleIDs { get; set; } = new List<long>();

        /// <summary>Signature of the agent in HTML format.</summary>
        [JsonProperty("signature")]
        public string Signature { get; set; } = "";

        /// <summary>Ticket permission of the agent.</summary>
        [JsonProperty("ticket_scope")]
        public AgentTicketScope TicketScope { get; set; } = AgentTicketScope.Unknown;

        /// <summary></summary>
        [JsonProperty("type")]
        public string Type { get; set; } = "";

        /// <summary>Agent updated timestamp.</summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; } = null;
    }
}
