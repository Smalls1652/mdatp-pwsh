using System;

using System.Text.Json.Serialization;

namespace MdatpPwsh.Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public string UserId { get; set; }

        [JsonPropertyName("firstSeen")]
        public Nullable<DateTime> FirstSeen { get; set; }

        [JsonPropertyName("lastSeen")]
        public Nullable<DateTime> LastSeen { get; set; }

        [JsonPropertyName("mostPrevalentMachineId")]
        public string MostPrevalentMachineId { get; set; }

        [JsonPropertyName("leastPrevalentMachineId")]
        public string LeastPrevalentMachineId { get; set; }

        [JsonPropertyName("logonTypes")]
        public string LogonTypes { get; set; }

        [JsonPropertyName("logonMachinesCount")]
        public Int64 LogonMachinesCount { get; set; }

        [JsonPropertyName("isDomainAdmin")]
        public Boolean IsDomainAdmin { get; set; }

        [JsonPropertyName("isOnlyNetworkUser")]
        public Nullable<Boolean> IsOnlyNetworkUser { get; set; }
    }
}