using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Helpers;

    [Cmdlet(VerbsCommon.Get, "DatpDomainStats")]
    public class GetDatpDomainStats : DatpCmdlet
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

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            string apiUri = $"domains/{domainName}/stats";

            WriteVerbose($"Getting stats for domain '{domainName}'.");
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            DomainStats apiResult = new JsonConverter<DomainStats>(apiJson).Value;

            WriteObject(apiResult);
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }
}