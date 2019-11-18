using System;
using System.Management.Automation;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Identity.Client;

namespace mdatp_pwsh
{
    [Cmdlet(VerbsCommon.Get, "DatpDomainStats")]
    public class GetDatpDomainStats : PSCmdlet
    {
        [Parameter(Position = 0)]
        public string DomainName
        {
            get { return domainName; }
            set { domainName = value; }
        }
        private static string domainName;

        private static string apiUri;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            apiUri = $"/domains/{domainName}/stats";
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = new ApiCaller().MakeGetApiCall(apiUri, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            WriteVerbose(apiJson);

            DatpDomainStats apiResult = JsonConvert.DeserializeObject<DatpDomainStats>(apiJson);

            WriteObject(apiResult);

        }
    }

    [Cmdlet(VerbsCommon.Get, "DatpDomainRelated")]
    public class GetDatpDomainRelated : PSCmdlet
    {
        [Parameter(Position = 0)]
        public string DomainName
        {
            get { return domainName; }
            set { domainName = value; }
        }
        private static string domainName;

        [Parameter(Position = 1)]
        [ValidateSet(
            "Alerts",
            "Machines"
        )]
        public string Type
        {
            get { return searchType; }
            set { searchType = value; }
        }
        private static string searchType = "Machines";

        private static string apiUri;


        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            apiUri = $"/domains/{domainName}/{searchType.ToLower()}";
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = new ApiCaller().MakeGetApiCall(apiUri, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            WriteVerbose(apiJson);

            dynamic apiResult = null;

            switch (searchType)
            {
                case "Alerts":
                    apiResult = JsonConvert.DeserializeObject<DatpAlertCollection>(apiJson);
                    break;

                case "Machines":
                    apiResult = JsonConvert.DeserializeObject<DatpMachineCollection>(apiJson);
                    break;

            }

            foreach (dynamic obj in apiResult.value)
            {
                WriteObject(obj);
            }

        }
    }

}