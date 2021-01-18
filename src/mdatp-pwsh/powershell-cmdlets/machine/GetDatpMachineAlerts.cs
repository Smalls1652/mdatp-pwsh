using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;

    [Cmdlet(VerbsCommon.Get, "DatpMachineAlerts")]
    public class GetDatpMachineAlerts : DatpCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true
        )]
        public string MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private static string machineId;

        private static string apiUri;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            apiUri = $"machines/{machineId}/alerts";

            WriteVerbose($"Getting alerts triggered by '{machineId}'.");

            WriteVerbose("Starting api call.");
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            ResponseCollection<Alert> apiResult = JsonSerializer.Deserialize<ResponseCollection<Alert>>(apiJson);

            foreach (Alert item in apiResult.Value)
            {
                WriteObject(item);
            }

        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }
}