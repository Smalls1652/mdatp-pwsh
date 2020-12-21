using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;

    [Cmdlet(VerbsCommon.Get, "DatpDomainStats")]
    public class GetDatpDomainStats : DatpCmdlet
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
            apiUri = $"domains/{domainName}/stats";
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Starting api call.");
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            DomainStats apiResult = JsonSerializer.Deserialize<DomainStats>(apiJson);

            WriteObject(apiResult);

        }
    }
}