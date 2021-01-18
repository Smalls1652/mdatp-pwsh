using System;

using System.Text.Json.Serialization;

namespace MdatpPwsh.Models.Errors
{
    public class ErrorDetails
    {
        [JsonPropertyName("code")]
        public string ErrorCode { get; set; }

        [JsonPropertyName("message")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("target")]
        public string ErrorTarget { get; set; }
    }
}