using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Helpers;

    [Cmdlet(VerbsLifecycle.Start, "DatpMachineScan")]
    public class StartDatpMachineScan : DatpCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true
        )]
        public List<string> MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private List<string> machineId;

        [Parameter(
            Position = 1
        )]
        [ValidateSet("Quick", "Full")]
        public string ScanType
        {
            get { return scanType; }
            set { scanType = value; }
        }
        private string scanType = "Quick";

        [Parameter(
            Position = 2,
            Mandatory = true
        )]
        [ValidateNotNullOrEmpty()]
        public string Comment
        {
            get { return cmnt; }
            set { cmnt = value; }
        }
        private string cmnt;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            foreach (string machine in machineId)
            {
                MachineScan postObj = new MachineScan();
                postObj.Comment = cmnt;
                postObj.ScanType = scanType;

                string apiPost = JsonSerializer.Serialize<MachineScan>(postObj);
                string apiUri = $"machines/{machine}/runAntiVirusScan";

                WriteVerbose($"Starting a '{scanType} Scan' on '{machine}'.");
                string apiJson = SendApiCall(apiUri, apiPost, HttpMethod.Post);

                ActivityResponse apiResult = new JsonConverter<ActivityResponse>(apiJson).Value;

                WriteObject(apiResult);
            }
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }
}