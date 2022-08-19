using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;
using Freshdesk.Agents;
using Freshdesk.Core;
using RestSharp;

namespace Freshdesk;

public partial class FreshdeskClient
{
    public (Response, List<Agent>) GetAgents()
        => GetAgents(null);

    public (Response, List<Agent>) GetAgents(NameValueCollection filter)
    {
        var request = new RestRequest($"api/v2/agents{filter?.ToQueryString()}", Method.GET);
        return _client.Execute<List<Agent>>(request);
    }

    public async Task<(Response, List<Agent>)> GetAgentsAsync(CancellationToken cancellationToken = default)
        => await GetAgentsAsync(null, cancellationToken).ConfigureAwait(false);

    public async Task<(Response, List<Agent>)> GetAgentsAsync(NameValueCollection filter, CancellationToken cancellationToken = default)
    {
        var request = new RestRequest($"api/v2/agents{filter?.ToQueryString()}", Method.GET);
        return await _client.ExecuteTaskAsync<List<Agent>>(request, cancellationToken).ConfigureAwait(false);
    }

    public (Response, Agent) GetAgent(long agentId)
    {
        if (agentId <= 0)
            throw new ArgumentException($"{nameof(agentId)} must be a positive {agentId.GetType().Name}.");

        var request = new RestRequest($"api/v2/agents/{agentId}", Method.GET);
        return _client.Execute<Agent>(request);
    }

    public async Task<(Response, Agent)> GetAgentAsync(long agentId, CancellationToken cancellationToken = default)
    {
        if (agentId <= 0)
            throw new ArgumentException($"{nameof(agentId)} must be a positive {agentId.GetType().Name}.");

        var request = new RestRequest($"api/v2/agents/{agentId}", Method.GET);
        return await _client.ExecuteTaskAsync<Agent>(request, cancellationToken).ConfigureAwait(false);
    }

    public (Response, Agent) UpdateAgent(Agent agent)
    {
        if (agent is null)
            throw new ArgumentNullException($"{nameof(agent)} cannot be null.");

        var request = new RestRequest($"api/v2/agents/{agent.Id}", Method.PUT);
        request.AddJsonBody(new AgentUpdate(agent));
        return _client.Execute<Agent>(request);
    }

    public async Task<(Response, Agent)> UpdateAgentAsync(Agent agent, CancellationToken cancellationToken = default)
    {
        if (agent is null)
            throw new ArgumentNullException($"{nameof(agent)} cannot be null.");

        var request = new RestRequest($"api/v2/agents/{agent.Id}", Method.PUT);
        request.AddJsonBody(new AgentUpdate(agent));
        return await _client.ExecuteTaskAsync<Agent>(request, cancellationToken).ConfigureAwait(false);
    }

    public Response DeleteAgent(long agentId)
    {
        if (agentId <= 0)
            throw new ArgumentException($"{nameof(agentId)} must be a positive {agentId.GetType().Name}.");

        var request = new RestRequest($"api/v2/agents/{agentId}", Method.DELETE);
        return _client.Execute(request);
    }

    public async Task<Response> DeleteAgentAsync(long agentId, CancellationToken cancellationToken = default)
    {
        if (agentId <= 0)
            throw new ArgumentException($"{nameof(agentId)} must be a positive {agentId.GetType().Name}.");

        var request = new RestRequest($"api/v2/agents/{agentId}", Method.DELETE);
        return await _client.ExecuteTaskAsync(request, cancellationToken).ConfigureAwait(false);
    }
}