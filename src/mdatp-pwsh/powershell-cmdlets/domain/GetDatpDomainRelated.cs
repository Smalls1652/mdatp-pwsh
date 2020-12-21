using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Models.Core;

    [Cmdlet(VerbsCommon.Get, "DatpDomainRelated")]
    public class GetDatpDomainRelated : DatpCmdlet
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
            apiUri = $"domains/{domainName}/{searchType.ToLower()}";
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Starting api call.");
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            dynamic apiResult = null;

            switch (searchType)
            {
                case "Alerts":
                    apiResult = JsonSerializer.Deserialize<ResponseCollection<Alert>>(apiJson);
                    break;

                case "Machines":
                    apiResult = JsonSerializer.Deserialize<ResponseCollection<Machine>>(apiJson);
                    break;

            }

            foreach (dynamic obj in apiResult.value)
            {
                WriteObject(obj);
            }

        }
    }
}