using System;

using System.Text.Json.Serialization;

namespace MdatpPwsh.Models.Errors
{
    public class ErrorMessage
    {
        [JsonPropertyName("error")]
        public ErrorDetails ErrorDetails { get; set; }
    }
}