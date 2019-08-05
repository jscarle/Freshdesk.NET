using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace Freshdesk
{
    public partial class FreshdeskClient
    {
        public (Response, List<Company>) GetCompanies()
            => GetCompaniesAsync().WaitAndUnwrapException<(Response, List<Company>)>();

        public async Task<(Response, List<Company>)> GetCompaniesAsync(CancellationToken cancellationToken = default)
        {
            RestRequest request = new RestRequest("api/v2/companies", Method.GET);
            return await client.ExecuteTaskAsync<List<Company>>(request, cancellationToken).ConfigureAwait(false);
        }

        public (Response, List<Company>) SearchCompanies(string query)
            => SearchCompaniesAsync(query).WaitAndUnwrapException<(Response, List<Company>)>();

        public async Task<(Response, List<Company>)> SearchCompaniesAsync(string query, CancellationToken cancellationToken = default)
        {
            if (String.IsNullOrWhiteSpace(query))
                throw new ArgumentException($"{nameof(query)} cannot be empty.");

            if (query.Length > 512)
                throw new ArgumentException($"{nameof(query)} cannot exceed 512 characters.");

            RestRequest request = new RestRequest($"api/v2/search/companies?query=\"{Uri.EscapeDataString(query)}\"", Method.GET);
            return await client.ExecuteSearchTaskAsync<List<Company>>(request, cancellationToken).ConfigureAwait(false);
        }

        public (Response, Company) GetCompany(long companyID)
            => GetCompanyAsync(companyID).WaitAndUnwrapException<(Response, Company)>();

        public async Task<(Response, Company)> GetCompanyAsync(long companyID, CancellationToken cancellationToken = default)
        {
            if (companyID <= 0)
                throw new ArgumentException($"{nameof(companyID)} must be a positive {companyID.GetType().Name}.");

            RestRequest request = new RestRequest($"api/v2/companies/{companyID}", Method.GET);
            return await client.ExecuteTaskAsync<Company>(request, cancellationToken).ConfigureAwait(false);
        }

        public (Response, Company) CreateCompany(NewCompany company)
            => CreateCompanyAsync(company).WaitAndUnwrapException<(Response, Company)>();

        public async Task<(Response, Company)> CreateCompanyAsync(NewCompany company, CancellationToken cancellationToken = default)
        {
            if (company == null)
                throw new ArgumentNullException($"{nameof(company)} cannot be null.");

            RestRequest request = new RestRequest("api/v2/companies", Method.POST);
            request.AddJsonBody(company);
            return await client.ExecuteTaskAsync<Company>(request, cancellationToken).ConfigureAwait(false);
        }

        public (Response, Company) UpdateCompany(Company company)
            => UpdateCompanyAsync(company).WaitAndUnwrapException<(Response, Company)>();

        public async Task<(Response, Company)> UpdateCompanyAsync(Company company, CancellationToken cancellationToken = default)
        {
            if (company == null)
                throw new ArgumentNullException($"{nameof(company)} cannot be null.");

            RestRequest request = new RestRequest($"api/v2/companies/{company.ID}", Method.PUT);
            request.AddJsonBody(new CompanyUpdate(company));
            return await client.ExecuteTaskAsync<Company>(request, cancellationToken).ConfigureAwait(false);
        }

        public Response DeleteCompany(long companyID)
            => DeleteCompanyAsync(companyID).WaitAndUnwrapException<Response>();

        public async Task<Response> DeleteCompanyAsync(long companyID, CancellationToken cancellationToken = default)
        {
            if (companyID <= 0)
                throw new ArgumentException($"{nameof(companyID)} must be a positive {companyID.GetType().Name}.");

            RestRequest request = new RestRequest($"api/v2/companies/{companyID}", Method.DELETE);
            return await client.ExecuteTaskAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}