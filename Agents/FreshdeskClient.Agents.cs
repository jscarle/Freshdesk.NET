using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using RestSharp;

namespace Freshdesk
{
    public partial class FreshdeskClient
    {
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
            request.AddJsonBody(new AgentUpdate(agent));
            return client.Execute<Agent>(request);
        }

        public Response DeleteAgent(long agentID)
        {
            if (agentID <= 0)
                throw new ArgumentException($"{nameof(agentID)} must be a positive {agentID.GetType().Name}.");

            RestRequest request = new RestRequest($"api/v2/agents/{agentID}", Method.DELETE);
            return client.Execute(request);
        }
    }
}