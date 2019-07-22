namespace Freshdesk
{
    public enum ErrorFieldCodes
    {
        /// <summary>A mandatory attribute is missing. For example, calling Create a Contact without the mandatory email field in the request will result in this error.</summary>
        MissingField,

        /// <summary>This code indicates that a request contained an incorrect or blank value, or was in an invalid format.</summary>
        InvalidValue,

        /// <summary>Indicates that this value already exists. This error is applicable to fields that require unique values such as the email address in a contact or the name in a company.</summary>
        DuplicateValue,

        /// <summary>Indicates that the field value doesn't match the expected data type. Entering text in a numerical field would trigger this error.</summary>
        DataTypeMismatch,

        /// <summary>An unexpected field was part of the request. If any additional field is included in the request payload (other than what is specified in the API documentation), this error will occur.</summary>
        InvalidField,

        /// <summary>Request parameter is not a valid JSON. We recommend that you validate the JSON payload with a JSON validator before firing the API request.</summary>
        InvalidJson,

        /// <summary>Incorrect or missing API credentials. As the name suggests, it indicates that the API request was made with invalid credentials. Forgetting to apply Base64 encoding on the API key is a common cause of this error.</summary>
        InvalidCredentials,

        /// <summary>Insufficient privileges to perform this action. An agent attempting to access admin APIs will result in this error.</summary>
        AccessDenied,

        /// <summary>Not allowed as a specific feature has to be enabled in your Freshdesk portal for you to perform this action.</summary>
        RequireFeature,

        /// <summary>Account has been suspended.</summary>
        AccountSuspended,

        /// <summary>HTTPS is required in the API URL.</summary>
        SslRequired,

        /// <summary>Read only field cannot be altered.</summary>
        ReadOnlyField,

        /// <summary>An email should be associated with the contact before converting the contact to an agent.</summary>
        InconsistentState,

        /// <summary>The account has reached the maximum number of agents.</summary>
        MaxAgentsReached,

        /// <summary>The agent has reached the maximum number of failed login attempts.</summary>
        PasswordLockout,

        /// <summary>The agent's password has expired.</summary>
        PasswordExpired,

        /// <summary>No JSON data required.</summary>
        NoContentRequired,

        /// <summary>The agent is not authorized to update this field.</summary>
        InaccessibleField,

        /// <summary>The field cannot be updated due to the current state of the record.</summary>
        IncompatibleField
    }
}
