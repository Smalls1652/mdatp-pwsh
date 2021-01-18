using System;

using System.Text.Json.Serialization;

namespace MdatpPwsh.Models
{
    public class Software
    {
        [JsonPropertyName("id")]
        public string SoftwareId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("vendor")]
        public string Vendor { get; set; }

        [JsonPropertyName("weaknesses")]
        public long Weaknesses { get; set; }

        [JsonPropertyName("publicExploit")]
        public Boolean PublicExploit { get; set; }

        [JsonPropertyName("activeAlert")]
        public Boolean ActiveAlert { get; set; }

        [JsonPropertyName("exposedMachines")]
        public long ExposedMachines { get; set; }

        [JsonPropertyName("impactScore")]
        public double ImpactScore { get; set; }
    }
}