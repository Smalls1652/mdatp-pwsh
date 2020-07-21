using System;
using System.Management.Automation;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Identity.Client;
using MdatpPwsh.Classes;

namespace MdatpPwsh
{
    [Cmdlet(VerbsCommon.Get, "DatpAlerts")]
    public class GetDatpAlerts : PSCmdlet
    {
        private static string apiUri;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            apiUri = $"/alerts";
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

            AlertCollection apiResult = null;

            apiResult = JsonConvert.DeserializeObject<AlertCollection>(apiJson);

            foreach (Alert obj in apiResult.value)
            {
                WriteObject(obj);
            }
        }
    }
}