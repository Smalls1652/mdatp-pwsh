using System;
using System.Collections.Generic;

using System.Text.Json.Serialization;

namespace MdatpPwsh
{
    namespace Models
    {
        public class SecureScore
        {
            [JsonPropertyName("time")]
            public Nullable<DateTime> ApiTimeStamp { get; set; }

            [JsonPropertyName("rbacGroupName")]
            public string RbacGroupName { get; set; }

            [JsonPropertyName("score")]
            public double Score { get; set; }
        }
    }
}