using Newtonsoft.Json;

namespace Freshdesk
{
    /// <summary>
    /// When multiple contacts from the same company contact you, it is better to group them into a company. This way, the tickets of the contacts can be mapped to the company. This also enables you to find an alternative person to call/email when a contact is unavailable.
    /// https://developers.freshdesk.com/api/#companies
    /// </summary>
    public class TicketCompany
    {
        /// <summary>Unique ID of the company.</summary>
        [JsonProperty("id")]
        public long ID { get; set; } = 0;

        /// <summary>Name of the company.</summary>
        [JsonProperty("name")]
        public string Name { get; set; } = "";
    }
}
