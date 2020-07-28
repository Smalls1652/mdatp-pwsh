using System;
using System.Management.Automation;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Identity.Client;

using MdatpPwsh.Classes;

namespace MdatpPwsh
{
    [Cmdlet(VerbsCommon.Get, "DatpMachineAlerts")]
    public class GetDatpMachineAlerts : DatpCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private static string machineId;

        private static string apiUri;

        protected override void BeginProcessing()
        {
            apiUri = $"machines/{machineId}/alerts";

            WriteVerbose($"Getting alerts triggered by '{machineId}'.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Starting api call.");
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            AlertCollection apiResult = JsonConvert.DeserializeObject<AlertCollection>(apiJson);

            foreach (Alert item in apiResult.value)
            {
                WriteObject(item);
            }

        }

        protected override void EndProcessing()
        {
        }
    }
}