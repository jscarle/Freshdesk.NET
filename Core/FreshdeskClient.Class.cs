using System;
using RestSharp.Authenticators;

namespace Freshdesk
{
    public partial class FreshdeskClient
    {
        private readonly CustomRestClient client;

        public FreshdeskClient(string domainName, string username, string password)
        {
            client = (CustomRestClient)new CustomRestClient().UseSerializer(() => new CustomSerializer());
            client.BaseUrl = new Uri("https://" + domainName);
            client.Authenticator = new HttpBasicAuthenticator(username, password);
        }
    }
}