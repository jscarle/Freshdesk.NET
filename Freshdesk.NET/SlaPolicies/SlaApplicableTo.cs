using System.Collections.Generic;
using Newtonsoft.Json;

namespace Freshdesk.SlaPolicies;

/// <summary>
/// </summary>
public class SlaApplicableTo
{
    /// <summary></summary>
    [JsonProperty("company_ids")]
    public List<long> CompanyIds { get; set; } = new();

    /// <summary></summary>
    [JsonProperty("group_ids")]
    public List<long> GroupIds { get; set; } = new();

    /// <summary></summary>
    [JsonProperty("product_ids")]
    public List<long> ProductIds { get; set; } = new();

    /// <summary></summary>
    [JsonProperty("sources")]
    public List<int> Sources { get; set; } = new();

    /// <summary></summary>
    [JsonProperty("ticket_types")]
    public List<string> TicketTypes { get; set; } = new();
}