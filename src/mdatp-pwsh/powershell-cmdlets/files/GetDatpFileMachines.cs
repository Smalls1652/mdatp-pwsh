using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;

    [Cmdlet(VerbsCommon.Get, "DatpFileMachines")]
    public class GetDatpFileMachines : DatpCmdlet
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
            apiUri = $"files/{fileIdentifier}/machines";

            WriteVerbose("Starting api call.");
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            ResponseCollection<Machine> apiResult = JsonSerializer.Deserialize<ResponseCollection<Machine>>(apiJson);
            foreach (Machine item in apiResult.Value)
            {
                WriteObject(item);
            }
        }
    }
}