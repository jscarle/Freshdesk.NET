using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization;

namespace Freshdesk;

public partial class FreshdeskClient
{
    private class CustomSerializer : IRestSerializer
    {
        public string Serialize(object obj) =>
            JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CustomContractResolver()
            });

        public string Serialize(Parameter parameter) =>
            JsonConvert.SerializeObject(parameter.Value, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CustomContractResolver()
            });

        public T Deserialize<T>(IRestResponse response) =>
            JsonConvert.DeserializeObject<T>(response.Content, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

        public string[] SupportedContentTypes { get; } =
            { "application/json", "text/json", "text/x-json", "text/javascript", "*+json" };

        public string ContentType { get; set; } =
            "application/json";

        public DataFormat DataFormat { get; } =
            DataFormat.Json;
    }
}