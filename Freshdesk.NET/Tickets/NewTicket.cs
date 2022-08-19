using System;
using System.Collections.Generic;
using Freshdesk.Core;
using Newtonsoft.Json;

namespace Freshdesk.Tickets;

public class NewTicket
{
    /// <summary>Ticket attachments. The total size of these attachments cannot exceed 15MB.</summary>
    [JsonProperty("attachments")]
    public List<object> Attachments { get; set; }

    /// <summary>Email address added in the 'cc' field of the incoming ticket email.</summary>
    [JsonProperty("cc_emails")]
    public List<string> CcEmails { get; set; } = new();

    /// <summary>ID of the company to which this ticket belongs.</summary>
    [JsonProperty("company_id")]
    public long? CompanyId { get; set; }

    /// <summary>Key value pairs containing the names and values of custom fields. </summary>
    [JsonProperty("custom_fields")]
    public CustomFields CustomFields { get; set; } = new();

    /// <summary>HTML content of the ticket.</summary>
    [JsonProperty("description")]
    public string Description { get; set; }

    /// <summary>Timestamp that denotes when the ticket is due to be resolved.</summary>
    [JsonProperty("due_by")]
    public DateTime? DueBy { get; set; }

    /// <summary>Email address of the requester. If no contact exists with this email address in Freshdesk, it will be added as a new contact.</summary>
    [JsonProperty("email")]
    public string Email { get; set; }

    /// <summary>ID of email config which is used for this ticket.</summary>
    [JsonProperty("email_config_id")]
    public long? EmailConfigId { get; set; }

    /// <summary>Facebook ID of the requester. A contact should exist with this facebook_id in Freshdesk.</summary>
    [JsonProperty("facebook_id")]
    public string FacebookId { get; set; }

    /// <summary>Timestamp that denotes when the first response is due.</summary>
    [JsonProperty("fr_due_by")]
    public DateTime? FrDueBy { get; set; }

    /// <summary>ID of the group to which the ticket has been assigned.</summary>
    [JsonProperty("group_id")]
    public long? GroupId { get; set; }

    /// <summary>Name of the requester.</summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>Phone number of the requester. If no contact exists with this phone number in Freshdesk, it will be added as a new contact. If the phone number is set and the email address is not, then the name attribute is mandatory.</summary>
    [JsonProperty("phone")]
    public string Phone { get; set; }

    /// <summary>Priority of the ticket.</summary>
    [JsonProperty("priority")]
    public TicketPriority? Priority { get; set; }

    /// <summary>ID of the product to which the ticket is associated.</summary>
    [JsonProperty("product_id")]
    public long? ProductId { get; set; }

    /// <summary>User ID of the requester. For existing contacts, the requester_id can be passed instead of the requester's email.</summary>
    [JsonProperty("requester_id")]
    public long? RequesterId { get; set; }

    /// <summary>ID of the agent to whom the ticket has been assigned.</summary>
    [JsonProperty("responder_id")]
    public long? ResponderId { get; set; }

    /// <summary>The channel through which the ticket was created.</summary>
    [JsonProperty("source")]
    public TicketSource? Source { get; set; }

    /// <summary>Status of the ticket.</summary>
    [JsonProperty("status")]
    public TicketStatus? Status { get; set; }

    /// <summary>Subject of the ticket.</summary>
    [JsonProperty("subject")]
    public string Subject { get; set; }

    /// <summary>Tags that have been associated with the ticket.</summary>
    [JsonProperty("tags")]
    public List<string> Tags { get; set; } = new();

    /// <summary>Twitter handle of the requester. If no contact exists with this handle in Freshdesk, it will be added as a new contact.</summary>
    [JsonProperty("twitter_id")]
    public string TwitterId { get; set; }

    /// <summary>Helps categorize the ticket according to the different kinds of issues your support team deals with.</summary>
    [JsonProperty("type")]
    public string Type { get; set; }
}