using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using RestSharp;

namespace Freshdesk
{
    public partial class FreshdeskClient
    {
        public (Response, List<Contact>) GetContacts() => GetContacts(null);

        public (Response, List<Contact>) GetContacts(NameValueCollection filter)
        {
            RestRequest request = new RestRequest($"api/v2/contacts{filter?.ToQueryString()}", Method.GET);
            return client.Execute<List<Contact>>(request);
        }

        public (Response, List<Contact>) SearchContacts(string query)
        {
            if (String.IsNullOrWhiteSpace(query))
                throw new ArgumentException($"{nameof(query)} cannot be empty.");

            if (query.Length > 512)
                throw new ArgumentException($"{nameof(query)} cannot exceed 512 characters.");

            RestRequest request = new RestRequest($"api/v2/search/contacts?query=\"{Uri.EscapeDataString(query)}\"", Method.GET);
            return client.ExecuteSearch<List<Contact>>(request);
        }

        public (Response, Contact) GetContact(long contactID)
        {
            if (contactID <= 0)
                throw new ArgumentException($"{nameof(contactID)} must be a positive {contactID.GetType().Name}.");

            RestRequest request = new RestRequest($"api/v2/contacts/{contactID}", Method.GET);
            return client.Execute<Contact>(request);
        }

        public (Response, Contact) CreateContact(NewContact contact)
        {
            if (contact == null)
                throw new ArgumentNullException($"{nameof(contact)} cannot be null.");

            RestRequest request = new RestRequest("api/v2/contacts", Method.POST);
            request.AddJsonBody(contact);
            return client.Execute<Contact>(request);
        }

        public (Response, Contact) UpdateContact(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException($"{nameof(contact)} cannot be null.");

            RestRequest request = new RestRequest($"api/v2/contacts/{contact.ID}", Method.PUT);
            request.AddJsonBody(new ContactUpdate(contact));
            return client.Execute<Contact>(request);
        }

        public Response DeleteContact(long contactID) => DeleteContact(contactID, false);

        public Response DeleteContact(long contactID, bool permanently)
        {
            if (contactID <= 0)
                throw new ArgumentException($"{nameof(contactID)} must be a positive {contactID.GetType().Name}.");

            RestRequest request = new RestRequest(permanently ? $"api/v2/contacts/{contactID}/hard_delete?force=true" : $"api/v2/contacts/{contactID}", Method.DELETE);
            return client.Execute(request);
        }
    }
}