using Newtonsoft.Json;

namespace Freshdesk
{
    /// <summary>
    /// </summary>
    public class SlaTarget
    {
        /// <summary></summary>
        [JsonProperty("priority_3")]
        public SlaTargetDetails High { get; set; } = null;

        /// <summary></summary>
        [JsonProperty("priority_1")]
        public SlaTargetDetails Low { get; set; } = null;

        /// <summary></summary>
        [JsonProperty("priority_2")]
        public SlaTargetDetails Medium { get; set; } = null;

        /// <summary></summary>
        [JsonProperty("priority_4")]
        public SlaTargetDetails Urgent { get; set; } = null;
    }
}