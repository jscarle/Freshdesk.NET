using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Freshdesk.Companies;
using Freshdesk.Core;
using RestSharp;

namespace Freshdesk;

public partial class FreshdeskClient
{
    public (Response, List<Company>) GetCompanies()
    {
        var request = new RestRequest("api/v2/companies", Method.GET);
        return _client.Execute<List<Company>>(request);
    }

    public async Task<(Response, List<Company>)> GetCompaniesAsync(CancellationToken cancellationToken = default)
    {
        var request = new RestRequest("api/v2/companies", Method.GET);
        return await _client.ExecuteTaskAsync<List<Company>>(request, cancellationToken).ConfigureAwait(false);
    }

    public (Response, List<Company>) SearchCompanies(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            throw new ArgumentException($"{nameof(query)} cannot be empty.");

        if (query.Length > 512)
            throw new ArgumentException($"{nameof(query)} cannot exceed 512 characters.");

        var request = new RestRequest($"api/v2/search/companies?query=\"{Uri.EscapeDataString(query)}\"", Method.GET);
        return _client.ExecuteSearch<List<Company>>(request);
    }

    public async Task<(Response, List<Company>)> SearchCompaniesAsync(string query, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(query))
            throw new ArgumentException($"{nameof(query)} cannot be empty.");

        if (query.Length > 512)
            throw new ArgumentException($"{nameof(query)} cannot exceed 512 characters.");

        var request = new RestRequest($"api/v2/search/companies?query=\"{Uri.EscapeDataString(query)}\"", Method.GET);
        return await _client.ExecuteSearchTaskAsync<List<Company>>(request, cancellationToken).ConfigureAwait(false);
    }

    public (Response, Company) GetCompany(long companyId)
    {
        if (companyId <= 0)
            throw new ArgumentException($"{nameof(companyId)} must be a positive {companyId.GetType().Name}.");

        var request = new RestRequest($"api/v2/companies/{companyId}", Method.GET);
        return _client.Execute<Company>(request);
    }

    public async Task<(Response, Company)> GetCompanyAsync(long companyId, CancellationToken cancellationToken = default)
    {
        if (companyId <= 0)
            throw new ArgumentException($"{nameof(companyId)} must be a positive {companyId.GetType().Name}.");

        var request = new RestRequest($"api/v2/companies/{companyId}", Method.GET);
        return await _client.ExecuteTaskAsync<Company>(request, cancellationToken).ConfigureAwait(false);
    }

    public (Response, Company) CreateCompany(NewCompany company)
    {
        if (company is null)
            throw new ArgumentNullException($"{nameof(company)} cannot be null.");

        var request = new RestRequest("api/v2/companies", Method.POST);
        request.AddJsonBody(company);
        return _client.Execute<Company>(request);
    }

    public async Task<(Response, Company)> CreateCompanyAsync(NewCompany company, CancellationToken cancellationToken = default)
    {
        if (company is null)
            throw new ArgumentNullException($"{nameof(company)} cannot be null.");

        var request = new RestRequest("api/v2/companies", Method.POST);
        request.AddJsonBody(company);
        return await _client.ExecuteTaskAsync<Company>(request, cancellationToken).ConfigureAwait(false);
    }

    public (Response, Company) UpdateCompany(Company company)
    {
        if (company is null)
            throw new ArgumentNullException($"{nameof(company)} cannot be null.");

        var request = new RestRequest($"api/v2/companies/{company.Id}", Method.PUT);
        request.AddJsonBody(new CompanyUpdate(company));
        return _client.Execute<Company>(request);
    }

    public async Task<(Response, Company)> UpdateCompanyAsync(Company company, CancellationToken cancellationToken = default)
    {
        if (company is null)
            throw new ArgumentNullException($"{nameof(company)} cannot be null.");

        var request = new RestRequest($"api/v2/companies/{company.Id}", Method.PUT);
        request.AddJsonBody(new CompanyUpdate(company));
        return await _client.ExecuteTaskAsync<Company>(request, cancellationToken).ConfigureAwait(false);
    }

    public Response DeleteCompany(long companyId)
    {
        if (companyId <= 0)
            throw new ArgumentException($"{nameof(companyId)} must be a positive {companyId.GetType().Name}.");

        var request = new RestRequest($"api/v2/companies/{companyId}", Method.DELETE);
        return _client.Execute(request);
    }

    public async Task<Response> DeleteCompanyAsync(long companyId, CancellationToken cancellationToken = default)
    {
        if (companyId <= 0)
            throw new ArgumentException($"{nameof(companyId)} must be a positive {companyId.GetType().Name}.");

        var request = new RestRequest($"api/v2/companies/{companyId}", Method.DELETE);
        return await _client.ExecuteTaskAsync(request, cancellationToken).ConfigureAwait(false);
    }
}