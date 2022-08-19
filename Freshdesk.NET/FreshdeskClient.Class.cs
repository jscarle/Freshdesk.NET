using System;
using RestSharp.Authenticators;

namespace Freshdesk;

public partial class FreshdeskClient
{
    private readonly CustomRestClient _client;

    public FreshdeskClient(string domainName, string username, string password)
    {
        _client = (CustomRestClient)new CustomRestClient().UseSerializer(() => new CustomSerializer());
        _client.BaseUrl = new Uri($@"https://{domainName}");
        _client.Authenticator = new HttpBasicAuthenticator(username, password);
    }
}