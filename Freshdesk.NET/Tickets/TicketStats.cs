using System;
using Newtonsoft.Json;

namespace Freshdesk
{
    public class TicketStats
    {
        [JsonProperty("agent_responded_at")]
        public DateTime? AgentRespondedAt { get; set; } = null;

        [JsonProperty("closed_at")]
        public DateTime? ClosedAt { get; set; } = null;

        [JsonProperty("first_responded_at")]
        public DateTime? FirstRespondedAt { get; set; } = null;

        [JsonProperty("pending_since")]
        public DateTime? PendingSince { get; set; } = null;

        [JsonProperty("reopened_at")]
        public DateTime? ReopenedAt { get; set; } = null;

        [JsonProperty("requester_responded_at")]
        public DateTime? RequesterRespondedAt { get; set; } = null;

        [JsonProperty("resolved_at")]
        public DateTime? ResolvedAt { get; set; } = null;

        [JsonProperty("status_updated_at")]
        public DateTime? StatusUpdatedAt { get; set; } = null;
    }
}