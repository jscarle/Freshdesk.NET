﻿using System;
using Newtonsoft.Json;

namespace Freshdesk
{
    public class ErrorField
    {
        /// <summary>The request field that triggerred this error. Applicable to HTTP 400 errors only.</summary>
        [JsonProperty("field")]
        public string Field { get; set; } = "";

        /// <summary>Detailed error message.</summary>
        [JsonProperty("message")]
        public string Message { get; set; } = "";

        /// <summary>Custom error code that is machine-parseable.</summary>
        [JsonProperty("code")]
        public ErrorFieldCode Code { get; set; } = ErrorFieldCode.Unknown;
    }
}