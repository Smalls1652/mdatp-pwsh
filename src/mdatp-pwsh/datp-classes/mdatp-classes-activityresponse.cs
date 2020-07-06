using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MdatpPwsh
{
    namespace Classes
    {
        public class ActivityResponse
        {
            [JsonProperty("id")]
            public string ActivityId { get; set; }

            [JsonProperty("type")]
            public string ActivityType { get; set; }

            [JsonProperty("requestor")]
            public string Requestor { get; set; }

            [JsonProperty("requestorcomment")]
            public string RequestorComment { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("machineId")]
            public string MachineId { get; set; }

            [JsonProperty("creationDateTimeUtc")]
            public Nullable<DateTime> CreationDateTimeUtc { get; set; }

            [JsonProperty("lastUpdateTimeUtc")]
            public Nullable<DateTime> LastUpdateTimeUtc { get; set; }

            [JsonProperty("relatedFileInfo")]
            public FileIdentifierData RelatedFileInfo { get; set; }

        }

        public class ActivityResponseCollection
        {
            public List<ActivityResponse> value { get; set; }
        }
    }
}