using System;
using Newtonsoft.Json;

namespace Freshdesk
{
    public class ErrorField
    {
        /// <summary>The request field that triggerred this error. Applicable to HTTP 400 errors only.</summary>
        [JsonProperty("field")]
        public string Field { get; set; }

        /// <summary>Detailed error message.</summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>Custom error code that is machine-parseable.</summary>
        [JsonConverter(typeof(ErrorFieldCodeConverter))]
        [JsonProperty("code")]
        public ErrorFieldCodes Code { get; set; }

        private class ErrorFieldCodeConverter : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                ErrorFieldCodes errorResponseFieldCode = (ErrorFieldCodes)value;

                switch (errorResponseFieldCode)
                {
                    case ErrorFieldCodes.MissingField:
                        writer.WriteValue("missing_field");
                        break;
                    case ErrorFieldCodes.InvalidValue:
                        writer.WriteValue("invalid_value");
                        break;
                    case ErrorFieldCodes.DuplicateValue:
                        writer.WriteValue("duplicate_value");
                        break;
                    case ErrorFieldCodes.DataTypeMismatch:
                        writer.WriteValue("datatype_mismatch");
                        break;
                    case ErrorFieldCodes.InvalidField:
                        writer.WriteValue("invalid_field");
                        break;
                    case ErrorFieldCodes.InvalidJson:
                        writer.WriteValue("invalid_json");
                        break;
                    case ErrorFieldCodes.InvalidCredentials:
                        writer.WriteValue("invalid_credentials");
                        break;
                    case ErrorFieldCodes.AccessDenied:
                        writer.WriteValue("access_denied");
                        break;
                    case ErrorFieldCodes.RequireFeature:
                        writer.WriteValue("require_feature");
                        break;
                    case ErrorFieldCodes.AccountSuspended:
                        writer.WriteValue("account_suspended");
                        break;
                    case ErrorFieldCodes.SslRequired:
                        writer.WriteValue("ssl_required");
                        break;
                    case ErrorFieldCodes.ReadOnlyField:
                        writer.WriteValue("readonly_field");
                        break;
                    case ErrorFieldCodes.InconsistentState:
                        writer.WriteValue("inconsistent_state");
                        break;
                    case ErrorFieldCodes.MaxAgentsReached:
                        writer.WriteValue("max_agents_reached");
                        break;
                    case ErrorFieldCodes.PasswordLockout:
                        writer.WriteValue("password_lockout");
                        break;
                    case ErrorFieldCodes.PasswordExpired:
                        writer.WriteValue("password_expired");
                        break;
                    case ErrorFieldCodes.NoContentRequired:
                        writer.WriteValue("no_content_required");
                        break;
                    case ErrorFieldCodes.InaccessibleField:
                        writer.WriteValue("inaccessible_field");
                        break;
                    case ErrorFieldCodes.IncompatibleField:
                        writer.WriteValue("incompatible_field");
                        break;
                }
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var enumString = (string)reader.Value;

                switch (enumString)
                {
                    case "missing_field":
                        return ErrorFieldCodes.MissingField;
                    case "invalid_value":
                        return ErrorFieldCodes.InvalidValue;
                    case "duplicate_value":
                        return ErrorFieldCodes.DuplicateValue;
                    case "datatype_mismatch":
                        return ErrorFieldCodes.DataTypeMismatch;
                    case "invalid_field":
                        return ErrorFieldCodes.InvalidField;
                    case "invalid_json":
                        return ErrorFieldCodes.InvalidJson;
                    case "invalid_credentials":
                        return ErrorFieldCodes.InvalidCredentials;
                    case "access_denied":
                        return ErrorFieldCodes.AccessDenied;
                    case "require_feature":
                        return ErrorFieldCodes.RequireFeature;
                    case "account_suspended":
                        return ErrorFieldCodes.AccountSuspended;
                    case "ssl_required":
                        return ErrorFieldCodes.SslRequired;
                    case "readonly_field":
                        return ErrorFieldCodes.ReadOnlyField;
                    case "inconsistent_state":
                        return ErrorFieldCodes.InconsistentState;
                    case "max_agents_reached":
                        return ErrorFieldCodes.MaxAgentsReached;
                    case "password_lockout":
                        return ErrorFieldCodes.PasswordLockout;
                    case "password_expired":
                        return ErrorFieldCodes.PasswordExpired;
                    case "no_content_required":
                        return ErrorFieldCodes.NoContentRequired;
                    case "inaccessible_field":
                        return ErrorFieldCodes.InaccessibleField;
                    case "incompatible_field":
                        return ErrorFieldCodes.IncompatibleField;
                }

                return Enum.Parse(typeof(ErrorFieldCodes), enumString, true);
            }

            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(string);
            }
        }

    }
}
