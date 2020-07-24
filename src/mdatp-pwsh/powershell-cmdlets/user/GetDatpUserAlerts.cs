using System;
using System.Management.Automation;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Identity.Client;

using MdatpPwsh.Classes;

namespace MdatpPwsh
{
    [Cmdlet(VerbsCommon.Get, "DatpUserAlerts")]
    public class GetDatpUserAlerts : PSCmdlet
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

            apiUri = $"users/{userName}/alerts";

            WriteVerbose($"Getting alerts triggered by '{userName}'.");
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