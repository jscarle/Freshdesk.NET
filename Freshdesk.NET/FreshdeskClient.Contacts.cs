using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;
using Freshdesk.Contacts;
using Freshdesk.Core;
using RestSharp;

namespace Freshdesk;

public partial class FreshdeskClient
{
    public (Response, List<Contact>) GetContacts()
        => GetContacts(null);

    public (Response, List<Contact>) GetContacts(NameValueCollection filter)
    {
        var request = new RestRequest($"api/v2/contacts{filter?.ToQueryString()}", Method.GET);
        return _client.Execute<List<Contact>>(request);
    }

    public async Task<(Response, List<Contact>)> GetContactsAsync(CancellationToken cancellationToken = default)
        => await GetContactsAsync(null, cancellationToken).ConfigureAwait(false);

    public async Task<(Response, List<Contact>)> GetContactsAsync(NameValueCollection filter, CancellationToken cancellationToken = default)
    {
        var request = new RestRequest($"api/v2/contacts{filter?.ToQueryString()}", Method.GET);
        return await _client.ExecuteTaskAsync<List<Contact>>(request, cancellationToken).ConfigureAwait(false);
    }

    public (Response, List<Contact>) SearchContacts(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            throw new ArgumentException($"{nameof(query)} cannot be empty.");

        if (query.Length > 512)
            throw new ArgumentException($"{nameof(query)} cannot exceed 512 characters.");

        var request = new RestRequest($"api/v2/search/contacts?query=\"{Uri.EscapeDataString(query)}\"", Method.GET);
        return _client.ExecuteSearch<List<Contact>>(request);
    }

    public async Task<(Response, List<Contact>)> SearchContactsAsync(string query, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(query))
            throw new ArgumentException($"{nameof(query)} cannot be empty.");

        if (query.Length > 512)
            throw new ArgumentException($"{nameof(query)} cannot exceed 512 characters.");

        var request = new RestRequest($"api/v2/search/contacts?query=\"{Uri.EscapeDataString(query)}\"", Method.GET);
        return await _client.ExecuteSearchTaskAsync<List<Contact>>(request, cancellationToken).ConfigureAwait(false);
    }

    public (Response, Contact) GetContact(long contactId)
    {
        if (contactId <= 0)
            throw new ArgumentException($"{nameof(contactId)} must be a positive {contactId.GetType().Name}.");

        var request = new RestRequest($"api/v2/contacts/{contactId}", Method.GET);
        return _client.Execute<Contact>(request);
    }

    public async Task<(Response, Contact)> GetContactAsync(long contactId, CancellationToken cancellationToken = default)
    {
        if (contactId <= 0)
            throw new ArgumentException($"{nameof(contactId)} must be a positive {contactId.GetType().Name}.");

        var request = new RestRequest($"api/v2/contacts/{contactId}", Method.GET);
        return await _client.ExecuteTaskAsync<Contact>(request, cancellationToken).ConfigureAwait(false);
    }

    public (Response, Contact) CreateContact(NewContact contact)
    {
        if (contact is null)
            throw new ArgumentNullException($"{nameof(contact)} cannot be null.");

        var request = new RestRequest("api/v2/contacts", Method.POST);
        request.AddJsonBody(contact);
        return _client.Execute<Contact>(request);
    }

    public async Task<(Response, Contact)> CreateContactAsync(NewContact contact, CancellationToken cancellationToken = default)
    {
        if (contact is null)
            throw new ArgumentNullException($"{nameof(contact)} cannot be null.");

        var request = new RestRequest("api/v2/contacts", Method.POST);
        request.AddJsonBody(contact);
        return await _client.ExecuteTaskAsync<Contact>(request, cancellationToken).ConfigureAwait(false);
    }

    public (Response, Contact) UpdateContact(Contact contact)
    {
        if (contact is null)
            throw new ArgumentNullException($"{nameof(contact)} cannot be null.");

        var request = new RestRequest($"api/v2/contacts/{contact.Id}", Method.PUT);
        request.AddJsonBody(new ContactUpdate(contact));
        return _client.Execute<Contact>(request);
    }

    public async Task<(Response, Contact)> UpdateContactAsync(Contact contact, CancellationToken cancellationToken = default)
    {
        if (contact is null)
            throw new ArgumentNullException($"{nameof(contact)} cannot be null.");

        var request = new RestRequest($"api/v2/contacts/{contact.Id}", Method.PUT);
        request.AddJsonBody(new ContactUpdate(contact));
        return await _client.ExecuteTaskAsync<Contact>(request, cancellationToken).ConfigureAwait(false);
    }

    public Response DeleteContact(long contactId)
        => DeleteContact(contactId);

    public Response DeleteContact(long contactId, bool permanently)
    {
        if (contactId <= 0)
            throw new ArgumentException($"{nameof(contactId)} must be a positive {contactId.GetType().Name}.");

        var request = new RestRequest(permanently ? $"api/v2/contacts/{contactId}/hard_delete?force=true" : $"api/v2/contacts/{contactId}", Method.DELETE);
        return _client.Execute(request);
    }

    public async Task<Response> DeleteContactAsync(long contactId, CancellationToken cancellationToken = default)
        => await DeleteContactAsync(contactId, false, cancellationToken).ConfigureAwait(false);

    public async Task<Response> DeleteContactAsync(long contactId, bool permanently, CancellationToken cancellationToken = default)
    {
        if (contactId <= 0)
            throw new ArgumentException($"{nameof(contactId)} must be a positive {contactId.GetType().Name}.");

        var request = new RestRequest(permanently ? $"api/v2/contacts/{contactId}/hard_delete?force=true" : $"api/v2/contacts/{contactId}", Method.DELETE);
        return await _client.ExecuteTaskAsync(request, cancellationToken).ConfigureAwait(false);
    }

    public Response RestoreContact(long contactId)
    {
        if (contactId <= 0)
            throw new ArgumentException($"{nameof(contactId)} must be a positive {contactId.GetType().Name}.");

        var request = new RestRequest($"api/v2/contacts/{contactId}/restore", Method.PUT);
        return _client.Execute(request);
    }

    public async Task<Response> RestoreContactAsync(long contactId, CancellationToken cancellationToken = default)
    {
        if (contactId <= 0)
            throw new ArgumentException($"{nameof(contactId)} must be a positive {contactId.GetType().Name}.");

        var request = new RestRequest($"api/v2/contacts/{contactId}/restore", Method.PUT);
        return await _client.ExecuteTaskAsync(request, cancellationToken).ConfigureAwait(false);
    }
}