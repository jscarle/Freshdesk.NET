using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Freshdesk.Conversations;

public class Conversation
{
    /// <summary></summary>
    [JsonProperty("attachments")]
    public List<object> Attachments { get; set; } = new();

    /// <summary></summary>
    [JsonProperty("bcc_emails")]
    public List<string> BccEmails { get; set; } = new();

    /// <summary></summary>
    [JsonProperty("body")]
    public string Body { get; set; } = "";

    /// <summary></summary>
    [JsonProperty("body_text")]
    public string BodyText { get; set; } = "";

    /// <summary></summary>
    [JsonProperty("category")]
    public int Category { get; set; }

    /// <summary></summary>
    [JsonProperty("cc_emails")]
    public List<string> CcEmails { get; set; } = new();

    /// <summary></summary>
    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary></summary>
    [JsonProperty("email_failure_count")]
    public int EmailFailureCount { get; set; }

    /// <summary></summary>
    [JsonProperty("from_email")]
    public string FromEmail { get; set; } = "";

    /// <summary></summary>
    [JsonProperty("id")]
    public long Id { get; set; }

    /// <summary></summary>
    [JsonProperty("incoming")]
    public bool Incoming { get; set; }

    /// <summary></summary>
    [JsonProperty("outgoing_failures")]
    public int OutgoingFailures { get; set; }

    /// <summary></summary>
    [JsonProperty("private")]
    public bool Private { get; set; }

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
    public long TicketId { get; set; }

    /// <summary></summary>
    [JsonProperty("to_emails")]
    public List<string> ToEmails { get; set; } = new();

    /// <summary></summary>
    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary></summary>
    [JsonProperty("user_id")]
    public long UserId { get; set; }
}