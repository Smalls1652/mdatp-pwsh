using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;

    [Cmdlet(VerbsCommon.Get, "DatpFileAlerts")]
    public class GetDatpFileAlerts : DatpCmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public string FileIdentifier
        {
            get { return fileIdentifier; }
            set { fileIdentifier = value; }
        }

        private string fileIdentifier;

        private string apiUri;

        protected override void ProcessRecord()
        {
            apiUri = $"files/{fileIdentifier}/alerts";
            
            WriteVerbose("Starting api call.");
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            ResponseCollection<Alert> apiResult = JsonSerializer.Deserialize<ResponseCollection<Alert>>(apiJson);
            foreach (Alert item in apiResult.Value)
            {
                WriteObject(item);
            }
        }
    }
}