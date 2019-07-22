using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Freshdesk
{
    /// <summary>
    /// A contact is a customer or a potential customer who has raised a support ticket through any channel.
    /// https://developers.freshdesk.com/api/#contacts
    /// </summary>
    public class NewContact
    {
        /// <summary>Set to true if the contact has been verified.</summary>
        [JsonProperty("active")]
        public bool? Active { get; set; } = null;

        /// <summary>Address of the contact.</summary>
        [JsonProperty("address")]
        public string Address { get; set; } = null;

        /// <summary>Avatar of the contact.</summary>
        [JsonProperty("avatar")]
        public object Avatar { get; set; } = null;

        /// <summary>ID of the primary company to which this contact belongs.</summary>
        [JsonProperty("company_id")]
        public long? CompanyID { get; set; } = null;

        /// <summary>Key value pair containing the name and value of the custom fields.</summary>
        [JsonProperty("custom_fields")]
        public CustomFields CustomFields { get; set; } = new CustomFields();

        /// <summary>A short description of the contact.</summary>
        [JsonProperty("description")]
        public string Description { get; set; } = null;

        /// <summary>Primary email address of the contact. If you want to associate additional email(s) with this contact, use the other_emails attribute.</summary>
        [JsonProperty("email")]
        public string Email { get; set; } = null;

        /// <summary>Job title of the contact.</summary>
        [JsonProperty("job_title")]
        public string JobTitle { get; set; } = null;

        /// <summary>Language of the contact.</summary>
        [JsonProperty("language")]
        public ContactLanguage? Language { get; set; } = null;

        /// <summary>Mobile number of the contact.</summary>
        [JsonProperty("mobile")]
        public string Mobile { get; set; } = null;

        /// <summary>Name of the contact.</summary>
        [JsonProperty("name")]
        public string Name { get; set; } = null;

        /// <summary>Additional companies associated with the contact.</summary>
        [JsonProperty("other_companies")]
        public List<OtherCompany> OtherCompanies { get; set; } = new List<OtherCompany>();

        /// <summary>Additional emails associated with the contact.</summary>
        [JsonProperty("other_emails")]
        public List<string> OtherEmails { get; set; } = new List<string>();

        /// <summary>Telephone number of the contact.</summary>
        [JsonProperty("phone")]
        public string Phone { get; set; } = null;

        /// <summary>Tags associated with this contact.</summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; } = new List<string>();

        /// <summary>Time zone in which the contact resides.</summary>
        [JsonProperty("time_zone")]
        public ContactTimeZone? TimeZone { get; set; } = null;

        /// <summary>Twitter handle of the contact.</summary>
        [JsonProperty("twitter_id")]
        public string TwitterID { get; set; } = null;

        /// <summary>External ID of the contact.</summary>
        [JsonProperty("unique_external_id")]
        public string UniqueExternalID { get; set; } = null;

        /// <summary>Set to true if the contact can see all tickets that are associated with the company to which he belong.</summary>
        [JsonProperty("view_all_tickets")]
        public bool? ViewAllTickets { get; set; } = null;
    }
}
