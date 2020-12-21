using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;


namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;

    [Cmdlet(VerbsCommon.Add, "DatpMachineTag")]
    public class AddDatpMachineTag : DatpCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public string MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private static string machineId;

        [Parameter(Mandatory = true, Position = 1)]
        public string TagName
        {
            get { return tagName; }
            set { tagName = value; }
        }
        private static string tagName;

        private static string apiUri;

        private static string apiPost;

        protected override void BeginProcessing()
        {
            MachineTag postObj = new MachineTag();
            postObj.Value = tagName;
            postObj.Action = "Add";

            apiPost = JsonSerializer.Serialize<MachineTag>(postObj);

            apiUri = $"machines/{machineId}/tags";

            WriteVerbose($"Adding tag, '{tagName}', to '{machineId}'.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Starting api call.");
            string apiJson = SendApiCall(apiUri, apiPost, HttpMethod.Post);

            Machine apiResult = JsonSerializer.Deserialize<Machine>(apiJson);

            WriteObject(apiResult);
        }

        protected override void EndProcessing()
        {
        }
    }

}