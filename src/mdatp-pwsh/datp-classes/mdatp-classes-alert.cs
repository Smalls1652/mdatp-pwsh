using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace mdatp_pwsh
{
    namespace Classes
    {
        public class Alert
        {
            [JsonProperty("id")]
            public string AlertId { get; set; }

            [JsonProperty("alertCreationTime")]
            public Nullable<DateTime> AlertCreationTime { get; set; }

            [JsonProperty("title")]
            public string AlertTitle { get; set; }

            [JsonProperty("description")]
            public string AlertDescription { get; set; }

            [JsonProperty("incidentId")]
            public Int64 IncidentId { get; set; }

            [JsonProperty("firstEventTime")]
            public Nullable<DateTime> FirstEventTime { get; set; }

            [JsonProperty("lastEventTime")]
            public Nullable<DateTime> LastEventTime { get; set; }

            [JsonProperty("resolvedTime")]
            public Nullable<DateTime> ResolvedTime { get; set; }

            [JsonProperty("machineId")]
            public string MachineId { get; set; }

            [JsonProperty("assignedTo")]
            public string AssignedTo { get; set; }

            [JsonProperty("severity")]
            public string Severity { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("classification")]
            public string Classification { get; set; }

            [JsonProperty("determination")]
            public string Determination { get; set; }

            [JsonProperty("investigationState")]
            public string InvestigationState { get; set; }

            [JsonProperty("category")]
            public string Category { get; set; }

            [JsonProperty("detectionSource")]
            public string DetectionSource { get; set; }

            [JsonProperty("threatFamilyName")]
            public string ThreatFamilyName { get; set; }

        }

        public class AlertCollection
        {
            public List<Alert> value { get; set; }
        }
    }
}