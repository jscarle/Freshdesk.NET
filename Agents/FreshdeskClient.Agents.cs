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
        public (Response, List<Agent>) GetAgents()
            => GetAgentsAsync().WaitAndUnwrapException<(Response, List<Agent>)>();

        public async Task<(Response, List<Agent>)> GetAgentsAsync(CancellationToken cancellationToken = default)
            => await GetAgentsAsync(null, cancellationToken).ConfigureAwait(false);

        public (Response, List<Agent>) GetAgents(NameValueCollection filter)
            => GetAgentsAsync(filter).WaitAndUnwrapException<(Response, List<Agent>)>();

        public async Task<(Response, List<Agent>)> GetAgentsAsync(NameValueCollection filter, CancellationToken cancellationToken = default)
        {
            RestRequest request = new RestRequest($"api/v2/agents{filter?.ToQueryString()}", Method.GET);
            return await client.ExecuteTaskAsync<List<Agent>>(request, cancellationToken).ConfigureAwait(false);
        }

        public (Response, Agent) GetAgent(long agentID)
            => GetAgentAsync(agentID).WaitAndUnwrapException<(Response, Agent)>();

        public async Task<(Response, Agent)> GetAgentAsync(long agentID, CancellationToken cancellationToken = default)
        {
            if (agentID <= 0)
                throw new ArgumentException($"{nameof(agentID)} must be a positive {agentID.GetType().Name}.");

            RestRequest request = new RestRequest($"api/v2/agents/{agentID}", Method.GET);
            return await client.ExecuteTaskAsync<Agent>(request, cancellationToken).ConfigureAwait(false);
        }

        public (Response, Agent) UpdateAgent(Agent agent)
            => UpdateAgentAsync(agent).WaitAndUnwrapException<(Response, Agent)>();

        public async Task<(Response, Agent)> UpdateAgentAsync(Agent agent, CancellationToken cancellationToken = default)
        {
            if (agent == null)
                throw new ArgumentNullException($"{nameof(agent)} cannot be null.");

            RestRequest request = new RestRequest($"api/v2/agents/{agent.ID}", Method.PUT);
            request.AddJsonBody(new AgentUpdate(agent));
            return await client.ExecuteTaskAsync<Agent>(request, cancellationToken).ConfigureAwait(false);
        }

        public Response DeleteAgent(long agentID)
            => DeleteAgentAsync(agentID).WaitAndUnwrapException<Response>();

        public async Task<Response> DeleteAgentAsync(long agentID, CancellationToken cancellationToken = default)
        {
            if (agentID <= 0)
                throw new ArgumentException($"{nameof(agentID)} must be a positive {agentID.GetType().Name}.");

            RestRequest request = new RestRequest($"api/v2/agents/{agentID}", Method.DELETE);
            return await client.ExecuteTaskAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}