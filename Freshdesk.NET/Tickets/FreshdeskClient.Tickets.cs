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
        public (Response, List<Ticket>) GetTickets()
            => GetTickets(null);

        public (Response, List<Ticket>) GetTickets(NameValueCollection filter)
        {
            // include=requester,stats,company,description
            RestRequest request = new RestRequest($"api/v2/tickets{filter?.ToQueryString()}", Method.GET);
            return client.Execute<List<Ticket>>(request);
        }

        public async Task<(Response, List<Ticket>)> GetTicketsAsync(CancellationToken cancellationToken = default)
            => await GetTicketsAsync(null, cancellationToken).ConfigureAwait(false);

        public async Task<(Response, List<Ticket>)> GetTicketsAsync(NameValueCollection filter, CancellationToken cancellationToken = default)
        {
            // include=requester,stats,company,description
            RestRequest request = new RestRequest($"api/v2/tickets{filter?.ToQueryString()}", Method.GET);
            return await client.ExecuteTaskAsync<List<Ticket>>(request, cancellationToken).ConfigureAwait(false);
        }

        public (Response, List<Ticket>) SearchTickets(string query)
        {
            if (String.IsNullOrWhiteSpace(query))
                throw new ArgumentException($"{nameof(query)} cannot be empty.");

            if (query.Length > 512)
                throw new ArgumentException($"{nameof(query)} cannot exceed 512 characters.");

            RestRequest request = new RestRequest($"api/v2/search/tickets?query=\"{Uri.EscapeDataString(query)}\"", Method.GET);
            return client.ExecuteSearch<List<Ticket>>(request);
        }

        public async Task<(Response, List<Ticket>)> SearchTicketsAsync(string query, CancellationToken cancellationToken = default)
        {
            if (String.IsNullOrWhiteSpace(query))
                throw new ArgumentException($"{nameof(query)} cannot be empty.");

            if (query.Length > 512)
                throw new ArgumentException($"{nameof(query)} cannot exceed 512 characters.");

            RestRequest request = new RestRequest($"api/v2/search/tickets?query=\"{Uri.EscapeDataString(query)}\"", Method.GET);
            return await client.ExecuteSearchTaskAsync<List<Ticket>>(request, cancellationToken).ConfigureAwait(false);
        }

        public (Response, Ticket) GetTicket(long ticketID)
            => GetTicket(ticketID, null);

        public (Response, Ticket) GetTicket(long ticketID, NameValueCollection filter)
        {
            if (ticketID <= 0)
                throw new ArgumentException($"{nameof(ticketID)} must be a positive {ticketID.GetType().Name}.");

            // include=conversations,requester,company,stats,sla_policy
            RestRequest request = new RestRequest($"api/v2/tickets/{ticketID}{filter?.ToQueryString()}", Method.GET);
            return client.Execute<Ticket>(request);
        }

        public async Task<(Response, Ticket)> GetTicketAsync(long ticketID, CancellationToken cancellationToken = default)
            => await GetTicketAsync(ticketID, null, cancellationToken).ConfigureAwait(false);

        public async Task<(Response, Ticket)> GetTicketAsync(long ticketID, NameValueCollection filter, CancellationToken cancellationToken = default)
        {
            if (ticketID <= 0)
                throw new ArgumentException($"{nameof(ticketID)} must be a positive {ticketID.GetType().Name}.");

            // include=conversations,requester,company,stats,sla_policy
            RestRequest request = new RestRequest($"api/v2/tickets/{ticketID}{filter?.ToQueryString()}", Method.GET);
            return await client.ExecuteTaskAsync<Ticket>(request, cancellationToken).ConfigureAwait(false);
        }

        public (Response, Ticket) CreateTicket(NewTicket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException($"{nameof(ticket)} cannot be null.");

            RestRequest request = new RestRequest("api/v2/tickets", Method.POST);
            request.AddJsonBody(ticket);
            return client.Execute<Ticket>(request);
        }

        public async Task<(Response, Ticket)> CreateTicketAsync(NewTicket ticket, CancellationToken cancellationToken = default)
        {
            if (ticket == null)
                throw new ArgumentNullException($"{nameof(ticket)} cannot be null.");

            RestRequest request = new RestRequest("api/v2/tickets", Method.POST);
            request.AddJsonBody(ticket);
            return await client.ExecuteTaskAsync<Ticket>(request, cancellationToken).ConfigureAwait(false);
        }

        public (Response, Ticket) UpdateTicket(Ticket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException($"{nameof(ticket)} cannot be null.");

            RestRequest request = new RestRequest($"api/v2/tickets/{ticket.ID}", Method.PUT);
            request.AddJsonBody(new TicketUpdate(ticket));
            return client.Execute<Ticket>(request);
        }

        public async Task<(Response, Ticket)> UpdateTicketAsync(Ticket ticket, CancellationToken cancellationToken = default)
        {
            if (ticket == null)
                throw new ArgumentNullException($"{nameof(ticket)} cannot be null.");

            RestRequest request = new RestRequest($"api/v2/tickets/{ticket.ID}", Method.PUT);
            request.AddJsonBody(new TicketUpdate(ticket));
            return await client.ExecuteTaskAsync<Ticket>(request, cancellationToken).ConfigureAwait(false);
        }

        public Response DeleteTicket(long ticketID)
        {
            if (ticketID <= 0)
                throw new ArgumentException($"{nameof(ticketID)} must be a positive {ticketID.GetType().Name}.");

            RestRequest request = new RestRequest($"api/v2/tickets/{ticketID}", Method.DELETE);
            return client.Execute(request);
        }

        public async Task<Response> DeleteTicketAsync(long ticketID, CancellationToken cancellationToken = default)
        {
            if (ticketID <= 0)
                throw new ArgumentException($"{nameof(ticketID)} must be a positive {ticketID.GetType().Name}.");

            RestRequest request = new RestRequest($"api/v2/tickets/{ticketID}", Method.DELETE);
            return await client.ExecuteTaskAsync(request, cancellationToken).ConfigureAwait(false);
        }

        public Response RestoreTicket(long ticketID)
        {
            if (ticketID <= 0)
                throw new ArgumentException($"{nameof(ticketID)} must be a positive {ticketID.GetType().Name}.");

            RestRequest request = new RestRequest($"api/v2/tickets/{ticketID}/restore", Method.PUT);
            return client.Execute(request);
        }

        public async Task<Response> RestoreTicketAsync(long ticketID, CancellationToken cancellationToken = default)
        {
            if (ticketID <= 0)
                throw new ArgumentException($"{nameof(ticketID)} must be a positive {ticketID.GetType().Name}.");

            RestRequest request = new RestRequest($"api/v2/tickets/{ticketID}/restore", Method.PUT);
            return await client.ExecuteTaskAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}