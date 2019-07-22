using Newtonsoft.Json;

namespace Freshdesk
{
    /// <summary>
    /// </summary>
    public class SlaEscalation
    {
        /// <summary></summary>
        [JsonProperty("resolution")]
        public SlaEscalationLevels Resolution { get; set; } = null;

        /// <summary></summary>
        [JsonProperty("reminder_resolution")]
        public SlaEscalationLevels ResolutionReminder { get; set; } = null;

        /// <summary></summary>
        [JsonProperty("response")]
        public SlaEscalationAgents Response { get; set; } = null;

        /// <summary></summary>
        [JsonProperty("reminder_response")]
        public SlaEscalationLevels ResponseReminder { get; set; } = null;
    }
}
