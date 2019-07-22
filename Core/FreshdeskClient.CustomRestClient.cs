using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;


namespace Freshdesk
{
    public partial class FreshdeskClient
    {
        private class CustomRestClient : RestClient
        {
            private const int PAGESIZE_MAXIMUM = 100;
            // Not currently used: private const int PAGESIZE_DEFAULT = 30;
            private const int PAGES_RECOMMENDEDLIMIT = 500;
            private const int PAGES_FILTEREDLIMIT = 10;

            private readonly JsonSerializerSettings jsonSerializerSettings;

            public CustomRestClient() : base()
            {
                jsonSerializerSettings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                };
            }

            public new Response Execute(IRestRequest request)
            {
                IRestResponse response = base.Execute(request);
                if (!IsSuccessfulRequest(response.StatusCode))
                    return new Response(response, JsonConvert.DeserializeObject<Error>(response.Content, jsonSerializerSettings));

                return new Response(response);
            }

            public new async Task<Response> ExecuteTaskAsync(IRestRequest request, CancellationToken cancellationToken = default)
            {
                IRestResponse response = await base.ExecuteTaskAsync(request, cancellationToken);
                if (!IsSuccessfulRequest(response.StatusCode))
                    return new Response(response, JsonConvert.DeserializeObject<Error>(response.Content, jsonSerializerSettings));

                return new Response(response);
            }

            public new(Response, T) Execute<T>(IRestRequest request) where T : class, new()
            {
                if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(List<>))
                {
                    request.Resource = AppendParametertoUri(request.Resource, "per_page", PAGESIZE_MAXIMUM.ToString());

                    Type genericType = typeof(T).GetGenericTypeDefinition().MakeGenericType(typeof(T).GetGenericArguments().First());
                    IList pagedData = (IList)Activator.CreateInstance(genericType);

                    IRestResponse response = base.Execute(request);
                    if (!IsSuccessfulRequest(response.StatusCode))
                        return (new Response(response, JsonConvert.DeserializeObject<Error>(response.Content, jsonSerializerSettings)), null);

                    foreach (object data in (IEnumerable)JsonConvert.DeserializeObject<T>(response.Content, jsonSerializerSettings))
                        pagedData.Add(data);

                    string nextPageUri = GetNextPageUri(response.Headers);
                    int nextPage = ExtractPageNumber(nextPageUri);

                    while (!String.IsNullOrWhiteSpace(nextPageUri) && nextPage <= PAGES_RECOMMENDEDLIMIT)
                    {
                        request.Resource = nextPageUri;

                        response = base.Execute(request);
                        if (!IsSuccessfulRequest(response.StatusCode))
                            return (new Response(response, JsonConvert.DeserializeObject<Error>(response.Content, jsonSerializerSettings)), null);

                        foreach (object data in (IEnumerable)JsonConvert.DeserializeObject<T>(response.Content, jsonSerializerSettings))
                            pagedData.Add(data);

                        nextPageUri = GetNextPageUri(response.Headers);
                        nextPage = ExtractPageNumber(nextPageUri);
                    }

                    return (new Response(response), (T)pagedData);
                }
                else
                {
                    IRestResponse response = base.Execute(request);
                    if (!IsSuccessfulRequest(response.StatusCode))
                        return (new Response(response, JsonConvert.DeserializeObject<Error>(response.Content, jsonSerializerSettings)), null);

                    return (new Response(response), JsonConvert.DeserializeObject<T>(response.Content, jsonSerializerSettings));
                }
            }

            public new async Task<(Response, T)> ExecuteTaskAsync<T>(IRestRequest request, CancellationToken cancellationToken = default) where T : class, new()
            {
                if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(List<>))
                {
                    request.Resource = AppendParametertoUri(request.Resource, "per_page", PAGESIZE_MAXIMUM.ToString());

                    Type genericType = typeof(T).GetGenericTypeDefinition().MakeGenericType(typeof(T).GetGenericArguments().First());
                    IList pagedData = (IList)Activator.CreateInstance(genericType);

                    IRestResponse response = await base.ExecuteTaskAsync(request, cancellationToken);
                    if (!IsSuccessfulRequest(response.StatusCode))
                        return (new Response(response, JsonConvert.DeserializeObject<Error>(response.Content, jsonSerializerSettings)), null);

                    foreach (object data in (IEnumerable)JsonConvert.DeserializeObject<T>(response.Content, jsonSerializerSettings))
                        pagedData.Add(data);

                    string nextPageUri = GetNextPageUri(response.Headers);
                    int nextPage = ExtractPageNumber(nextPageUri);

                    while (!String.IsNullOrWhiteSpace(nextPageUri) && nextPage <= PAGES_RECOMMENDEDLIMIT)
                    {
                        request.Resource = nextPageUri;

                        response = await base.ExecuteTaskAsync(request, cancellationToken);
                        if (!IsSuccessfulRequest(response.StatusCode))
                            return (new Response(response, JsonConvert.DeserializeObject<Error>(response.Content, jsonSerializerSettings)), null);

                        foreach (object data in (IEnumerable)JsonConvert.DeserializeObject<T>(response.Content, jsonSerializerSettings))
                            pagedData.Add(data);

                        nextPageUri = GetNextPageUri(response.Headers);
                        nextPage = ExtractPageNumber(nextPageUri);
                    }

                    return (new Response(response), (T)pagedData);
                }
                else
                {
                    IRestResponse response = await base.ExecuteTaskAsync(request, cancellationToken);
                    if (!IsSuccessfulRequest(response.StatusCode))
                        return (new Response(response, JsonConvert.DeserializeObject<Error>(response.Content, jsonSerializerSettings)), null);

                    return (new Response(response), JsonConvert.DeserializeObject<T>(response.Content, jsonSerializerSettings));
                }
            }

            public (Response, T) ExecuteSearch<T>(IRestRequest request) where T : class, new()
            {
                request.Resource = AppendParametertoUri(request.Resource, "page", "1");

                Type genericType = typeof(T).GetGenericTypeDefinition().MakeGenericType(typeof(T).GetGenericArguments().First());
                IList pagedData = (IList)Activator.CreateInstance(genericType);

                IRestResponse response = base.Execute(request);
                if (!IsSuccessfulRequest(response.StatusCode))
                    return (new Response(response, JsonConvert.DeserializeObject<Error>(response.Content, jsonSerializerSettings)), null);

                SearchResults<T> initialResults = JsonConvert.DeserializeObject<SearchResults<T>>(response.Content, jsonSerializerSettings);
                foreach (object data in (IEnumerable)initialResults.Results)
                    pagedData.Add(data);

                int pages = (int)Math.Ceiling((decimal)initialResults.Total / (decimal)30);
                if (pages > 10)
                    pages = PAGES_FILTEREDLIMIT;

                for (int page = 2; page <= pages; page++)
                {
                    response = base.Execute(request);
                    if (!IsSuccessfulRequest(response.StatusCode))
                        return (new Response(response, JsonConvert.DeserializeObject<Error>(response.Content, jsonSerializerSettings)), null);

                    SearchResults<T> additionnalResults = JsonConvert.DeserializeObject<SearchResults<T>>(response.Content, jsonSerializerSettings);
                    foreach (object data in (IEnumerable)additionnalResults.Results)
                        pagedData.Add(data);
                }

                return (new Response(response), (T)pagedData);
            }

            public async Task<(Response, T)> ExecuteSearchTaskAsync<T>(IRestRequest request, CancellationToken cancellationToken = default) where T : class, new()
            {
                request.Resource = AppendParametertoUri(request.Resource, "page", "1");

                Type genericType = typeof(T).GetGenericTypeDefinition().MakeGenericType(typeof(T).GetGenericArguments().First());
                IList pagedData = (IList)Activator.CreateInstance(genericType);

                IRestResponse response = await base.ExecuteTaskAsync(request, cancellationToken);
                if (!IsSuccessfulRequest(response.StatusCode))
                    return (new Response(response, JsonConvert.DeserializeObject<Error>(response.Content, jsonSerializerSettings)), null);

                SearchResults<T> initialResults = JsonConvert.DeserializeObject<SearchResults<T>>(response.Content, jsonSerializerSettings);
                foreach (object data in (IEnumerable)initialResults.Results)
                    pagedData.Add(data);

                int pages = (int)Math.Ceiling((decimal)initialResults.Total / (decimal)30);
                if (pages > 10)
                    pages = PAGES_FILTEREDLIMIT;

                for (int page = 2; page <= pages; page++)
                {
                    response = await base.ExecuteTaskAsync(request);
                    if (!IsSuccessfulRequest(response.StatusCode))
                        return (new Response(response, JsonConvert.DeserializeObject<Error>(response.Content, jsonSerializerSettings)), null);

                    SearchResults<T> additionnalResults = JsonConvert.DeserializeObject<SearchResults<T>>(response.Content, jsonSerializerSettings);
                    foreach (object data in (IEnumerable)additionnalResults.Results)
                        pagedData.Add(data);
                }

                return (new Response(response), (T)pagedData);
            }

            private string AppendParametertoUri(string uri, string parameterName, string parameterValue)
            {
                string baseUri = uri;

                NameValueCollection parameters = new NameValueCollection();

                if (uri.Contains("?"))
                {
                    string[] uriParts = uri.Split('?');
                    baseUri = uriParts[0];
                    parameters = QueryToNameValueCollection(uriParts[1]);
                }

                parameters[parameterName] = parameterValue;

                return baseUri + "?" + NameValueCollectionToQuery(parameters);
            }

            private int ExtractPageNumber(string uri)
            {
                if (!uri.Contains("?"))
                    return 0;

                string[] uriParts = uri.Split('?');
                NameValueCollection parameters = QueryToNameValueCollection(uriParts[1]);

                if (!parameters.AllKeys.Contains("page"))
                    return 0;

                return Convert.ToInt32(parameters["page"]);
            }

            private NameValueCollection QueryToNameValueCollection(string query)
            {
                NameValueCollection nameValueCollection = new NameValueCollection();
                foreach (string parameter in Regex.Split(query, "&"))
                {
                    string[] parts = Regex.Split(parameter, "=");
                    if (parts.Length == 2)
                        nameValueCollection.Add(parts[0], parts[1]);
                    else
                        nameValueCollection.Add(parts[0], String.Empty);
                }
                return nameValueCollection;
            }

            private string NameValueCollectionToQuery(NameValueCollection parameters)
            {
                StringBuilder query = new StringBuilder();

                foreach (string key in parameters.Keys)
                {
                    if (String.IsNullOrWhiteSpace(key)) continue;

                    string[] values = parameters.GetValues(key);
                    if (values == null) continue;

                    foreach (string value in values)
                    {
                        if (query.Length > 0)
                            query.Append("&");
                        query.AppendFormat("{0}={1}", Uri.EscapeDataString(key), Uri.EscapeDataString(value));
                    }
                }

                return query.ToString();
            }

            private string GetNextPageUri(IList<Parameter> headers)
            {
                // Based on RFC5988: https://tools.ietf.org/html/rfc5988#page-6

                string uri = "";
                bool isNext = false;
                foreach (Parameter header in headers)
                {
                    if (header.Name.ToLower() == "link")
                    {
                        string headerValue = Convert.ToString(header.Value);
                        if (!String.IsNullOrWhiteSpace(headerValue))
                        {
                            string[] valueParts = headerValue.Split(';');
                            foreach (string valuePart in valueParts)
                            {
                                Match uriMatch = Regex.Match(valuePart, "(?<=<).+?(?=>)", RegexOptions.IgnoreCase);
                                if (uriMatch.Success)
                                    uri = uriMatch.Value;
                                Match relMatch = Regex.Match(valuePart, "(?<=rel=\").+?(?=\")", RegexOptions.IgnoreCase);
                                if (relMatch.Success)
                                    isNext = true;
                            }
                        }
                    }
                }

                if (isNext)
                    return uri;
                else
                    return "";
            }

            private bool IsSuccessfulRequest(HttpStatusCode httpStatusCode)
            {
                switch (httpStatusCode)
                {
                    case HttpStatusCode.OK:
                    case HttpStatusCode.NoContent:
                    case HttpStatusCode.Created:
                        return true;
                }

                return false;
            }

            private struct SearchResults<T> where T : class, new()
            {
                [JsonProperty("total")]
                public int Total { get; set; }

                [JsonProperty("results")]
                public T Results { get; set; }
            }
        }
    }
}
