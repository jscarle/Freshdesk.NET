using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace Freshdesk
{
    public partial class FreshdeskClient
    {
        public (Response, List<Contact>) GetContacts()
            => GetContactsAsync().WaitAndUnwrapException<(Response, List<Contact>)>();

        public async Task<(Response, List<Contact>)> GetContactsAsync(CancellationToken cancellationToken = default)
            => await GetContactsAsync(null, cancellationToken).ConfigureAwait(false);

        public (Response, List<Contact>) GetContacts(NameValueCollection filter)
            => GetContactsAsync(filter).WaitAndUnwrapException<(Response, List<Contact>)>();

        public async Task<(Response, List<Contact>)> GetContactsAsync(NameValueCollection filter, CancellationToken cancellationToken = default)
        {
            RestRequest request = new RestRequest($"api/v2/contacts{filter?.ToQueryString()}", Method.GET);
            return await client.ExecuteTaskAsync<List<Contact>>(request, cancellationToken).ConfigureAwait(false);
        }

        public (Response, List<Contact>) SearchContacts(string query)
            => SearchContactsAsync(query).WaitAndUnwrapException<(Response, List<Contact>)>();

        public async Task<(Response, List<Contact>)> SearchContactsAsync(string query, CancellationToken cancellationToken = default)
        {
            if (String.IsNullOrWhiteSpace(query))
                throw new ArgumentException($"{nameof(query)} cannot be empty.");

            if (query.Length > 512)
                throw new ArgumentException($"{nameof(query)} cannot exceed 512 characters.");

            RestRequest request = new RestRequest($"api/v2/search/contacts?query=\"{Uri.EscapeDataString(query)}\"", Method.GET);
            return await client.ExecuteSearchTaskAsync<List<Contact>>(request, cancellationToken).ConfigureAwait(false);
        }

        public (Response, Contact) GetContact(long contactID)
            => GetContactAsync(contactID).WaitAndUnwrapException<(Response, Contact)>();

        public async Task<(Response, Contact)> GetContactAsync(long contactID, CancellationToken cancellationToken = default)
        {
            if (contactID <= 0)
                throw new ArgumentException($"{nameof(contactID)} must be a positive {contactID.GetType().Name}.");

            RestRequest request = new RestRequest($"api/v2/contacts/{contactID}", Method.GET);
            return await client.ExecuteTaskAsync<Contact>(request, cancellationToken).ConfigureAwait(false);
        }

        public (Response, Contact) CreateContact(NewContact contact)
            => CreateContactAsync(contact).WaitAndUnwrapException<(Response, Contact)>();

        public async Task<(Response, Contact)> CreateContactAsync(NewContact contact, CancellationToken cancellationToken = default)
        {
            if (contact == null)
                throw new ArgumentNullException($"{nameof(contact)} cannot be null.");

            RestRequest request = new RestRequest("api/v2/contacts", Method.POST);
            request.AddJsonBody(contact);
            return await client.ExecuteTaskAsync<Contact>(request, cancellationToken).ConfigureAwait(false);
        }

        public (Response, Contact) UpdateContact(Contact contact)
            => UpdateContactAsync(contact).WaitAndUnwrapException<(Response, Contact)>();

        public async Task<(Response, Contact)> UpdateContactAsync(Contact contact, CancellationToken cancellationToken = default)
        {
            if (contact == null)
                throw new ArgumentNullException($"{nameof(contact)} cannot be null.");

            RestRequest request = new RestRequest($"api/v2/contacts/{contact.ID}", Method.PUT);
            request.AddJsonBody(new ContactUpdate(contact));
            return await client.ExecuteTaskAsync<Contact>(request, cancellationToken).ConfigureAwait(false);
        }

        public Response DeleteContact(long contactID)
            => DeleteContactAsync(contactID).WaitAndUnwrapException<Response>();

        public async Task<Response> DeleteContactAsync(long contactID, CancellationToken cancellationToken = default)
            => await DeleteContactAsync(contactID, false, cancellationToken).ConfigureAwait(false);

        public Response DeleteContact(long contactID, bool permanently)
            => DeleteContactAsync(contactID, permanently).WaitAndUnwrapException<Response>();

        public async Task<Response> DeleteContactAsync(long contactID, bool permanently, CancellationToken cancellationToken = default)
        {
            if (contactID <= 0)
                throw new ArgumentException($"{nameof(contactID)} must be a positive {contactID.GetType().Name}.");

            RestRequest request = new RestRequest(permanently ? $"api/v2/contacts/{contactID}/hard_delete?force=true" : $"api/v2/contacts/{contactID}", Method.DELETE);
            return await client.ExecuteTaskAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}