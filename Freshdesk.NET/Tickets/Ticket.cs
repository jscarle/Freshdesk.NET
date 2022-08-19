﻿using System;
using System.Collections.Generic;
using Freshdesk.Conversations;
using Freshdesk.Core;
using Freshdesk.SlaPolicies;
using Newtonsoft.Json;

namespace Freshdesk.Tickets;

public class Ticket
{
    /// <summary></summary>
    [JsonProperty("associated_tickets_count")]
    public int AssociatedTicketsCount { get; set; }

    /// <summary></summary>
    [JsonProperty("associated_tickets_list")]
    public List<long> AssociatedTicketsList { get; set; } = new();

    /// <summary></summary>
    [JsonProperty("association_type")]
    public TicketAssociationType AssociationType { get; set; } = TicketAssociationType.Unknown;

    /// <summary>Ticket attachments. The total size of these attachments cannot exceed 15MB.</summary>
    [JsonProperty("attachments")]
    public List<object> Attachments { get; set; } = new();

    /// <summary>Email address added in the 'cc' field of the incoming ticket email.</summary>
    [JsonProperty("cc_emails")]
    public List<string> CcEmails { get; set; } = new();

    /// <summary></summary>
    [JsonProperty("company")]
    public TicketCompany Company { get; set; }

    /// <summary>ID of the company to which this ticket belongs.</summary>
    [JsonProperty("company_id")]
    public long CompanyId { get; set; }

    /// <summary></summary>
    [JsonProperty("conversations")]
    public List<Conversation> Conversations { get; set; } = new();

    /// <summary>Ticket creation timestamp.</summary>
    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>Key value pairs containing the names and values of custom fields. </summary>
    [JsonProperty("custom_fields")]
    public CustomFields CustomFields { get; set; } = new();

    /// <summary>Set to true if the ticket has been deleted/trashed. Deleted tickets will not be displayed in any views except the "deleted" filter.</summary>
    [JsonProperty("deleted")]
    public bool Deleted { get; set; }

    /// <summary>HTML content of the ticket.</summary>
    [JsonProperty("description")]
    public string Description { get; set; } = "";

    /// <summary>Content of the ticket in plain text.</summary>
    [JsonProperty("description_text")]
    public string DescriptionText { get; set; } = "";

    /// <summary>Timestamp that denotes when the ticket is due to be resolved.</summary>
    [JsonProperty("due_by")]
    public DateTime? DueBy { get; set; }

    /// <summary>ID of email config which is used for this ticket.</summary>
    [JsonProperty("email_config_id")]
    public long EmailConfigId { get; set; }

    /// <summary>Timestamp that denotes when the first response is due.</summary>
    [JsonProperty("fr_due_by")]
    public DateTime? FrDueBy { get; set; }

    /// <summary>Set to true if the ticket has been escalated as the result of first response time being breached.</summary>
    [JsonProperty("fr_escalated")]
    public bool FrEscalated { get; set; }

    /// <summary>Email address(e)s added while forwarding a ticket.</summary>
    [JsonProperty("fwd_emails")]
    public List<string> FwdEmails { get; set; } = new();

    /// <summary>ID of the group to which the ticket has been assigned.</summary>
    [JsonProperty("group_id")]
    public long GroupId { get; set; }

    /// <summary>Unique ID of the ticket.</summary>
    [JsonProperty("id")]
    public long Id { get; set; }

    /// <summary>Set to true if the ticket has been escalated for any reason.</summary>
    [JsonProperty("is_escalated")]
    public bool IsEscalated { get; set; }

    /// <summary>Priority of the ticket.</summary>
    [JsonProperty("priority")]
    public TicketPriority Priority { get; set; } = TicketPriority.Unknown;

    /// <summary>ID of the product to which the ticket is associated.</summary>
    [JsonProperty("product_id")]
    public long ProductId { get; set; }

    /// <summary>Email address added while replying to a ticket.</summary>
    [JsonProperty("reply_cc_emails")]
    public List<string> ReplyCcEmails { get; set; } = new();

    /// <summary></summary>
    [JsonProperty("requester")]
    public TicketRequester Requester { get; set; }

    /// <summary>User ID of the requester. For existing contacts, the requester_id can be passed instead of the requester's email.</summary>
    [JsonProperty("requester_id")]
    public long RequesterId { get; set; }

    /// <summary>ID of the agent to whom the ticket has been assigned.</summary>
    [JsonProperty("responder_id")]
    public long ResponderId { get; set; }

    /// <summary></summary>
    [JsonProperty("sla_policy")]
    public SlaPolicy SlaPolicy { get; set; }

    /// <summary>The channel through which the ticket was created.</summary>
    [JsonProperty("source")]
    public TicketSource Source { get; set; } = TicketSource.Unknown;

    /// <summary></summary>
    [JsonProperty("source_additional_info")]
    public string SourceAdditionalInfo { get; set; } = "";

    /// <summary>Set to true if the ticket has been marked as spam.</summary>
    [JsonProperty("spam")]
    public bool Spam { get; set; }

    /// <summary></summary>
    [JsonProperty("stats")]
    public TicketStats Stats { get; set; }

    /// <summary>Status of the ticket.</summary>
    [JsonProperty("status")]
    public TicketStatus Status { get; set; } = TicketStatus.Unknown;

    /// <summary>Subject of the ticket.</summary>
    [JsonProperty("subject")]
    public string Subject { get; set; } = "";

    /// <summary>Tags that have been associated with the ticket.</summary>
    [JsonProperty("tags")]
    public List<string> Tags { get; set; } = new();

    /// <summary></summary>
    [JsonProperty("ticket_cc_emails")]
    public List<string> TicketCcEmails { get; set; } = new();

    /// <summary>Email addresses to which the ticket was originally sent.</summary>
    [JsonProperty("to_emails")]
    public List<string> ToEmails { get; set; } = new();

    /// <summary>Helps categorize the ticket according to the different kinds of issues your support team deals with.</summary>
    [JsonProperty("type")]
    public string Type { get; set; } = "";

    /// <summary>Ticket updated timestamp.</summary>
    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}