using System;

using System.Text.Json.Serialization;

namespace MdatpPwsh.Models
{
    public class DomainStats
    {
        [JsonPropertyName("host")]
        public string DomainHost { get; set; }

        [JsonPropertyName("orgPrevalence")]
        public string OrgPrevalence { get; set; }

        [JsonPropertyName("orgFirstSeen")]
        public Nullable<DateTime> OrgFirstSeen { get; set; }

        [JsonPropertyName("orgLastSeen")]
        public Nullable<DateTime> OrgLastSeen { get; set; }
    }
}