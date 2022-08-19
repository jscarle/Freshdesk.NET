﻿using System.Collections.Generic;
using Freshdesk.Agents;
using Freshdesk.Contacts;
using Newtonsoft.Json;

namespace Freshdesk;

public partial class FreshdeskClient
{
    /// <summary>
    /// Agents in Freshdesk can be “full-time” or “occasional”. Full time agents are those in your core support team who will log in to your help desk every day. Occasional agents are those who would only need to log in a few times every month, such as the CEO or field staff.
    /// https://developers.freshdesk.com/api/#agents
    /// </summary>
    private class AgentUpdate
    {
        /// <summary>Email address of the agent.</summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>Group IDs associated with the agent.</summary>
        [JsonProperty("group_ids")]
        public List<long> GroupIds { get; set; }

        /// <summary>Job title of the agent.</summary>
        [JsonProperty("job_title")]
        public string JobTitle { get; set; }

        /// <summary>Language of the agent.</summary>
        [JsonProperty("language")]
        public ContactLanguage? Language { get; set; }

        /// <summary>Mobile number of the agent.</summary>
        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        /// <summary>Name of the agent.</summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>Set to true if this is an occasional agent.</summary>
        [JsonProperty("occasional")]
        public bool? Occasional { get; set; }

        /// <summary>Telephone number of the agent.</summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>Role IDs associated with the agent.</summary>
        [JsonProperty("role_ids")]
        public List<long> RoleIds { get; set; }

        /// <summary>Signature of the agent in HTML format.</summary>
        [JsonProperty("signature")]
        public string Signature { get; set; }

        /// <summary>Ticket permission of the agent.</summary>
        [JsonProperty("ticket_scope")]
        public AgentTicketScope? TicketScope { get; set; }

        /// <summary>Time zone of the agent.</summary>
        [JsonProperty("time_zone")]
        public ContactTimeZone? TimeZone { get; set; }

        public AgentUpdate()
        {
        }

        public AgentUpdate(Agent agent)
        {
            Email = agent.Contact.Email;

            if (agent.GroupIds?.Count > 0)
                GroupIds = agent.GroupIds;

            JobTitle = agent.Contact.JobTitle;

            if (agent.Contact.Language != ContactLanguage.Unknown)
                Language = agent.Contact.Language;

            Mobile = agent.Contact.Mobile;

            Name = agent.Contact.Name;

            Occasional = agent.Occasional;

            Phone = agent.Contact.Phone;

            if (agent.RoleIds?.Count > 0)
                RoleIds = agent.RoleIds;

            Signature = agent.Signature;

            if (agent.TicketScope != AgentTicketScope.Unknown)
                TicketScope = agent.TicketScope;

            if (agent.Contact.TimeZone != ContactTimeZone.Unknown)
                TimeZone = agent.Contact.TimeZone;
        }
    }
}