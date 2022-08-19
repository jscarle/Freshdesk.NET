using System;
using System.Collections.Generic;
using Freshdesk.Core;
using Freshdesk.Tickets;
using Newtonsoft.Json;

namespace Freshdesk;

public partial class FreshdeskClient
{
    private class TicketUpdate
    {
        /// <summary>Ticket attachments. The total size of these attachments cannot exceed 15MB.</summary>
        [JsonProperty("attachments")]
        public List<object> Attachments { get; set; }

        /// <summary>ID of the company to which this ticket belongs.</summary>
        [JsonProperty("company_id")]
        public long? CompanyId { get; set; }

        /// <summary>Key value pairs containing the names and values of custom fields. </summary>
        [JsonProperty("custom_fields")]
        public CustomFields CustomFields { get; set; }

        /// <summary>HTML content of the ticket.</summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>Timestamp that denotes when the ticket is due to be resolved.</summary>
        [JsonProperty("due_by")]
        public DateTime? DueBy { get; set; }

        /// <summary>ID of email config which is used for this ticket.</summary>
        [JsonProperty("email_config_id")]
        public long? EmailConfigId { get; set; }

        /// <summary>Timestamp that denotes when the first response is due.</summary>
        [JsonProperty("fr_due_by")]
        public DateTime? FrDueBy { get; set; }

        /// <summary>ID of the group to which the ticket has been assigned.</summary>
        [JsonProperty("group_id")]
        public long? GroupId { get; set; }

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
        public List<string> Tags { get; set; }

        /// <summary>Helps categorize the ticket according to the different kinds of issues your support team deals with.</summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        public TicketUpdate()
        {
        }

        public TicketUpdate(Ticket ticket)
        {
            if (ticket.Attachments?.Count > 0)
                Attachments = ticket.Attachments;

            if (ticket.CompanyId > 0)
                CompanyId = ticket.CompanyId;

            if (ticket.CustomFields?.Count > 0)
                CustomFields = ticket.CustomFields;

            Description = ticket.Description;

            DueBy = ticket.DueBy;

            if (ticket.EmailConfigId > 0)
                EmailConfigId = ticket.EmailConfigId;

            FrDueBy = ticket.FrDueBy;

            if (ticket.GroupId > 0)
                GroupId = ticket.GroupId;

            if (ticket.Priority != TicketPriority.Unknown)
                Priority = ticket.Priority;

            if (ticket.ProductId > 0)
                ProductId = ticket.ProductId;

            if (ticket.RequesterId > 0)
                RequesterId = ticket.RequesterId;

            if (ticket.ResponderId > 0)
                ResponderId = ticket.ResponderId;

            if (ticket.Source != TicketSource.Unknown)
                Source = ticket.Source;

            if (ticket.Status != TicketStatus.Unknown)
                Status = ticket.Status;

            Subject = ticket.Subject;

            if (ticket.Tags?.Count > 0)
                Tags = ticket.Tags;

            Type = ticket.Type;
        }
    }
}