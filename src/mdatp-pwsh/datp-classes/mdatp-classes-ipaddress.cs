using System;
using Newtonsoft.Json;

namespace MdatpPwsh
{
    namespace Classes
    {
        public class IpAddress
        {
            [JsonProperty("ipAddress")]
            public string Ipv4Address { get; set; }

            [JsonProperty("orgPrevalence")]
            public Int64 Prevalence { get; set; }

            [JsonProperty("orgFirstSeen")]
            public DateTime FirstSeen { get; set; }

            [JsonProperty("orgLastSeen")]
            public DateTime LastSeen { get; set; }
        }
    }
}