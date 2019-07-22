using System;
using System.Net;
using RestSharp;

namespace Freshdesk
{
    public struct Response
    {
        public HttpStatusCode StatusCode { get; }

        public Error Error { get; }

        private readonly RateLimit _queries;
        public RateLimit Queries { get { return _queries; } }

        public Response(IRestResponse response)
            : this(response, null) { }

        public Response(IRestResponse response, Error error)
        {
            StatusCode = response.StatusCode;

            Error = error;

            _queries = new RateLimit();
            foreach (Parameter header in response.Headers)
            {
                switch (header.Name.ToLower())
                {
                    case "x-ratelimit-total":
                        _queries.Total = Convert.ToInt32(header.Value);
                        break;
                    case "x-ratelimit-remaining":
                        _queries.Remaining = Convert.ToInt32(header.Value);
                        break;
                    case "x-ratelimit-used-currentrequest":
                        _queries.Used = Convert.ToInt32(header.Value);
                        break;
                    case "retry-after":
                        _queries.RetryAfter = Convert.ToInt32(header.Value);
                        break;
                }
            }
        }

        public struct RateLimit
        {
            public int Total;
            public int Remaining;
            public int Used;
            public int RetryAfter;
        }
    }
}
