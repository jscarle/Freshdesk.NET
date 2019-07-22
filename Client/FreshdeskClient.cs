using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization;

namespace Freshdesk
{
    public partial class FreshdeskClient
    {
        #region Main Class
        private readonly PagingRestClient client;

        public FreshdeskClient(string domainName, string username, string password)
        {
            client = (PagingRestClient)new PagingRestClient().UseSerializer(() => new JsonSerializer());
            client.BaseUrl = new Uri("https://" + domainName);
            client.Authenticator = new HttpBasicAuthenticator(username, password);
       }

        private class JsonSerializer : IRestSerializer
        {
            public string Serialize(object obj) =>
                JsonConvert.SerializeObject(obj, new JsonSerializerSettings {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new FreshdeskContractResolver()
                });

            public string Serialize(Parameter parameter) =>
                JsonConvert.SerializeObject(parameter.Value, new JsonSerializerSettings {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new FreshdeskContractResolver()
                });

            public T Deserialize<T>(IRestResponse response) =>
                JsonConvert.DeserializeObject<T>(response.Content, new JsonSerializerSettings {
                    NullValueHandling = NullValueHandling.Ignore
                });

            public string[] SupportedContentTypes { get; } =
                { "application/json", "text/json", "text/x-json", "text/javascript", "*+json" };

            public string ContentType { get; set; } =
                "application/json";

            public DataFormat DataFormat { get; } =
                DataFormat.Json;
        }

        private class FreshdeskContractResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                JsonProperty property = base.CreateProperty(member, memberSerialization);

                switch (property.DeclaringType)
                {
                    case Type type when type == typeof(Company) || type == typeof(NewCompany) || type == typeof(UpdateCompany):
                        switch (property.PropertyName)
                        {
                            case "renewal_date":
                                property.Converter = new DateOnlyConverter();
                                break;
                        }
                        break;
                    case Type type when type == typeof(UpdateContact):
                        switch (property.PropertyName)
                        {
                            case "company_id":
                                property.NullValueHandling = NullValueHandling.Include;
                                break;
                        }
                        break;
                    case Type type when type == typeof(UpdateTicket):
                        switch (property.PropertyName)
                        {
                            case "company_id":
                            case "email_config_id":
                            case "group_id":
                            case "product_id":
                            case "requester_id":
                            case "responder_id":
                                property.NullValueHandling = NullValueHandling.Include;
                                break;
                        }
                        break;
                }

                return property;
            }
        }

        private class DateOnlyConverter : IsoDateTimeConverter
        {
            public DateOnlyConverter()
            {
                DateTimeFormat = "yyyy-MM-dd";
            }
        }
        #endregion

        #region Agents
        public (Response, List<Agent>) GetAgents() => GetAgents(null);

        public (Response, List<Agent>) GetAgents(NameValueCollection filter)
        {
            RestRequest request = new RestRequest($"api/v2/agents{filter?.ToQueryString()}", Method.GET);
            return client.Execute<List<Agent>>(request);
        }

        public (Response, Agent) GetAgent(long agentID)
        {
            if (agentID <= 0)
                throw new ArgumentException($"{nameof(agentID)} must be a positive {agentID.GetType().Name}.");

            RestRequest request = new RestRequest($"api/v2/agents/{agentID}", Method.GET);
            return client.Execute<Agent>(request);
        }

        public (Response, Agent) UpdateAgent(Agent agent)
        {
            if (agent == null)
                throw new ArgumentNullException($"{nameof(agent)} cannot be null.");

            RestRequest request = new RestRequest($"api/v2/agents/{agent.ID}", Method.PUT);
            request.AddJsonBody(new UpdateAgent(agent));
            return client.Execute<Agent>(request);
        }

        public Response DeleteAgent(long agentID)
        {
            if (agentID <= 0)
                throw new ArgumentException($"{nameof(agentID)} must be a positive {agentID.GetType().Name}.");

            RestRequest request = new RestRequest($"api/v2/agents/{agentID}", Method.DELETE);
            return client.Execute(request);
        }
        #endregion

        #region Companies
        public (Response, List<Company>) GetCompanies()
        {
            RestRequest request = new RestRequest("api/v2/companies", Method.GET);
            return client.Execute<List<Company>>(request);
        }

        public (Response, List<Company>) SearchCompanies(string query)
        {
            if (String.IsNullOrWhiteSpace(query))
                throw new ArgumentException($"{nameof(query)} cannot be empty.");

            if (query.Length > 512)
                throw new ArgumentException($"{nameof(query)} cannot exceed 512 characters.");

            RestRequest request = new RestRequest($"api/v2/search/companies?query=\"{Uri.EscapeDataString(query)}\"", Method.GET);
            return client.ExecuteFiltered<List<Company>>(request);
        }

        public (Response, Company) GetCompany(long companyID)
        {
            if (companyID <= 0)
                throw new ArgumentException($"{nameof(companyID)} must be a positive {companyID.GetType().Name}.");

            RestRequest request = new RestRequest($"api/v2/companies/{companyID}", Method.GET);
            return client.Execute<Company>(request);
        }

        public (Response, Company) CreateCompany(NewCompany company)
        {
            if (company == null)
                throw new ArgumentNullException($"{nameof(company)} cannot be null.");

            RestRequest request = new RestRequest("api/v2/companies", Method.POST);
            request.AddJsonBody(company);
            return client.Execute<Company>(request);
        }

        public (Response, Company) UpdateCompany(Company company)
        {
            if (company == null)
                throw new ArgumentNullException($"{nameof(company)} cannot be null.");

            RestRequest request = new RestRequest($"api/v2/companies/{company.ID}", Method.PUT);
            request.AddJsonBody(new UpdateCompany(company));
            return client.Execute<Company>(request);
        }

        public Response DeleteCompany(long companyID)
        {
            if (companyID <= 0)
                throw new ArgumentException($"{nameof(companyID)} must be a positive {companyID.GetType().Name}.");

            RestRequest request = new RestRequest($"api/v2/companies/{companyID}", Method.DELETE);
            return client.Execute(request);
        }
        #endregion

        #region Contacts
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
            return client.ExecuteFiltered<List<Contact>>(request);
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
            request.AddJsonBody(new UpdateContact(contact));
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
        #endregion

        #region Tickets
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
            return client.ExecuteFiltered<List<Ticket>>(request);
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
            request.AddJsonBody(new UpdateTicket(ticket));
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
        #endregion
    }
}