using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Freshdesk
{
    /// <summary>
    /// A contact is a customer or a potential customer who has raised a support ticket through any channel.
    /// https://developers.freshdesk.com/api/#contacts
    /// </summary>
    public class Contact
    {
        /// <summary>Set to true if the contact has been verified.</summary>
        [JsonProperty("active")]
        public bool Active { get; set; } = false;

        /// <summary>Address of the contact.</summary>
        [JsonProperty("address")]
        public string Address { get; set; } = "";

        /// <summary>Avatar of the contact.</summary>
        [JsonProperty("avatar")]
        public object Avatar { get; set; } = null;

        /// <summary>ID of the primary company to which this contact belongs.</summary>
        [JsonProperty("company_id")]
        public long CompanyID { get; set; } = 0;

        /// <summary>Contact creation timestamp.</summary>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; } = null;

        /// <summary>Key value pair containing the name and value of the custom fields.</summary>
        [JsonProperty("custom_fields")]
        public CustomFields CustomFields { get; set; } = new CustomFields();

        /// <summary>Set to true if the contact has been deleted. Note that this attribute will only be present for deleted contacts.</summary>
        [JsonProperty("deleted")]
        public bool Deleted { get; set; } = false;

        /// <summary>A short description of the contact.</summary>
        [JsonProperty("description")]
        public string Description { get; set; } = "";

        /// <summary>Primary email address of the contact. If you want to associate additional email(s) with this contact, use the other_emails attribute.</summary>
        [JsonProperty("email")]
        public string Email { get; set; } = "";

        /// <summary>Facebook ID of the contact.</summary>
        [JsonProperty("facebook_id")]
        public string FacebookID { get; set; } = "";

        /// <summary>ID of the contact.</summary>
        [JsonProperty("id")]
        public long ID { get; set; } = 0;

        /// <summary>Job title of the contact.</summary>
        [JsonProperty("job_title")]
        public string JobTitle { get; set; } = "";

        /// <summary>Language of the contact.</summary>
        [JsonProperty("language")]
        public ContactLanguage Language { get; set; } = ContactLanguage.Unknown;

        /// <summary>Mobile number of the contact.</summary>
        [JsonProperty("mobile")]
        public string Mobile { get; set; } = "";

        /// <summary>Name of the contact.</summary>
        [JsonProperty("name")]
        public string Name { get; set; } = "";

        /// <summary>Additional companies associated with the contact.</summary>
        [JsonProperty("other_companies")]
        public List<OtherCompany> OtherCompanies { get; set; } = new List<OtherCompany>();

        /// <summary>Additional emails associated with the contact.</summary>
        [JsonProperty("other_emails")]
        public List<string> OtherEmails { get; set; } = new List<string>();

        /// <summary>Telephone number of the contact.</summary>
        [JsonProperty("phone")]
        public string Phone { get; set; } = "";

        /// <summary>Tags associated with this contact.</summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; } = new List<string>();

        /// <summary>Time zone in which the contact resides.</summary>
        [JsonProperty("time_zone")]
        public ContactTimeZone TimeZone { get; set; } = ContactTimeZone.Unknown;

        /// <summary>Twitter handle of the contact.</summary>
        [JsonProperty("twitter_id")]
        public string TwitterID { get; set; } = "";

        /// <summary>External ID of the contact.</summary>
        [JsonProperty("unique_external_id")]
        public string UniqueExternalID { get; set; } = "";

        /// <summary>Contact updated timestamp</summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; } = null;

        /// <summary>Set to true if the contact can see all tickets that are associated with the company to which he belong.</summary>
        [JsonProperty("view_all_tickets")]
        public bool ViewAllTickets { get; set; } = false;
    }
}