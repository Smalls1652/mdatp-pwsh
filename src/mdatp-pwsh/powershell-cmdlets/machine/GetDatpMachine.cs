using System;
using System.Management.Automation;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Identity.Client;

using MdatpPwsh.Classes;

namespace MdatpPwsh
{
    [Cmdlet(VerbsCommon.Get, "DatpMachine")]
    [CmdletBinding(DefaultParameterSetName = "AllMachines")]
    public class GetDatpMachine : PSCmdlet
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
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

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
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = null;

            InvokeDatpApiCall invokeDatpApiCall = new InvokeDatpApiCall(apiUri, token, HttpMethod.Get);
            foreach (HttpResponseMessage r in invokeDatpApiCall.Invoke<HttpResponseMessage>())
            {
                apiResponse = r;
            }

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            WriteVerbose(apiJson);

            switch (ParameterSetName)
            {
                case "SingleMachine":
                    Machine apiResult = JsonConvert.DeserializeObject<Machine>(apiJson);
                    WriteObject(apiResult);
                    break;

                case "AllMachines":
                    MachineCollection apiResults = JsonConvert.DeserializeObject<MachineCollection>(apiJson);

                    foreach (Machine item in apiResults.value)
                    {
                        WriteObject(item);
                    }
                    break;
            }

        }
    }
}