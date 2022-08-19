using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Freshdesk.Core;
using Newtonsoft.Json;
using RestSharp;

namespace Freshdesk;

public partial class FreshdeskClient
{
    private class CustomRestClient : RestClient
    {
        private const int PagesizeMaximum = 100;

        // Not currently used: private const int PAGESIZE_DEFAULT = 30;
        private const int PagesRecommendedlimit = 500;

        private const int PagesFilteredlimit = 10;

        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public CustomRestClient()
        {
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public new Response Execute(IRestRequest request)
            => ExecuteTaskAsync(request).WaitAndUnwrapException();

        public new async Task<Response> ExecuteTaskAsync(IRestRequest request, CancellationToken cancellationToken = default)
        {
            var response = await ExecuteAsync(request, cancellationToken).ConfigureAwait(false);
            return !IsSuccessfulRequest(response.StatusCode) ? new Response(response, JsonConvert.DeserializeObject<Error>(response.Content, _jsonSerializerSettings)) : new Response(response);
        }

        public new(Response, T) Execute<T>(IRestRequest request)
            where T : class, new()
            => ExecuteTaskAsync<T>(request).WaitAndUnwrapException();

        public new async Task<(Response, T)> ExecuteTaskAsync<T>(IRestRequest request, CancellationToken cancellationToken = default)
            where T : class, new()
        {
            if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(List<>))
            {
                request.Resource = AppendParametertoUri(request.Resource, "per_page", PagesizeMaximum.ToString());

                var genericType = typeof(T).GetGenericTypeDefinition().MakeGenericType(typeof(T).GetGenericArguments().First());
                var pagedData = (IList)Activator.CreateInstance(genericType);

                var response = await ExecuteAsync(request, cancellationToken).ConfigureAwait(false);
                if (!IsSuccessfulRequest(response.StatusCode))
                    return (new Response(response, JsonConvert.DeserializeObject<Error>(response.Content, _jsonSerializerSettings)), null);

                var responseData = JsonConvert.DeserializeObject<T>(response.Content, _jsonSerializerSettings);
                if (responseData is not null)
                    foreach (var data in (IEnumerable)responseData)
                        pagedData.Add(data);

                var nextPageUri = GetNextPageUri(response.Headers);
                var nextPage = ExtractPageNumber(nextPageUri);

                while (!string.IsNullOrWhiteSpace(nextPageUri) && nextPage <= PagesRecommendedlimit)
                {
                    if (cancellationToken.IsCancellationRequested)
                        break;

                    request.Resource = nextPageUri;

                    response = await ExecuteAsync(request, cancellationToken).ConfigureAwait(false);
                    if (!IsSuccessfulRequest(response.StatusCode))
                        return (new Response(response, JsonConvert.DeserializeObject<Error>(response.Content, _jsonSerializerSettings)), null);

                    responseData = JsonConvert.DeserializeObject<T>(response.Content, _jsonSerializerSettings);
                    if (responseData is not null)
                        foreach (var data in (IEnumerable)responseData)
                            pagedData.Add(data);

                    nextPageUri = GetNextPageUri(response.Headers);
                    nextPage = ExtractPageNumber(nextPageUri);
                }

                return (new Response(response), (T)pagedData);
            }
            else
            {
                var response = await ExecuteAsync(request, cancellationToken).ConfigureAwait(false);
                return !IsSuccessfulRequest(response.StatusCode) ? (new Response(response, JsonConvert.DeserializeObject<Error>(response.Content, _jsonSerializerSettings)), null) : (new Response(response), JsonConvert.DeserializeObject<T>(response.Content, _jsonSerializerSettings));
            }
        }

        public (Response, T) ExecuteSearch<T>(IRestRequest request)
            where T : class, new()
            => ExecuteSearchTaskAsync<T>(request).WaitAndUnwrapException();

        public async Task<(Response, T)> ExecuteSearchTaskAsync<T>(IRestRequest request, CancellationToken cancellationToken = default)
            where T : class, new()
        {
            request.Resource = AppendParametertoUri(request.Resource, "page", "1");

            var genericType = typeof(T).GetGenericTypeDefinition().MakeGenericType(typeof(T).GetGenericArguments().First());
            var pagedData = (IList)Activator.CreateInstance(genericType);

            var response = await ExecuteAsync(request, cancellationToken).ConfigureAwait(false);
            if (!IsSuccessfulRequest(response.StatusCode))
                return (new Response(response, JsonConvert.DeserializeObject<Error>(response.Content, _jsonSerializerSettings)), null);

            var initialResults = JsonConvert.DeserializeObject<SearchResults<T>>(response.Content, _jsonSerializerSettings);
            foreach (var data in (IEnumerable)initialResults.Results)
                pagedData.Add(data);

            var pages = (int)Math.Ceiling((decimal)initialResults.Total / (decimal)30);
            if (pages > 10)
                pages = PagesFilteredlimit;

            for (var page = 2; page <= pages; page++)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                response = await ExecuteAsync(request, cancellationToken).ConfigureAwait(false);
                if (!IsSuccessfulRequest(response.StatusCode))
                    return (new Response(response, JsonConvert.DeserializeObject<Error>(response.Content, _jsonSerializerSettings)), null);

                var additionnalResults = JsonConvert.DeserializeObject<SearchResults<T>>(response.Content, _jsonSerializerSettings);
                foreach (var data in (IEnumerable)additionnalResults.Results)
                    pagedData.Add(data);
            }

            return (new Response(response), (T)pagedData);
        }

        private static string AppendParametertoUri(string uri, string parameterName, string parameterValue)
        {
            var baseUri = uri;

            var parameters = new NameValueCollection();

            if (uri.Contains("?"))
            {
                var uriParts = uri.Split('?');
                baseUri = uriParts[0];
                parameters = QueryToNameValueCollection(uriParts[1]);
            }

            parameters[parameterName] = parameterValue;

            return baseUri + "?" + NameValueCollectionToQuery(parameters);
        }

        private static int ExtractPageNumber(string uri)
        {
            if (!uri.Contains("?"))
                return 0;

            var uriParts = uri.Split('?');
            var parameters = QueryToNameValueCollection(uriParts[1]);

            return !parameters.AllKeys.Contains("page") ? 0 : Convert.ToInt32(parameters["page"]);
        }

        private static NameValueCollection QueryToNameValueCollection(string query)
        {
            var nameValueCollection = new NameValueCollection();
            foreach (var parameter in Regex.Split(query, "&"))
            {
                var parts = Regex.Split(parameter, "=");
                nameValueCollection.Add(parts[0], parts.Length == 2 ? parts[1] : string.Empty);
            }
            return nameValueCollection;
        }

        private static string NameValueCollectionToQuery(NameValueCollection parameters)
        {
            var query = new StringBuilder();

            foreach (string key in parameters.Keys)
            {
                if (string.IsNullOrWhiteSpace(key)) continue;

                var values = parameters.GetValues(key);
                if (values is null) continue;

                foreach (var value in values)
                {
                    if (query.Length > 0)
                        query.Append("&");
                    query.AppendFormat("{0}={1}", Uri.EscapeDataString(key), Uri.EscapeDataString(value));
                }
            }

            return query.ToString();
        }

        private static string GetNextPageUri(IEnumerable<Parameter> headers)
        {
            // Based on RFC5988: https://tools.ietf.org/html/rfc5988#page-6

            var uri = "";
            var isNext = false;
            foreach (var header in headers)
            {
                if (header.Name is not null && header.Name.ToLower() != "link")
                    continue;

                var headerValue = Convert.ToString(header.Value);
                if (string.IsNullOrWhiteSpace(headerValue))
                    continue;

                var valueParts = headerValue.Split(';');
                foreach (var valuePart in valueParts)
                {
                    var uriMatch = Regex.Match(valuePart, "(?<=<).+?(?=>)", RegexOptions.IgnoreCase);
                    if (uriMatch.Success)
                        uri = uriMatch.Value;
                    var relMatch = Regex.Match(valuePart, "(?<=rel=\").+?(?=\")", RegexOptions.IgnoreCase);
                    if (relMatch.Success)
                        isNext = true;
                }
            }

            return isNext ? uri : "";
        }

        private static bool IsSuccessfulRequest(HttpStatusCode httpStatusCode)
        {
            return httpStatusCode switch
            {
                HttpStatusCode.OK => true,
                HttpStatusCode.NoContent => true,
                HttpStatusCode.Created => true,
                _ => false
            };
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