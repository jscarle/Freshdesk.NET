using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;
using Freshdesk.Core;
using Freshdesk.Tickets;
using RestSharp;

namespace Freshdesk;

public partial class FreshdeskClient
{
    public (Response, List<Ticket>) GetTickets()
        => GetTickets(null);

    public (Response, List<Ticket>) GetTickets(NameValueCollection filter)
    {
        // include=requester,stats,company,description
        var request = new RestRequest($"api/v2/tickets{filter?.ToQueryString()}", Method.GET);
        return _client.Execute<List<Ticket>>(request);
    }

    public async Task<(Response, List<Ticket>)> GetTicketsAsync(CancellationToken cancellationToken = default)
        => await GetTicketsAsync(null, cancellationToken).ConfigureAwait(false);

    public async Task<(Response, List<Ticket>)> GetTicketsAsync(NameValueCollection filter, CancellationToken cancellationToken = default)
    {
        // include=requester,stats,company,description
        var request = new RestRequest($"api/v2/tickets{filter?.ToQueryString()}", Method.GET);
        return await _client.ExecuteTaskAsync<List<Ticket>>(request, cancellationToken).ConfigureAwait(false);
    }

    public (Response, List<Ticket>) SearchTickets(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            throw new ArgumentException($"{nameof(query)} cannot be empty.");

        if (query.Length > 512)
            throw new ArgumentException($"{nameof(query)} cannot exceed 512 characters.");

        var request = new RestRequest($"api/v2/search/tickets?query=\"{Uri.EscapeDataString(query)}\"", Method.GET);
        return _client.ExecuteSearch<List<Ticket>>(request);
    }

    public async Task<(Response, List<Ticket>)> SearchTicketsAsync(string query, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(query))
            throw new ArgumentException($"{nameof(query)} cannot be empty.");

        if (query.Length > 512)
            throw new ArgumentException($"{nameof(query)} cannot exceed 512 characters.");

        var request = new RestRequest($"api/v2/search/tickets?query=\"{Uri.EscapeDataString(query)}\"", Method.GET);
        return await _client.ExecuteSearchTaskAsync<List<Ticket>>(request, cancellationToken).ConfigureAwait(false);
    }

    public (Response, Ticket) GetTicket(long ticketId)
        => GetTicket(ticketId, null);

    public (Response, Ticket) GetTicket(long ticketId, NameValueCollection filter)
    {
        if (ticketId <= 0)
            throw new ArgumentException($"{nameof(ticketId)} must be a positive {ticketId.GetType().Name}.");

        // include=conversations,requester,company,stats,sla_policy
        var request = new RestRequest($"api/v2/tickets/{ticketId}{filter?.ToQueryString()}", Method.GET);
        return _client.Execute<Ticket>(request);
    }

    public async Task<(Response, Ticket)> GetTicketAsync(long ticketId, CancellationToken cancellationToken = default)
        => await GetTicketAsync(ticketId, null, cancellationToken).ConfigureAwait(false);

    public async Task<(Response, Ticket)> GetTicketAsync(long ticketId, NameValueCollection filter, CancellationToken cancellationToken = default)
    {
        if (ticketId <= 0)
            throw new ArgumentException($"{nameof(ticketId)} must be a positive {ticketId.GetType().Name}.");

        // include=conversations,requester,company,stats,sla_policy
        var request = new RestRequest($"api/v2/tickets/{ticketId}{filter?.ToQueryString()}", Method.GET);
        return await _client.ExecuteTaskAsync<Ticket>(request, cancellationToken).ConfigureAwait(false);
    }

    public (Response, Ticket) CreateTicket(NewTicket ticket)
    {
        if (ticket == null)
            throw new ArgumentNullException($"{nameof(ticket)} cannot be null.");

        var request = new RestRequest("api/v2/tickets", Method.POST);
        request.AddJsonBody(ticket);
        return _client.Execute<Ticket>(request);
    }

    public async Task<(Response, Ticket)> CreateTicketAsync(NewTicket ticket, CancellationToken cancellationToken = default)
    {
        if (ticket == null)
            throw new ArgumentNullException($"{nameof(ticket)} cannot be null.");

        var request = new RestRequest("api/v2/tickets", Method.POST);
        request.AddJsonBody(ticket);
        return await _client.ExecuteTaskAsync<Ticket>(request, cancellationToken).ConfigureAwait(false);
    }

    public (Response, Ticket) UpdateTicket(Ticket ticket)
    {
        if (ticket == null)
            throw new ArgumentNullException($"{nameof(ticket)} cannot be null.");

        var request = new RestRequest($"api/v2/tickets/{ticket.Id}", Method.PUT);
        request.AddJsonBody(new TicketUpdate(ticket));
        return _client.Execute<Ticket>(request);
    }

    public async Task<(Response, Ticket)> UpdateTicketAsync(Ticket ticket, CancellationToken cancellationToken = default)
    {
        if (ticket == null)
            throw new ArgumentNullException($"{nameof(ticket)} cannot be null.");

        var request = new RestRequest($"api/v2/tickets/{ticket.Id}", Method.PUT);
        request.AddJsonBody(new TicketUpdate(ticket));
        return await _client.ExecuteTaskAsync<Ticket>(request, cancellationToken).ConfigureAwait(false);
    }

    public Response DeleteTicket(long ticketId)
    {
        if (ticketId <= 0)
            throw new ArgumentException($"{nameof(ticketId)} must be a positive {ticketId.GetType().Name}.");

        var request = new RestRequest($"api/v2/tickets/{ticketId}", Method.DELETE);
        return _client.Execute(request);
    }

    public async Task<Response> DeleteTicketAsync(long ticketId, CancellationToken cancellationToken = default)
    {
        if (ticketId <= 0)
            throw new ArgumentException($"{nameof(ticketId)} must be a positive {ticketId.GetType().Name}.");

        var request = new RestRequest($"api/v2/tickets/{ticketId}", Method.DELETE);
        return await _client.ExecuteTaskAsync(request, cancellationToken).ConfigureAwait(false);
    }

    public Response RestoreTicket(long ticketId)
    {
        if (ticketId <= 0)
            throw new ArgumentException($"{nameof(ticketId)} must be a positive {ticketId.GetType().Name}.");

        var request = new RestRequest($"api/v2/tickets/{ticketId}/restore", Method.PUT);
        return _client.Execute(request);
    }

    public async Task<Response> RestoreTicketAsync(long ticketId, CancellationToken cancellationToken = default)
    {
        if (ticketId <= 0)
            throw new ArgumentException($"{nameof(ticketId)} must be a positive {ticketId.GetType().Name}.");

        var request = new RestRequest($"api/v2/tickets/{ticketId}/restore", Method.PUT);
        return await _client.ExecuteTaskAsync(request, cancellationToken).ConfigureAwait(false);
    }
}