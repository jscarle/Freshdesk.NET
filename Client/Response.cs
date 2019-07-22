using System;
using System.Net;
using RestSharp;

namespace Freshdesk
{
    public struct Response
    {
        public HttpStatusCode StatusCode { get; }

        public Error Error { get; }

        private readonly RateLimit _rateLimit;
        public RateLimit RateLimit { get { return _rateLimit; } }

        public Response(IRestResponse response)
            : this(response, null) { }

        public Response(IRestResponse response, Error error)
        {
            StatusCode = response.StatusCode;

            Error = error;

            _rateLimit = new RateLimit();
            foreach (Parameter header in response.Headers)
            {
                switch (header.Name.ToLower())
                {
                    case "x-ratelimit-total":
                        _rateLimit.Total = Convert.ToInt32(header.Value);
                        break;
                    case "x-ratelimit-remaining":
                        _rateLimit.Remaining = Convert.ToInt32(header.Value);
                        break;
                    case "x-ratelimit-used-currentrequest":
                        _rateLimit.Used = Convert.ToInt32(header.Value);
                        break;
                    case "retry-after":
                        _rateLimit.RetryAfter = Convert.ToInt32(header.Value);
                        break;
                }
            }
        }
    }
}
