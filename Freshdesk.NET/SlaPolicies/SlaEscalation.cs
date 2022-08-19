using Newtonsoft.Json;

namespace Freshdesk.SlaPolicies;

/// <summary>
/// </summary>
public class SlaEscalation
{
    /// <summary></summary>
    [JsonProperty("resolution")]
    public SlaEscalationLevels Resolution { get; set; }

    /// <summary></summary>
    [JsonProperty("reminder_resolution")]
    public SlaEscalationLevels ResolutionReminder { get; set; }

    /// <summary></summary>
    [JsonProperty("response")]
    public SlaEscalationAgents Response { get; set; }

    /// <summary></summary>
    [JsonProperty("reminder_response")]
    public SlaEscalationLevels ResponseReminder { get; set; }
}