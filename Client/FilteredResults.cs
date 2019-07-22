using System;
using Newtonsoft.Json;

namespace Freshdesk
{
    public class FilteredResults<T> where T : class, new()
    {
        [JsonProperty("total")]
        public int Total;

        [JsonProperty("results")]
        public T Results;
    }
}
