using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Freshdesk
{
    public partial class FreshdeskClient
    {
        /// <summary>
        /// When multiple contacts from the same company contact you, it is better to group them into a company. This way, the tickets of the contacts can be mapped to the company. This also enables you to find an alternative person to call/email when a contact is unavailable.
        /// https://developers.freshdesk.com/api/#companies
        /// </summary>
        private class CompanyUpdate
        {
            /// <summary>Classification based on how much value the company brings to your business.</summary>
            [JsonProperty("account_tier")]
            public CompanyAccountTier? AccountTier { get; set; } = null;

            /// <summary>Key value pairs containing the names and values of custom fields.</summary>
            [JsonProperty("custom_fields")]
            public CustomFields CustomFields { get; set; } = null;

            /// <summary>Description of the company.</summary>
            [JsonProperty("description")]
            public string Description { get; set; } = null;

            /// <summary>Domains of the company. Email addresses of contacts that contain this domain will be associated with that company automatically.</summary>
            [JsonProperty("domains")]
            public List<string> Domains { get; set; } = null;

            /// <summary>The strength of your relationship with the company.</summary>
            [JsonProperty("health_score")]
            public CompanyHealthScore? HealthScore { get; set; } = null;

            /// <summary>The industry the company serves in.</summary>
            [JsonProperty("industry")]
            public CompanyIndustry? Industry { get; set; } = null;

            /// <summary>Name of the company.</summary>
            [JsonProperty("name")]
            public string Name { get; set; } = null;

            /// <summary>Any specific note about the company.</summary>
            [JsonProperty("note")]
            public string Note { get; set; } = null;

            /// <summary>Date when your contract or relationship with the company is due for renewal.</summary>
            [JsonProperty("renewal_date")]
            public DateTime? RenewalDate { get; set; } = null;

            public CompanyUpdate()
            {
            }

            public CompanyUpdate(Company company)
            {
                if (company.AccountTier != CompanyAccountTier.Unknown)
                    AccountTier = company.AccountTier;

                if (company.CustomFields?.Count > 0)
                    CustomFields = company.CustomFields;

                Description = company.Description;

                if (company.Domains?.Count > 0)
                    Domains = company.Domains;

                if (company.HealthScore != CompanyHealthScore.Unknown)
                    HealthScore = company.HealthScore;

                if (company.Industry != CompanyIndustry.Unknown)
                    Industry = company.Industry;

                Name = company.Name;

                Note = company.Note;

                RenewalDate = company.RenewalDate;
            }
        }
    }
}