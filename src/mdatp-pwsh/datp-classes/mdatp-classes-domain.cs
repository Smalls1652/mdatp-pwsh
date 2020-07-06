using System;
using Newtonsoft.Json;

namespace mdatp_pwsh
{
    namespace Classes
    {
        public class DomainStats
        {
            [JsonProperty("host")]
            public string DomainHost { get; set; }

            [JsonProperty("orgPrevalence")]
            public Nullable<Int64> OrgPrevalence { get; set; }

            [JsonProperty("orgFirstSeen")]
            public Nullable<DateTime> OrgFirstSeen { get; set; }

            [JsonProperty("orgLastSeen")]
            public Nullable<DateTime> OrgLastSeen { get; set; }
        }
    }
}