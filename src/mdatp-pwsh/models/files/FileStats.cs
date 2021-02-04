using System;
using System.Collections.Generic;

using System.Text.Json.Serialization;

namespace MdatpPwsh.Models
{
    public class FileStats
    {
        [JsonPropertyName("sha1")]
        public string SHA1 { get; set; }

        [JsonPropertyName("orgPrevalence")]
        public int OrgPrevalence { get; set; }

        [JsonPropertyName("orgFirstSeen")]
        public Nullable<DateTime> OrgFirstSeen { get; set; }

        [JsonPropertyName("orgLastSeen")]
        public Nullable<DateTime> OrgLastSeen { get; set; }

        [JsonPropertyName("globalPrevalence")]
        public string GlobalPrevalence { get; set; }

        [JsonPropertyName("globalFirstObserved")]
        public Nullable<DateTime> GlobalFirstObserved { get; set; }

        [JsonPropertyName("globalLastObserved")]
        public Nullable<DateTime> GlobalLastObserved { get; set; }

        [JsonPropertyName("topFileNames")]
        public List<string> TopFileNames { get; set; }
    }
}