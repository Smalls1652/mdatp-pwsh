using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace MdatpPwsh
{
    namespace Classes
    {
        public class SecureScore
        {
            [JsonProperty("time")]
            public Nullable<DateTime> ApiTimeStamp { get; set; }

            [JsonProperty("rbacGroupName")]
            public string RbacGroupName { get; set; }

            [JsonProperty("score")]
            public double Score { get; set; }
        }

        public class ScoreCollection
        {
            public List<SecureScore> value { get; set; }
        }
    }
}