using System;
using Newtonsoft.Json;

namespace Freshdesk
{
    /// <summary>
    /// A contact is a customer or a potential customer who has raised a support ticket through any channel.
    /// https://developers.freshdesk.com/api/#contacts
    /// </summary>
    public class AgentContact
    {
        /// <summary>Set to true if the agent is verified.</summary>
        [JsonProperty("active")]
        public bool Active { get; set; } = false;

        /// <summary>Creation timestamp.</summary>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; } = null;

        /// <summary>Email address of the agent.</summary>
        [JsonProperty("email")]
        public string Email { get; set; } = "";

        /// <summary>Job title of the agent.</summary>
        [JsonProperty("job_title")]
        public string JobTitle { get; set; } = "";

        /// <summary>Language of the agent.</summary>
        [JsonProperty("language")]
        public ContactLanguage Language { get; set; } = ContactLanguage.Unknown;

        /// <summary>Timestamp of the agent's last successful login.</summary>
        [JsonProperty("last_login_at")]
        public DateTime? LastLoginAt { get; set; } = null;

        /// <summary>Mobile number of the agent.</summary>
        [JsonProperty("mobile")]
        public string Mobile { get; set; } = "";

        /// <summary>Name of the agent.</summary>
        [JsonProperty("name")]
        public string Name { get; set; } = "";

        /// <summary>Telephone number of the agent.</summary>
        [JsonProperty("phone")]
        public string Phone { get; set; } = "";

        /// <summary>Time zone of the agent.</summary>
        [JsonProperty("time_zone")]
        public ContactTimeZone TimeZone { get; set; } = ContactTimeZone.Unknown;

        /// <summary>Timestamp of the last update.</summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; } = null;
    }
}
