using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Identity.Client;

namespace mdatp_pwsh
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
            HttpResponseMessage apiResponse = new ApiCaller().MakeGetApiCall(apiUri, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            WriteVerbose(apiJson);

            DatpMachineCollection apiResult = JsonConvert.DeserializeObject<DatpMachineCollection>(apiJson);

            foreach (DatpMachine item in apiResult.value)
            {
                WriteObject(item);
            }

        }

        protected override void EndProcessing()
        {
        }
    }

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

            apiUri = $"/users/{userName}/alerts";

            WriteVerbose($"Getting alerts triggered by '{userName}'.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = new ApiCaller().MakeGetApiCall(apiUri, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            WriteVerbose(apiJson);

            DatpAlertCollection apiResult = JsonConvert.DeserializeObject<DatpAlertCollection>(apiJson);

            foreach (DatpAlert item in apiResult.value)
            {
                WriteObject(item);
            }

        }

        protected override void EndProcessing()
        {
        }
    }
}