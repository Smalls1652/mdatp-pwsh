using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;


namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Helpers;

    [Cmdlet(VerbsCommon.Get, "DatpMachine")]
    [CmdletBinding(DefaultParameterSetName = "AllMachines")]
    public class GetDatpMachine : DatpCmdlet
    {
        [Parameter(
            Position = 0,
            ParameterSetName = "SingleMachine",
            ValueFromPipelineByPropertyName = true
        )]
        public List<string> MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private List<string> machineId;

        [Parameter(
            Position = 1,
            ParameterSetName = "AllMachines"
        )]
        public SwitchParameter AllMachines
        {
            get { return allMachines; }
            set { allMachines = value; }
        }
        private SwitchParameter allMachines = true;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            string apiUri;
            string apiJson;

            WriteVerbose("Starting api call.");
            switch (ParameterSetName)
            {
                case "SingleMachine":
                    foreach (string machine in machineId)
                    {
                        apiUri = $"machines/{machine}";
                        apiJson = SendApiCall(apiUri, null, HttpMethod.Get);
                        Machine apiResult = new JsonConverter<Machine>(apiJson).Value;

                        WriteObject(apiResult);
                    }
                    break;

                case "AllMachines":
                    apiUri = $"machines";
                    apiJson = SendApiCall(apiUri, null, HttpMethod.Get);
                    ResponseCollection<Machine> apiResults = new JsonConverter<ResponseCollection<Machine>>(apiJson).Value;

                    foreach (Machine item in apiResults.Value)
                    {
                        WriteObject(item);
                    }
                    break;
            }
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }
}