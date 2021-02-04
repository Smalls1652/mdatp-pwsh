using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Enums.Alerts;
    using MdatpPwsh.Helpers;

    [Cmdlet(VerbsData.Update, "DatpAlert")]
    public class UpdateDatpAlert : DatpCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true
        )]
        public string AlertId
        {
            get { return alertId; }
            set { alertId = value; }
        }
        private string alertId;

        [Parameter(
            Position = 1,
            Mandatory = true
        )]
        public AlertStatus Status
        {
            get { return alertStatus; }
            set { alertStatus = value; }
        }
        private AlertStatus alertStatus;

        [Parameter(
            Position = 2,
            Mandatory = true
        )]
        public string AssignedTo
        {
            get { return assignedTo; }
            set { assignedTo = value; }
        }
        private string assignedTo;

        [Parameter(
            Position = 3,
            Mandatory = true
        )]
        public AlertClassification Classification
        {
            get { return alertClassification; }
            set { alertClassification = value; }
        }
        private AlertClassification alertClassification;

        [Parameter(
            Position = 4,
            Mandatory = true
        )]
        public AlertDetermination Determination
        {
            get { return alertDetermination; }
            set { alertDetermination = value; }
        }
        private AlertDetermination alertDetermination;

        [Parameter(
            Position = 5,
            Mandatory = true
        )]
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        private string comment;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            string apiUri = $"alerts/{alertId}";

            UpdateAlert updateAlert = new UpdateAlert(
                Status = alertStatus,
                AssignedTo = assignedTo,
                Classification = alertClassification,
                Determination = alertDetermination,
                Comment = comment
            );
            string apiPatch = JsonSerializer.Serialize<UpdateAlert>(updateAlert);

            WriteVerbose($"Updating alert with AlertId of '{alertId}'.");
            string apiJson = SendApiCall(apiUri, apiPatch, HttpMethod.Patch);
        }
    }
}