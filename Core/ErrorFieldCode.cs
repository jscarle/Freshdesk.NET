using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Freshdesk
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ErrorFieldCode
    {
        /// <summary>A mandatory attribute is missing. For example, calling Create a Contact without the mandatory email field in the request will result in this error.</summary>
        [EnumMember(Value = "missing_field")]
        MissingField,

        /// <summary>This code indicates that a request contained an incorrect or blank value, or was in an invalid format.</summary>
        [EnumMember(Value = "invalid_value")]
        InvalidValue,

        /// <summary>Indicates that this value already exists. This error is applicable to fields that require unique values such as the email address in a contact or the name in a company.</summary>
        [EnumMember(Value = "duplicate_value")]
        DuplicateValue,

        /// <summary>Indicates that the field value doesn't match the expected data type. Entering text in a numerical field would trigger this error.</summary>
        [EnumMember(Value = "datatype_mismatch")]
        DataTypeMismatch,

        /// <summary>An unexpected field was part of the request. If any additional field is included in the request payload (other than what is specified in the API documentation), this error will occur.</summary>
        [EnumMember(Value = "invalid_field")]
        InvalidField,

        /// <summary>Request parameter is not a valid JSON. We recommend that you validate the JSON payload with a JSON validator before firing the API request.</summary>
        [EnumMember(Value = "invalid_json")]
        InvalidJson,

        /// <summary>Incorrect or missing API credentials. As the name suggests, it indicates that the API request was made with invalid credentials. Forgetting to apply Base64 encoding on the API key is a common cause of this error.</summary>
        [EnumMember(Value = "invalid_credentials")]
        InvalidCredentials,

        /// <summary>Insufficient privileges to perform this action. An agent attempting to access admin APIs will result in this error.</summary>
        [EnumMember(Value = "access_denied")]
        AccessDenied,

        /// <summary>Not allowed as a specific feature has to be enabled in your Freshdesk portal for you to perform this action.</summary>
        [EnumMember(Value = "require_feature")]
        RequireFeature,

        /// <summary>Account has been suspended.</summary>
        [EnumMember(Value = "account_suspended")]
        AccountSuspended,

        /// <summary>HTTPS is required in the API URL.</summary>
        [EnumMember(Value = "ssl_required")]
        SslRequired,

        /// <summary>Read only field cannot be altered.</summary>
        [EnumMember(Value = "readonly_field")]
        ReadOnlyField,

        /// <summary>An email should be associated with the contact before converting the contact to an agent.</summary>
        [EnumMember(Value = "inconsistent_state")]
        InconsistentState,

        /// <summary>The account has reached the maximum number of agents.</summary>
        [EnumMember(Value = "max_agents_reached")]
        MaxAgentsReached,

        /// <summary>The agent has reached the maximum number of failed login attempts.</summary>
        [EnumMember(Value = "password_lockout")]
        PasswordLockout,

        /// <summary>The agent's password has expired.</summary>
        [EnumMember(Value = "password_expired")]
        PasswordExpired,

        /// <summary>No JSON data required.</summary>
        [EnumMember(Value = "no_content_required")]
        NoContentRequired,

        /// <summary>The agent is not authorized to update this field.</summary>
        [EnumMember(Value = "inaccessible_field")]
        InaccessibleField,

        /// <summary>The field cannot be updated due to the current state of the record.</summary>
        [EnumMember(Value = "incompatible_field")]
        IncompatibleField
    }
}
