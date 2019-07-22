using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Freshdesk
{
    public class Conversation
    {
        /// <summary></summary>
        [JsonProperty("attachments")]
        public List<object> Attachments { get; set; } = new List<object>();

        /// <summary></summary>
        [JsonProperty("bcc_emails")]
        public List<string> BccEmails { get; set; } = new List<string>();

        /// <summary></summary>
        [JsonProperty("body")]
        public string Body { get; set; } = "";

        /// <summary></summary>
        [JsonProperty("body_text")]
        public string BodyText { get; set; } = "";

        /// <summary></summary>
        [JsonProperty("category")]
        public int Category { get; set; } = 0;

        /// <summary></summary>
        [JsonProperty("cc_emails")]
        public List<string> CcEmails { get; set; } = new List<string>();

        /// <summary></summary>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; } = null;

        /// <summary></summary>
        [JsonProperty("email_failure_count")]
        public int EmailFailureCount { get; set; } = 0;

        /// <summary></summary>
        [JsonProperty("from_email")]
        public string FromEmail { get; set; } = "";

        /// <summary></summary>
        [JsonProperty("id")]
        public long ID { get; set; } = 0;

        /// <summary></summary>
        [JsonProperty("incoming")]
        public bool Incoming { get; set; } = false;

        /// <summary></summary>
        [JsonProperty("outgoing_failures")]
        public int OutgoingFailures { get; set; } = 0;

        /// <summary></summary>
        [JsonProperty("private")]
        public bool Private { get; set; } = false;

        /// <summary></summary>
        [JsonProperty("source")]
        public ConversationSource Source { get; set; } = ConversationSource.Unknown;

        /// <summary></summary>
        [JsonProperty("source_additional_info")]
        public string SourceAdditionalInfo { get; set; } = "";

        /// <summary></summary>
        [JsonProperty("support_email")]
        public string SupportEmail { get; set; } = "";

        /// <summary></summary>
        [JsonProperty("ticket_id")]
        public long TicketID { get; set; } = 0;

        /// <summary></summary>
        [JsonProperty("to_emails")]
        public List<string> ToEmails { get; set; } = new List<string>();

        /// <summary></summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; } = null;

        /// <summary></summary>
        [JsonProperty("user_id")]
        public long UserID { get; set; } = 0;
    }
}
