using System;
using System.Management.Automation;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Identity.Client;

namespace MdatpPwsh
{
    using Classes;

    [Cmdlet(VerbsCommon.Get, "DatpFileMachines")]
    public class GetDatpFileMachines : PSCmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public string FileIdentifier
        {
            get { return fileIdentifier; }
            set { fileIdentifier = value; }
        }

        private string fileIdentifier;

        private string apiUri;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }
        }

        protected override void ProcessRecord()
        {
            apiUri = $"files/{fileIdentifier}/machines";

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

            MachineCollection apiResult = JsonConvert.DeserializeObject<MachineCollection>(apiJson);
            foreach (Machine item in apiResult.value)
            {
                WriteObject(item);
            }
        }
    }
}