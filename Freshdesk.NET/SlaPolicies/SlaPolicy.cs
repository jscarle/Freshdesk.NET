using System;
using Newtonsoft.Json;

namespace Freshdesk
{
    /// <summary>
    /// </summary>
    public class SlaPolicy
    {
        /// <summary></summary>
        [JsonProperty("active")]
        public bool Active { get; set; } = false;

        /// <summary></summary>
        [JsonProperty("applicable_to")]
        public SlaApplicableTo ApplicableTo { get; set; } = null;

        /// <summary></summary>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; } = null;

        /// <summary></summary>
        [JsonProperty("description")]
        public string Description { get; set; } = "";

        /// <summary></summary>
        [JsonProperty("escalation")]
        public SlaEscalation Escalation { get; set; } = null;

        /// <summary></summary>
        [JsonProperty("id")]
        public long ID { get; set; } = 0;

        /// <summary></summary>
        [JsonProperty("is_default")]
        public bool IsDefault { get; set; } = false;

        /// <summary></summary>
        [JsonProperty("name")]
        public string Name { get; set; } = "";

        /// <summary></summary>
        [JsonProperty("position")]
        public int Position { get; set; } = 0;

        /// <summary></summary>
        [JsonProperty("sla_target")]
        public SlaTarget SLATarget { get; set; } = null;

        /// <summary></summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; } = null;
    }
}