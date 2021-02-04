using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Helpers;

    [Cmdlet(VerbsCommon.Get, "DatpDomainRelated")]
    [OutputType(
        typeof(Machine[]),
        typeof(Alert[])
    )]
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

            switch (searchType)
            {
                case "Alerts":
                    ResponseCollection<Alert> apiResultAlerts = new JsonConverter<ResponseCollection<Alert>>(apiJson).Value;

                    foreach (Alert obj in apiResultAlerts.Value)
                    {
                        WriteObject(obj);
                    }
                    break;

                case "Machines":
                    ResponseCollection<Machine> apiResultMachines = new JsonConverter<ResponseCollection<Machine>>(apiJson).Value;

                    foreach (Machine obj in apiResultMachines.Value)
                    {
                        WriteObject(obj);
                    }
                    break;

            }
        }
    }
}