using System.Collections.Generic;
using Newtonsoft.Json;

namespace Freshdesk.Core;

public class Error
{
    [JsonProperty("description")]
    public string Description { get; set; } = "";

    [JsonProperty("errors")]
    public List<ErrorField> Errors { get; set; } = new();
}