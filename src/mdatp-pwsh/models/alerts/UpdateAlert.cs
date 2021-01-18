using System;
using System.Collections.Generic;

using System.Text.Json.Serialization;

namespace MdatpPwsh.Models
{
    using MdatpPwsh.Enums.Alerts;

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

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AlertStatus Status { get; set; }

        [JsonPropertyName("assignedTo")]
        public string AssignedTo { get; set; }

        [JsonPropertyName("classification")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AlertClassification Classification { get; set; }

        [JsonPropertyName("determination")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AlertDetermination Determination { get; set; }

        [JsonPropertyName("comment")]
        public string Comment { get; set; }
    }
}