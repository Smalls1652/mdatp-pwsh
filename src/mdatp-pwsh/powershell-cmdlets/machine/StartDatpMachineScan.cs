using System;
using System.Management.Automation;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Identity.Client;

using MdatpPwsh.Classes;
using MdatpPwsh.Classes.Post;

namespace MdatpPwsh
{
    [Cmdlet(VerbsLifecycle.Start, "DatpMachineScan")]
    public class StartDatpMachineScan : DatpCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public string MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private static string machineId;

        [Parameter(Position = 1)]
        [ValidateSet("Quick", "Full")]
        public string ScanType
        {
            get { return scanType; }
            set { scanType = value; }
        }
        private static string scanType = "Quick";

        [Parameter(Mandatory = true, Position = 2)]
        [ValidateNotNullOrEmpty()]
        public string Comment
        {
            get { return cmnt; }
            set { cmnt = value; }
        }
        private static string cmnt;

        private static string apiUri;

        private static string apiPost;

        protected override void BeginProcessing()
        {
            MachineScan postObj = new MachineScan();
            postObj.Comment = cmnt;
            postObj.ScanType = scanType;

            apiPost = JsonConvert.SerializeObject(postObj);

            apiUri = $"machines/{machineId}/runAntiVirusScan";

            WriteVerbose($"Starting a '{scanType} Scan' on '{machineId}'.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Starting api call.");
            string apiJson = SendApiCall(apiUri, apiPost, HttpMethod.Post);

            ActivityResponse apiResult = JsonConvert.DeserializeObject<ActivityResponse>(apiJson);

            WriteObject(apiResult);
        }

        protected override void EndProcessing()
        {
        }
    }
}