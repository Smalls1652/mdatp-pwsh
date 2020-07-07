using System;
using System.Management.Automation;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Identity.Client;

using MdatpPwsh.Classes;

namespace MdatpPwsh
{
    [Cmdlet(VerbsCommon.Get, "DatpUserMachines")]
    public class GetDatpUserMachines : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private static string userName;

        private static string apiUri;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            apiUri = $"/users/{userName}/machines";

            WriteVerbose($"Getting machines '{userName}' has logged into.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = null;

            InvokeDatpGetApiCall invokeDatpGetApiCall = new InvokeDatpGetApiCall();
            invokeDatpGetApiCall.Uri = apiUri;
            invokeDatpGetApiCall.Token = token;

            foreach (HttpResponseMessage r in invokeDatpGetApiCall.Invoke<HttpResponseMessage>())
            {
                apiResponse = r;
            }

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            WriteVerbose(apiJson);

            MachineCollection apiResult = JsonConvert.DeserializeObject<MachineCollection>(apiJson);

            foreach (Machine item in apiResult.value)
            {
                WriteObject(item);
            }

        }

        protected override void EndProcessing()
        {
        }
    }
}