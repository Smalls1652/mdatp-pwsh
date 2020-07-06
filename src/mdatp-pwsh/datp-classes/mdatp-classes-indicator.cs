using System;
using Newtonsoft.Json;

namespace mdatp_pwsh
{
    namespace Classes
    {
        public class Indicator
        {
            [JsonProperty("title")]
            public string IndicatorTitle { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("indicatorValue")]
            public string IndicatorValue { get; set; }

            [JsonProperty("indicatorType")]
            public Enum IndicatorType { get; set; }

            [JsonProperty("action")]
            public string Action { get; set; }

            [JsonProperty("severity")]
            public string Severity { get; set; }

            [JsonProperty("recommendedActions")]
            public string RecommendedActions { get; set; }

            [JsonProperty("creationTimeDateTimeUtc")]
            public DateTime DateCreated { get; set; }

            [JsonProperty("createdBy")]
            public string CreatedBy { get; set; }

            [JsonProperty("expirationTime")]
            public DateTime ExpirationTime { get; set; }

            [JsonProperty("rbacGroupNames")]
            public string[] RbacGroupNames { get; set; }
        }
    }
}