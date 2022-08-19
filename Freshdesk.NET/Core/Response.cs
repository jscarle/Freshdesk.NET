using System;
using System.Net;
using RestSharp;

namespace Freshdesk.Core;

public readonly struct Response
{
    public HttpStatusCode StatusCode { get; }

    public Error Error { get; }

    public RateLimit Queries { get; }

    public Response(IRestResponse response, Error error = null)
    {
        StatusCode = response.StatusCode;

        Error = error;

        var total = 0;
        var remaining = 0;
        var used = 0;
        var retryAfter = 0;
        foreach (var header in response.Headers)
        {
            if (header.Name == null)
                continue;

            switch (header.Name.ToLower())
            {
                case "x-ratelimit-total":
                    total = Convert.ToInt32(header.Value);
                    break;

                case "x-ratelimit-remaining":
                    remaining = Convert.ToInt32(header.Value);
                    break;

                case "x-ratelimit-used-currentrequest":
                    used = Convert.ToInt32(header.Value);
                    break;

                case "retry-after":
                    retryAfter = Convert.ToInt32(header.Value);
                    break;
            }
        }
        Queries = new RateLimit(total, remaining, used, retryAfter);
    }

    public struct RateLimit
    {
        public int Total { get; }
            
        public int Remaining { get; }
            
        public int Used { get; }
            
        public int RetryAfter { get; }

        public RateLimit(int total, int remaining, int used, int retryAfter)
        {
            Total = total;
            Remaining = remaining;
            Used = used;
            RetryAfter = retryAfter;
        }
    }
}