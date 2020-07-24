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
        [Parameter(Position = 0)]
        [ValidateSet(
            "All",
            "InProgress",
            "New",
            "Resolved",
            "Unknown"
        )]
        public string AlertStatus {
            get { return alertStatus; }
            set { alertStatus = value; }
        }
        private string alertStatus = "New";

        private static string apiUri;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            switch (alertStatus)
            {
                case "InProgress":
                    apiUri = $"alerts?$filter=status eq 'InProgress'";
                    break;

                case "New":
                    apiUri = $"alerts?$filter=status eq 'New'";
                    break;

                case "Resolved":
                    apiUri = $"alerts?$filter=status eq 'Resolved'";
                    break;

                case "Unknown":
                    apiUri = $"alerts?$filter=status eq 'Unknown'";
                    break;

                default:
                    apiUri = $"alerts";
                    break;

            }
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