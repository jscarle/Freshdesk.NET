using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Freshdesk
{
    public class NewTicket
    {
        /// <summary>Ticket attachments. The total size of these attachments cannot exceed 15MB.</summary>
        [JsonProperty("attachments")]
        public List<object> Attachments { get; set; } = null;

        /// <summary>Email address added in the 'cc' field of the incoming ticket email.</summary>
        [JsonProperty("cc_emails")]
        public List<string> CCEmails { get; set; } = new List<string>();

        /// <summary>ID of the company to which this ticket belongs.</summary>
        [JsonProperty("company_id")]
        public long? CompanyID { get; set; } = null;

        /// <summary>Key value pairs containing the names and values of custom fields. </summary>
        [JsonProperty("custom_fields")]
        public CustomFields CustomFields { get; set; } = new CustomFields();

        /// <summary>HTML content of the ticket.</summary>
        [JsonProperty("description")]
        public string Description { get; set; } = null;

        /// <summary>Timestamp that denotes when the ticket is due to be resolved.</summary>
        [JsonProperty("due_by")]
        public DateTime? DueBy { get; set; } = null;

        /// <summary>Email address of the requester. If no contact exists with this email address in Freshdesk, it will be added as a new contact.</summary>
        [JsonProperty("email")]
        public string Email { get; set; } = null;

        /// <summary>ID of email config which is used for this ticket.</summary>
        [JsonProperty("email_config_id")]
        public long? EmailConfigID { get; set; } = null;

        /// <summary>Facebook ID of the requester. A contact should exist with this facebook_id in Freshdesk.</summary>
        [JsonProperty("facebook_id")]
        public string FacebookID { get; set; } = null;

        /// <summary>Timestamp that denotes when the first response is due.</summary>
        [JsonProperty("fr_due_by")]
        public DateTime? FrDueBy { get; set; } = null;

        /// <summary>ID of the group to which the ticket has been assigned.</summary>
        [JsonProperty("group_id")]
        public long? GroupID { get; set; } = null;

        /// <summary>Name of the requester.</summary>
        [JsonProperty("name")]
        public string Name { get; set; } = null;

        /// <summary>Phone number of the requester. If no contact exists with this phone number in Freshdesk, it will be added as a new contact. If the phone number is set and the email address is not, then the name attribute is mandatory.</summary>
        [JsonProperty("phone")]
        public string Phone { get; set; } = null;

        /// <summary>Priority of the ticket.</summary>
        [JsonProperty("priority")]
        public TicketPriority? Priority { get; set; } = null;

        /// <summary>ID of the product to which the ticket is associated.</summary>
        [JsonProperty("product_id")]
        public long? ProductID { get; set; } = null;

        /// <summary>User ID of the requester. For existing contacts, the requester_id can be passed instead of the requester's email.</summary>
        [JsonProperty("requester_id")]
        public long? RequesterID { get; set; } = null;

        /// <summary>ID of the agent to whom the ticket has been assigned.</summary>
        [JsonProperty("responder_id")]
        public long? ResponderID { get; set; } = null;

        /// <summary>The channel through which the ticket was created.</summary>
        [JsonProperty("source")]
        public TicketSource? Source { get; set; } = null;

        /// <summary>Status of the ticket.</summary>
        [JsonProperty("status")]
        public TicketStatus? Status { get; set; } = null;

        /// <summary>Subject of the ticket.</summary>
        [JsonProperty("subject")]
        public string Subject { get; set; } = null;

        /// <summary>Tags that have been associated with the ticket.</summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; } = new List<string>();

        /// <summary>Twitter handle of the requester. If no contact exists with this handle in Freshdesk, it will be added as a new contact.</summary>
        [JsonProperty("twitter_id")]
        public string TwitterID { get; set; } = null;

        /// <summary>Helps categorize the ticket according to the different kinds of issues your support team deals with.</summary>
        [JsonProperty("type")]
        public string Type { get; set; } = null;
    }
}
