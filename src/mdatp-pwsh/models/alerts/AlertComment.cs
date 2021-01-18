using System;

using System.Text.Json.Serialization;

namespace MdatpPwsh.Models
{
    public class AlertComment
    {
        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; }

        [JsonPropertyName("createdTime")]
        public DateTime CreatedTime { get; set; }
    }
}