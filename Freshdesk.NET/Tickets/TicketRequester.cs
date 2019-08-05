using Newtonsoft.Json;

namespace Freshdesk
{
    /// <summary>
    /// A contact is a customer or a potential customer who has raised a support ticket through any channel.
    /// https://developers.freshdesk.com/api/#contacts
    /// </summary>
    public class TicketRequester
    {
        /// <summary>Primary email address of the contact. If you want to associate additional email(s) with this contact, use the other_emails attribute.</summary>
        [JsonProperty("email")]
        public string Email { get; set; } = "";

        /// <summary>ID of the contact.</summary>
        [JsonProperty("id")]
        public long ID { get; set; } = 0;

        /// <summary>Mobile number of the contact.</summary>
        [JsonProperty("mobile")]
        public string Mobile { get; set; } = "";

        /// <summary>Name of the contact.</summary>
        [JsonProperty("name")]
        public string Name { get; set; } = "";

        /// <summary>Telephone number of the contact.</summary>
        [JsonProperty("phone")]
        public string Phone { get; set; } = "";
    }
}