using System.Collections.Generic;
using Newtonsoft.Json;

namespace Freshdesk
{
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
            public string Email { get; set; } = null;

            /// <summary>Group IDs associated with the agent.</summary>
            [JsonProperty("group_ids")]
            public List<long> GroupIDs { get; set; } = null;

            /// <summary>Job title of the agent.</summary>
            [JsonProperty("job_title")]
            public string JobTitle { get; set; } = null;

            /// <summary>Language of the agent.</summary>
            [JsonProperty("language")]
            public ContactLanguage? Language { get; set; } = null;

            /// <summary>Mobile number of the agent.</summary>
            [JsonProperty("mobile")]
            public string Mobile { get; set; } = null;

            /// <summary>Name of the agent.</summary>
            [JsonProperty("name")]
            public string Name { get; set; } = null;

            /// <summary>Set to true if this is an occasional agent.</summary>
            [JsonProperty("occasional")]
            public bool? Occasional { get; set; } = null;

            /// <summary>Telephone number of the agent.</summary>
            [JsonProperty("phone")]
            public string Phone { get; set; } = null;

            /// <summary>Role IDs associated with the agent.</summary>
            [JsonProperty("role_ids")]
            public List<long> RoleIDs { get; set; } = null;

            /// <summary>Signature of the agent in HTML format.</summary>
            [JsonProperty("signature")]
            public string Signature { get; set; } = null;

            /// <summary>Ticket permission of the agent.</summary>
            [JsonProperty("ticket_scope")]
            public AgentTicketScope? TicketScope { get; set; } = null;

            /// <summary>Time zone of the agent.</summary>
            [JsonProperty("time_zone")]
            public ContactTimeZone? TimeZone { get; set; } = null;

            public AgentUpdate()
            {
            }

            public AgentUpdate(Agent agent)
            {
                Email = agent.Contact.Email;

                if (agent.GroupIDs?.Count > 0)
                    GroupIDs = agent.GroupIDs;

                JobTitle = agent.Contact.JobTitle;

                if (agent.Contact.Language != ContactLanguage.Unknown)
                    Language = agent.Contact.Language;

                Mobile = agent.Contact.Mobile;

                Name = agent.Contact.Name;

                Occasional = agent.Occasional;

                Phone = agent.Contact.Phone;

                if (agent.RoleIDs?.Count > 0)
                    RoleIDs = agent.RoleIDs;

                Signature = agent.Signature;

                if (agent.TicketScope != AgentTicketScope.Unknown)
                    TicketScope = agent.TicketScope;

                if (agent.Contact.TimeZone != ContactTimeZone.Unknown)
                    TimeZone = agent.Contact.TimeZone;
            }
        }
    }
}