using System;
using System.Management.Automation;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Identity.Client;

namespace MdatpPwsh
{
    using Classes;
    using Classes.Enums;

    [Cmdlet(VerbsData.Update, "DatpAlert")]
    public class UpdateDatpAlert : PSCmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public string AlertId
        {
            get { return alertId; }
            set { alertId = value; }
        }

        [Parameter(Position = 1, Mandatory = true)]
        public AlertStatus Status
        {
            get { return alertStatus; }
            set { alertStatus = value; }
        }

        [Parameter(Position = 2, Mandatory = true)]
        public string AssignedTo
        {
            get { return assignedTo; }
            set { assignedTo = value; }
        }

        [Parameter(Position = 3, Mandatory = true)]
        public AlertClassification Classification
        {
            get { return alertClassification; }
            set { alertClassification = value; }
        }

        [Parameter(Position = 4, Mandatory = true)]
        public AlertDetermination Determination
        {
            get { return alertDetermination; }
            set { alertDetermination = value; }
        }

        [Parameter(Position = 5, Mandatory = true)]
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        
        private string alertId;
        private AlertStatus alertStatus;
        private string assignedTo;
        private AlertClassification alertClassification;
        private AlertDetermination alertDetermination;
        private string comment;

        private string apiUri;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            apiUri = $"alerts/{alertId}";
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            UpdateAlert updateAlert = new UpdateAlert(
                Status = alertStatus,
                AssignedTo = assignedTo,
                Classification = alertClassification,
                Determination = alertDetermination,
                Comment = comment
            );
            string apiPatchBody = JsonConvert.SerializeObject(updateAlert);

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = null;

            InvokeDatpPatchApiCall invokeDatpPatchApiCall = new InvokeDatpPatchApiCall();
            invokeDatpPatchApiCall.Uri = apiUri;
            invokeDatpPatchApiCall.PostBody = apiPatchBody;
            invokeDatpPatchApiCall.Token = token;

            foreach (HttpResponseMessage r in invokeDatpPatchApiCall.Invoke<HttpResponseMessage>())
            {
                apiResponse = r;
            }
        }
    }
}