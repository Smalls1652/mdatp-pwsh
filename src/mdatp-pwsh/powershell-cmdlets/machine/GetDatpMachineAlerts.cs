using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Helpers;

    [Cmdlet(VerbsCommon.Get, "DatpMachineAlerts")]
    public class GetDatpMachineAlerts : DatpCmdlet
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


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            foreach (string machine in machineId)
            {
                string apiUri = $"machines/{machine}/alerts";

                WriteVerbose($"Getting alerts triggered by '{machine}'.");

                string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

                ResponseCollection<Alert> apiResult = new JsonConverter<ResponseCollection<Alert>>(apiJson).Value;

                foreach (Alert item in apiResult.Value)
                {
                    WriteObject(item);
                }
            }
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }
}