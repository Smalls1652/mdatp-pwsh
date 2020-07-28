using System;
using System.Management.Automation;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Identity.Client;

namespace MdatpPwsh
{
    using Classes;

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

            MachineCollection apiResult = JsonConvert.DeserializeObject<MachineCollection>(apiJson);
            foreach (Machine item in apiResult.value)
            {
                WriteObject(item);
            }
        }
    }
}