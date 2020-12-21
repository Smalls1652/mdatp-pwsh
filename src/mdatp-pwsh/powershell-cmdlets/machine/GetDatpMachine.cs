using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;


namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    
    [Cmdlet(VerbsCommon.Get, "DatpMachine")]
    [CmdletBinding(DefaultParameterSetName = "AllMachines")]
    public class GetDatpMachine : DatpCmdlet
    {
        [Parameter(Position = 0, ParameterSetName = "SingleMachine", ValueFromPipelineByPropertyName = true)]
        public string MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private static string machineId;

        [Parameter(Position = 1, ParameterSetName = "AllMachines")]
        public SwitchParameter AllMachines
        {
            get { return allMachines; }
            set { allMachines = value; }
        }
        private static SwitchParameter allMachines = true;

        private static string apiUri;

        protected override void BeginProcessing()
        {
            switch (ParameterSetName)
            {
                case "SingleMachine":
                    apiUri = $"machines/{machineId}";
                    break;

                case "AllMachines":
                    apiUri = $"machines";
                    break;
            }
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Starting api call.");
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            switch (ParameterSetName)
            {
                case "SingleMachine":
                    Machine apiResult = JsonSerializer.Deserialize<Machine>(apiJson);
                    WriteObject(apiResult);
                    break;

                case "AllMachines":
                    ResponseCollection<Machine> apiResults = JsonSerializer.Deserialize<ResponseCollection<Machine>>(apiJson);

                    foreach (Machine item in apiResults.Value)
                    {
                        WriteObject(item);
                    }
                    break;
            }

        }
    }
}