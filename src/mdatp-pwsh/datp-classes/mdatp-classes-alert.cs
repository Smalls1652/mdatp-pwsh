using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MdatpPwsh
{
    namespace Classes
    {
        using Enums;

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
            public Nullable<Int64> IncidentId { get; set; }

            [JsonProperty("firstEventTime")]
            public Nullable<DateTime> FirstEventTime { get; set; }

            [JsonProperty("lastEventTime")]
            public Nullable<DateTime> LastEventTime { get; set; }

            [JsonProperty("resolvedTime")]
            public Nullable<DateTime> ResolvedTime { get; set; }

            [JsonProperty("machineId")]
            public string MachineId { get; set; }

            [JsonProperty("computerDnsName")]
            public string ComputerDnsName { get; set; }

            [JsonProperty("aadTenantId")]
            public string AadTenantId { get; set; }

            [JsonProperty("assignedTo")]
            public string AssignedTo { get; set; }

            [JsonProperty("severity")]
            public AlertSeverity Severity { get; set; }

            [JsonProperty("status")]
            public Nullable<AlertStatus> Status { get; set; }

            [JsonProperty("classification")]
            public Nullable<AlertClassification> Classification { get; set; }

            [JsonProperty("determination")]
            public Nullable<AlertDetermination> Determination { get; set; }

            [JsonProperty("investigationId")]
            public Nullable<Int64> InvestigationId { get; set; }

            [JsonProperty("investigationState")]
            public Nullable<InvestigationState> InvestigationState { get; set; }

            [JsonProperty("category")]
            public string Category { get; set; }

            [JsonProperty("detectionSource")]
            public string DetectionSource { get; set; }

            [JsonProperty("threatFamilyName")]
            public string ThreatFamilyName { get; set; }

            [JsonProperty("comments")]
            public List<AlertComment> Comments { get; set; }

        }

        public class AlertCollection
        {
            public List<Alert> value { get; set; }
        }

        public class AlertComment
        {
            [JsonProperty("comment")]
            public string Comment { get; set; }

            [JsonProperty("createdBy")]
            public string CreatedBy { get; set; }

            [JsonProperty("createdTime")]
            public DateTime CreatedTime { get; set; }
        }

        public class UpdateAlert
        {
            public UpdateAlert()
            {

            }

            public UpdateAlert(AlertStatus status, string assignedTo, AlertClassification classification, AlertDetermination determination, string comment)
            {
                Status = status;
                AssignedTo = assignedTo;
                Classification = classification;
                Determination = determination;
                Comment = comment;
            }

            [JsonProperty("status")]
            [JsonConverter(typeof(StringEnumConverter))]
            public AlertStatus Status { get; set; }

            [JsonProperty("assignedTo")]
            public string AssignedTo { get; set; }

            [JsonProperty("classification")]
            [JsonConverter(typeof(StringEnumConverter))]
            public AlertClassification Classification { get; set; }

            [JsonProperty("determination")]
            [JsonConverter(typeof(StringEnumConverter))]
            public AlertDetermination Determination { get; set; }

            [JsonProperty("comment")]
            public string Comment { get; set; }
        }
    }
}