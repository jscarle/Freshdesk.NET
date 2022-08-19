using System.Reflection;
using Freshdesk.Companies;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Freshdesk;

public partial class FreshdeskClient
{
    private class CustomContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            switch (property.DeclaringType)
            {
                case { } type when type == typeof(Company) || type == typeof(NewCompany) || type == typeof(CompanyUpdate):
                    property.Converter = property.PropertyName switch
                    {
                        "renewal_date" => new DateOnlyConverter(),
                        _ => property.Converter
                    };
                    break;

                case { } type when type == typeof(ContactUpdate):
                    property.NullValueHandling = property.PropertyName switch
                    {
                        "company_id" => NullValueHandling.Include,
                        _ => property.NullValueHandling
                    };
                    break;

                case { } type when type == typeof(TicketUpdate):
                    property.NullValueHandling = property.PropertyName switch
                    {
                        "company_id" => NullValueHandling.Include,
                        "email_config_id" => NullValueHandling.Include,
                        "group_id" => NullValueHandling.Include,
                        "product_id" => NullValueHandling.Include,
                        "requester_id" => NullValueHandling.Include,
                        "responder_id" => NullValueHandling.Include,
                        _ => property.NullValueHandling
                    };
                    break;
            }

            return property;
        }
    }
}