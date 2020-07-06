using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace mdatp_pwsh
{
    namespace Classes
    {
        public class User
    {
        [JsonProperty("id")]
        public string UserId { get; set; }

        [JsonProperty("firstSeen")]
        public Nullable<DateTime> FirstSeen { get; set; }

        [JsonProperty("lastSeen")]
        public Nullable<DateTime> LastSeen { get; set; }

        [JsonProperty("mostPrevalentMachineId")]
        public string MostPrevalentMachineId { get; set; }

        [JsonProperty("leastPrevalentMachineId")]
        public string LeastPrevalentMachineId { get; set; }

        [JsonProperty("logonTypes")]
        public string LogonTypes { get; set; }

        [JsonProperty("logonMachinesCount")]
        public Int64 LogonMachinesCount { get; set; }

        [JsonProperty("isDomainAdmin")]
        public Boolean IsDomainAdmin { get; set; }

        [JsonProperty("isOnlyNetworkUser")]
        public Nullable<Boolean> IsOnlyNetworkUser { get; set; }
    }

    public class UserCollection
    {
        [JsonProperty("value")]
        public List<User> value { get; set; }
    }
    }
}