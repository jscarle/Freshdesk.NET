using Newtonsoft.Json;

namespace Freshdesk
{
    /// <summary>
    /// </summary>
    public class SlaTargetDetails
    {
        /// <summary></summary>
        [JsonProperty("business_hours")]
        public bool BusinessHours { get; set; } = false;

        /// <summary></summary>
        [JsonProperty("escalation_enabled")]
        public bool EscalationEnabled { get; set; } = false;

        /// <summary></summary>
        [JsonProperty("resolve_within")]
        public int ResolveWithin { get; set; } = 0;

        /// <summary></summary>
        [JsonProperty("respond_within")]
        public int RespondWithin { get; set; } = 0;
    }
}