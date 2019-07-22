using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using RestSharp;

namespace Freshdesk
{
    public partial class FreshdeskClient
    {
        public (Response, List<Ticket>) GetTickets() => GetTickets(null);

        public (Response, List<Ticket>) GetTickets(NameValueCollection filter)
        {
            // include=requester,stats,company,description
            RestRequest request = new RestRequest($"api/v2/tickets{filter?.ToQueryString()}", Method.GET);
            return client.Execute<List<Ticket>>(request);
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

        public (Response, Ticket) GetTicket(long ticketID) => GetTicket(ticketID, null);

        public (Response, Ticket) GetTicket(long ticketID, NameValueCollection filter)
        {
            if (ticketID <= 0)
                throw new ArgumentException($"{nameof(ticketID)} must be a positive {ticketID.GetType().Name}.");

            // include=conversations,requester,company,stats,sla_policy
            RestRequest request = new RestRequest($"api/v2/tickets/{ticketID}{filter?.ToQueryString()}", Method.GET);
            return client.Execute<Ticket>(request);
        }

        public (Response, Ticket) CreateTicket(NewTicket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException($"{nameof(ticket)} cannot be null.");

            RestRequest request = new RestRequest("api/v2/tickets", Method.POST);
            request.AddJsonBody(ticket);
            return client.Execute<Ticket>(request);
        }

        public (Response, Ticket) UpdateTicket(Ticket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException($"{nameof(ticket)} cannot be null.");

            RestRequest request = new RestRequest($"api/v2/tickets/{ticket.ID}", Method.PUT);
            request.AddJsonBody(new TicketUpdate(ticket));
            return client.Execute<Ticket>(request);
        }

        public Response DeleteTicket(long ticketID)
        {
            if (ticketID <= 0)
                throw new ArgumentException($"{nameof(ticketID)} must be a positive {ticketID.GetType().Name}.");

            RestRequest request = new RestRequest($"api/v2/tickets/{ticketID}", Method.DELETE);
            return client.Execute(request);
        }

        public Response RestoreTicket(long ticketID)
        {
            if (ticketID <= 0)
                throw new ArgumentException($"{nameof(ticketID)} must be a positive {ticketID.GetType().Name}.");

            RestRequest request = new RestRequest($"api/v2/tickets/{ticketID}/restore", Method.DELETE);
            return client.Execute(request);
        }
    }
}