using System;
using System.Collections.Generic;

using System.Text.Json.Serialization;

namespace MdatpPwsh.Models
{
    public class IpAddress
    {
        [JsonPropertyName("ipAddress")]
        public string Ipv4Address { get; set; }

        [JsonPropertyName("orgPrevalence")]
        public Int64 Prevalence { get; set; }

        [JsonPropertyName("orgFirstSeen")]
        public DateTime FirstSeen { get; set; }

        [JsonPropertyName("orgLastSeen")]
        public DateTime LastSeen { get; set; }
    }
}