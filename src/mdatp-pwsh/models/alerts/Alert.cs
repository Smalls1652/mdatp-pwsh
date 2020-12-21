using System;
using System.Collections.Generic;

using System.Text.Json.Serialization;

namespace MdatpPwsh.Models
{
    using MdatpPwsh.Enums.Alerts;
    using MdatpPwsh.Enums.Investigations;
    
    public class Alert
    {
        [JsonPropertyName("id")]
        public string AlertId { get; set; }

        [JsonPropertyName("alertCreationTime")]
        public Nullable<DateTime> AlertCreationTime { get; set; }

        [JsonPropertyName("title")]
        public string AlertTitle { get; set; }

        [JsonPropertyName("description")]
        public string AlertDescription { get; set; }

        [JsonPropertyName("incidentId")]
        public Nullable<Int64> IncidentId { get; set; }

        [JsonPropertyName("firstEventTime")]
        public Nullable<DateTime> FirstEventTime { get; set; }

        [JsonPropertyName("lastEventTime")]
        public Nullable<DateTime> LastEventTime { get; set; }

        [JsonPropertyName("resolvedTime")]
        public Nullable<DateTime> ResolvedTime { get; set; }

        [JsonPropertyName("machineId")]
        public string MachineId { get; set; }

        [JsonPropertyName("computerDnsName")]
        public string ComputerDnsName { get; set; }

        [JsonPropertyName("aadTenantId")]
        public string AadTenantId { get; set; }

        [JsonPropertyName("assignedTo")]
        public string AssignedTo { get; set; }

        [JsonPropertyName("severity")]
        public AlertSeverity Severity { get; set; }

        [JsonPropertyName("status")]
        public Nullable<AlertStatus> Status { get; set; }

        [JsonPropertyName("classification")]
        public Nullable<AlertClassification> Classification { get; set; }

        [JsonPropertyName("determination")]
        public Nullable<AlertDetermination> Determination { get; set; }

        [JsonPropertyName("investigationId")]
        public Nullable<Int64> InvestigationId { get; set; }

        [JsonPropertyName("investigationState")]
        public Nullable<InvestigationState> InvestigationState { get; set; }

        [JsonPropertyName("category")]
        public AlertCategory Category { get; set; }

        [JsonPropertyName("detectionSource")]
        public string DetectionSource { get; set; }

        [JsonPropertyName("threatFamilyName")]
        public string ThreatFamilyName { get; set; }

        [JsonPropertyName("comments")]
        public List<AlertComment> Comments { get; set; }

    }
}