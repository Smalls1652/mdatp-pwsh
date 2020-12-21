using System;

using System.Text.Json.Serialization;

namespace MdatpPwsh.Models
{
    public class ActivityResponse
    {
        [JsonPropertyName("id")]
        public string ActivityId { get; set; }

        [JsonPropertyName("type")]
        public string ActivityType { get; set; }

        [JsonPropertyName("requestor")]
        public string Requestor { get; set; }

        [JsonPropertyName("requestorcomment")]
        public string RequestorComment { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("machineId")]
        public string MachineId { get; set; }

        [JsonPropertyName("creationDateTimeUtc")]
        public Nullable<DateTime> CreationDateTimeUtc { get; set; }

        [JsonPropertyName("lastUpdateTimeUtc")]
        public Nullable<DateTime> LastUpdateTimeUtc { get; set; }

        [JsonPropertyName("relatedFileInfo")]
        public FileIdentifierData RelatedFileInfo { get; set; }

    }
}