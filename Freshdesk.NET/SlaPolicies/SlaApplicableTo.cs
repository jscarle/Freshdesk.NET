using System.Collections.Generic;
using Newtonsoft.Json;

namespace Freshdesk
{
    /// <summary>
    /// </summary>
    public class SlaApplicableTo
    {
        /// <summary></summary>
        [JsonProperty("company_ids")]
        public List<long> CompanyIDs { get; set; } = new List<long>();

        /// <summary></summary>
        [JsonProperty("group_ids")]
        public List<long> GroupIDs { get; set; } = new List<long>();

        /// <summary></summary>
        [JsonProperty("product_ids")]
        public List<long> ProductIDs { get; set; } = new List<long>();

        /// <summary></summary>
        [JsonProperty("sources")]
        public List<int> Sources { get; set; } = new List<int>();

        /// <summary></summary>
        [JsonProperty("ticket_types")]
        public List<string> TicketTypes { get; set; } = new List<string>();
    }
}