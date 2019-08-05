using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Freshdesk
{
    public partial class FreshdeskClient
    {
        private class CustomContractResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                JsonProperty property = base.CreateProperty(member, memberSerialization);

                switch (property.DeclaringType)
                {
                    case Type type when type == typeof(Company) || type == typeof(NewCompany) || type == typeof(CompanyUpdate):
                        switch (property.PropertyName)
                        {
                            case "renewal_date":
                                property.Converter = new DateOnlyConverter();
                                break;
                        }
                        break;

                    case Type type when type == typeof(ContactUpdate):
                        switch (property.PropertyName)
                        {
                            case "company_id":
                                property.NullValueHandling = NullValueHandling.Include;
                                break;
                        }
                        break;

                    case Type type when type == typeof(TicketUpdate):
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
    }
}