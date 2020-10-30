using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace MdatpPwsh
{
    namespace Classes
    {
        public class Software
        {
            [JsonProperty("id")]
            public string SoftwareId { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("vendor")]
            public string Vendor { get; set; }

            [JsonProperty("weaknesses")]
            public long Weaknesses { get; set; }

            [JsonProperty("publicExploit")]
            public Boolean PublicExploit { get; set; }

            [JsonProperty("activeAlert")]
            public Boolean ActiveAlert { get; set; }

            [JsonProperty("exposedMachines")]
            public long ExposedMachines { get; set; }

            [JsonProperty("impactScore")]
            public double ImpactScore { get; set; }
        }

        public class SoftwareCollection
        {
            public List<Software> value { get; set; }
        }
    }
}