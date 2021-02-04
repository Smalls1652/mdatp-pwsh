using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Helpers;

    [Cmdlet(VerbsLifecycle.Start, "DatpInvestigationPkgCollection")]
    [OutputType(typeof(ActivityResponse))]
    public class StartDatpInvestigationPkgCollection : DatpCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true
        )]
        public string[] MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private string[] machineId;

        [Parameter(
            Position = 1,
            Mandatory = true
        )]
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
                CollectInvestigationPackage postObj = new CollectInvestigationPackage();
                postObj.Comment = cmnt;

                string apiPost = JsonSerializer.Serialize<CollectInvestigationPackage>(postObj);
                string apiUri = $"machines/{machine}/collectInvestigationPackage";

                WriteVerbose($"Initiating investigaton package collection on '{machine}'.");
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