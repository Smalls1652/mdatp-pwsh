using System;
using System.Collections.Generic;

using System.Text.Json.Serialization;

namespace MdatpPwsh.Models
{
    using MdatpPwsh.Enums.Alerts;
    
    public class NewAlert
    {
        public NewAlert() { }

        public NewAlert(DateTime eventTime, string reportId, string machineId, AlertSeverity severity, string title, string description, string recommendedAction, AlertCategory category)
        {
            EventTime = eventTime;
            ReportId = reportId;
            MachineId = machineId;
            Severity = severity;
            Title = title;
            Description = description;
            RecommendedAction = recommendedAction;
            Category = category;
        }

        [JsonPropertyName("eventTime")]
        public DateTime EventTime { get; set; }

        [JsonPropertyName("reportId")]
        public string ReportId { get; set; }

        [JsonPropertyName("machineId")]
        public string MachineId { get; set; }

        [JsonPropertyName("severity")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AlertSeverity Severity { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("recommendedAction")]
        public string RecommendedAction { get; set; }

        [JsonPropertyName("category")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AlertCategory Category { get; set; }
    }
}