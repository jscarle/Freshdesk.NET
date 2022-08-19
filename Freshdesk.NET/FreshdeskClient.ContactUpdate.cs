using System.Collections.Generic;
using Freshdesk.Contacts;
using Freshdesk.Core;
using Newtonsoft.Json;

namespace Freshdesk;

public partial class FreshdeskClient
{
    /// <summary>
    /// A contact is a customer or a potential customer who has raised a support ticket through any channel.
    /// https://developers.freshdesk.com/api/#contacts
    /// </summary>
    private class ContactUpdate
    {
        /// <summary>Set to true if the contact has been verified.</summary>
        [JsonProperty("active")]
        public bool? Active { get; set; }

        /// <summary>Address of the contact.</summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>Avatar of the contact.</summary>
        [JsonProperty("avatar")]
        public object Avatar { get; set; }

        /// <summary>ID of the primary company to which this contact belongs.</summary>
        [JsonProperty("company_id")]
        public long? CompanyId { get; set; }

        /// <summary>Key value pair containing the name and value of the custom fields.</summary>
        [JsonProperty("custom_fields")]
        public CustomFields CustomFields { get; set; }

        /// <summary>A short description of the contact.</summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>Primary email address of the contact. If you want to associate additional email(s) with this contact, use the other_emails attribute.</summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>Job title of the contact.</summary>
        [JsonProperty("job_title")]
        public string JobTitle { get; set; }

        /// <summary>Language of the contact.</summary>
        [JsonProperty("language")]
        public ContactLanguage? Language { get; set; }

        /// <summary>Mobile number of the contact.</summary>
        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        /// <summary>Name of the contact.</summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>Additional companies associated with the contact.</summary>
        [JsonProperty("other_companies")]
        public List<OtherCompany> OtherCompanies { get; set; }

        /// <summary>Additional emails associated with the contact.</summary>
        [JsonProperty("other_emails")]
        public List<string> OtherEmails { get; set; }

        /// <summary>Telephone number of the contact.</summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>Tags associated with this contact.</summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        /// <summary>Time zone in which the contact resides.</summary>
        [JsonProperty("time_zone")]
        public ContactTimeZone? TimeZone { get; set; }

        /// <summary>Twitter handle of the contact.</summary>
        [JsonProperty("twitter_id")]
        public string TwitterId { get; set; }

        /// <summary>External ID of the contact.</summary>
        [JsonProperty("unique_external_id")]
        public string UniqueExternalId { get; set; }

        /// <summary>Set to true if the contact can see all tickets that are associated with the company to which he belong.</summary>
        [JsonProperty("view_all_tickets")]
        public bool? ViewAllTickets { get; set; }

        public ContactUpdate()
        {
        }

        public ContactUpdate(Contact contact)
        {
            Active = contact.Active;

            Address = contact.Address;

            Avatar = contact.Avatar;

            CompanyId = contact.CompanyId;

            if (contact.CustomFields?.Count > 0)
                CustomFields = contact.CustomFields;

            Description = contact.Description;

            Email = contact.Email;

            JobTitle = contact.JobTitle;

            if (contact.Language != ContactLanguage.Unknown)
                Language = contact.Language;

            Mobile = contact.Mobile;

            Name = contact.Name;

            if (contact.OtherCompanies?.Count > 0)
                OtherCompanies = contact.OtherCompanies;

            if (contact.OtherEmails?.Count > 0)
                OtherEmails = contact.OtherEmails;

            Phone = contact.Phone;

            if (contact.Tags?.Count > 0)
                Tags = contact.Tags;

            if (contact.TimeZone != ContactTimeZone.Unknown)
                TimeZone = contact.TimeZone;

            TwitterId = contact.TwitterId;

            UniqueExternalId = contact.UniqueExternalId;

            ViewAllTickets = contact.ViewAllTickets;
        }
    }
}