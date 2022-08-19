using System;
using Newtonsoft.Json;

namespace Freshdesk.Tickets;

public class TicketStats
{
    [JsonProperty("agent_responded_at")]
    public DateTime? AgentRespondedAt { get; set; }

    [JsonProperty("closed_at")]
    public DateTime? ClosedAt { get; set; }

    [JsonProperty("first_responded_at")]
    public DateTime? FirstRespondedAt { get; set; }

    [JsonProperty("pending_since")]
    public DateTime? PendingSince { get; set; }

    [JsonProperty("reopened_at")]
    public DateTime? ReopenedAt { get; set; }

    [JsonProperty("requester_responded_at")]
    public DateTime? RequesterRespondedAt { get; set; }

    [JsonProperty("resolved_at")]
    public DateTime? ResolvedAt { get; set; }

    [JsonProperty("status_updated_at")]
    public DateTime? StatusUpdatedAt { get; set; }
}