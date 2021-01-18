using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;

    [Cmdlet(VerbsLifecycle.Start, "DatpInvestigationPkgCollection")]
    public class StartDatpInvestigationPkgCollection : DatpCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public string MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private static string machineId;

        [Parameter(Mandatory = true, Position = 1)]
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
            CollectInvestigationPackage postObj = new CollectInvestigationPackage();
            postObj.Comment = cmnt;

            apiPost = JsonSerializer.Serialize<CollectInvestigationPackage>(postObj);

            apiUri = $"machines/{machineId}/collectInvestigationPackage";

            WriteVerbose($"Initiating investigaton package collection on '{machineId}'.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Starting api call.");
            string apiJson = SendApiCall(apiUri, apiPost, HttpMethod.Post);

            ActivityResponse apiResult = JsonSerializer.Deserialize<ActivityResponse>(apiJson);

            WriteObject(apiResult);
        }

        protected override void EndProcessing()
        {
        }
    }
}