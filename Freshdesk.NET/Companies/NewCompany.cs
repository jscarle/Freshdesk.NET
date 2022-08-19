﻿using System;
using System.Collections.Generic;
using Freshdesk.Core;
using Newtonsoft.Json;

namespace Freshdesk.Companies;

/// <summary>
/// When multiple contacts from the same company contact you, it is better to group them into a company. This way, the tickets of the contacts can be mapped to the company. This also enables you to find an alternative person to call/email when a contact is unavailable.
/// https://developers.freshdesk.com/api/#companies
/// </summary>
public class NewCompany
{
    /// <summary>Classification based on how much value the company brings to your business.</summary>
    [JsonProperty("account_tier")]
    public CompanyAccountTier? AccountTier { get; set; }

    /// <summary>Key value pairs containing the names and values of custom fields.</summary>
    [JsonProperty("custom_fields")]
    public CustomFields CustomFields { get; set; } = new();

    /// <summary>Description of the company.</summary>
    [JsonProperty("description")]
    public string Description { get; set; }

    /// <summary>Domains of the company. Email addresses of contacts that contain this domain will be associated with that company automatically.</summary>
    [JsonProperty("domains")]
    public List<string> Domains { get; set; } = new();

    /// <summary>The strength of your relationship with the company.</summary>
    [JsonProperty("health_score")]
    public CompanyHealthScore? HealthScore { get; set; }

    /// <summary>The industry the company serves in.</summary>
    [JsonProperty("industry")]
    public CompanyIndustry? Industry { get; set; }

    /// <summary>Name of the company.</summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>Any specific note about the company.</summary>
    [JsonProperty("note")]
    public string Note { get; set; }

    /// <summary>Date when your contract or relationship with the company is due for renewal.</summary>
    [JsonProperty("renewal_date")]
    public DateTime? RenewalDate { get; set; }
}