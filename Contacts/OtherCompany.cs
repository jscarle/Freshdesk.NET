using Newtonsoft.Json;

namespace Freshdesk
{
    /// <summary>
    /// Additional companies associated with the contact.
    /// </summary>
    public class OtherCompany
    {
        /// <summary>Unique ID of the company.</summary>
        [JsonProperty("company_id")]
        public long CompanyID { get; set; } = 0;

        /// <summary>Set to true if the contact can see all tickets that are associated with the company to which he belong.</summary>
        [JsonProperty("view_all_tickets")]
        public bool ViewAllTickets { get; set; } = false;
    }
}
