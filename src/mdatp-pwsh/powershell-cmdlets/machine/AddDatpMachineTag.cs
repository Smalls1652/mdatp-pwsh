using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;


namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Helpers;

    [Cmdlet(VerbsCommon.Add, "DatpMachineTag")]
    public class AddDatpMachineTag : DatpCmdlet
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
        public string TagName
        {
            get { return tagName; }
            set { tagName = value; }
        }
        private string tagName;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            foreach (string machine in machineId)
            {
                MachineTag postObj = new MachineTag();
                postObj.Value = tagName;
                postObj.Action = "Add";

                string apiPost = JsonSerializer.Serialize<MachineTag>(postObj);
                string apiUri = $"machines/{machine}/tags";

                WriteVerbose($"Adding tag, '{tagName}', to '{machine}'.");
                string apiJson = SendApiCall(apiUri, apiPost, HttpMethod.Post);

                Machine apiResult = new JsonConverter<Machine>(apiJson).Value;
                WriteObject(apiResult);
            }
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }

}