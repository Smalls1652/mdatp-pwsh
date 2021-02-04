using System;
using System.Collections.Generic;

using System.Text.Json.Serialization;

namespace MdatpPwsh
{
    namespace Models
    {
        public class ExposureScore
        {
            [JsonPropertyName("time")]
            public Nullable<DateTime> ApiTimeStamp { get; set; }

            [JsonPropertyName("score")]
            public double Score { get; set; }
        }
    }
}