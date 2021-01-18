using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Helpers;

    [Cmdlet(VerbsCommon.Get, "DatpDomainRelated")]
    public class GetDatpDomainRelated : DatpCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true
        )]
        public string DomainName
        {
            get { return domainName; }
            set { domainName = value; }
        }
        private string domainName;

        [Parameter(
            Position = 1
        )]
        [ValidateSet(
            "Alerts",
            "Machines"
        )]
        public string Type
        {
            get { return searchType; }
            set { searchType = value; }
        }
        private string searchType = "Machines";


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            string apiUri = $"domains/{domainName}/{searchType.ToLower()}";

            WriteVerbose($"Getting related info for domain '{domainName}'.");
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            dynamic apiResult = null;
            switch (searchType)
            {
                case "Alerts":
                    apiResult = new JsonConverter<ResponseCollection<Alert>>(apiJson).Value;
                    break;

                case "Machines":
                    apiResult = new JsonConverter<ResponseCollection<Machine>>(apiJson).Value;
                    break;

            }

            foreach (dynamic obj in apiResult.value)
            {
                WriteObject(obj);
            }

        }
    }
}