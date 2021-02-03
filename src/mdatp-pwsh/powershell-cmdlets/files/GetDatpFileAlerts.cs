using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Helpers;

    [Cmdlet(VerbsCommon.Get, "DatpFileAlerts")]
    [OutputType(typeof(Alert[]))]
    public class GetDatpFileAlerts : DatpCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true
        )]
        public string FileIdentifier
        {
            get { return fileIdentifier; }
            set { fileIdentifier = value; }
        }
        private string fileIdentifier;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            string apiUri = $"files/{fileIdentifier}/alerts";
            
            WriteVerbose($"Getting alerts for file identifier '{fileIdentifier}'.");
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            ResponseCollection<Alert> apiResult = new JsonConverter<ResponseCollection<Alert>>(apiJson).Value;
            foreach (Alert item in apiResult.Value)
            {
                WriteObject(item);
            }
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }
}