using System;
using System.Collections.Generic;

using System.Text.Json.Serialization;

namespace MdatpPwsh.Models
{
    public class Indicator
        {
            [JsonPropertyName("title")]
            public string IndicatorTitle { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("indicatorValue")]
            public string IndicatorValue { get; set; }

            [JsonPropertyName("indicatorType")]
            public Enum IndicatorType { get; set; }

            [JsonPropertyName("action")]
            public string Action { get; set; }

            [JsonPropertyName("severity")]
            public string Severity { get; set; }

            [JsonPropertyName("recommendedActions")]
            public string RecommendedActions { get; set; }

            [JsonPropertyName("creationTimeDateTimeUtc")]
            public DateTime DateCreated { get; set; }

            [JsonPropertyName("createdBy")]
            public string CreatedBy { get; set; }

            [JsonPropertyName("expirationTime")]
            public DateTime ExpirationTime { get; set; }

            [JsonPropertyName("rbacGroupNames")]
            public List<string> RbacGroupNames { get; set; }
        }
}