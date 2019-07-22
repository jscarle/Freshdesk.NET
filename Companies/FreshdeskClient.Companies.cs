using System;
using System.Collections.Generic;
using RestSharp;

namespace Freshdesk
{
    public partial class FreshdeskClient
    {
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
            return client.ExecuteSearch<List<Company>>(request);
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
            request.AddJsonBody(new CompanyUpdate(company));
            return client.Execute<Company>(request);
        }

        public Response DeleteCompany(long companyID)
        {
            if (companyID <= 0)
                throw new ArgumentException($"{nameof(companyID)} must be a positive {companyID.GetType().Name}.");

            RestRequest request = new RestRequest($"api/v2/companies/{companyID}", Method.DELETE);
            return client.Execute(request);
        }
    }
}