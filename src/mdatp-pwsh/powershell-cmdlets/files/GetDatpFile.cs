using System;
using System.Management.Automation;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Identity.Client;

namespace MdatpPwsh
{
    using Classes;

    [Cmdlet(VerbsCommon.Get, "DatpFile")]
    public class GetDatpFile : DatpCmdlet
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
            apiUri = $"files/{fileIdentifier}";

            WriteVerbose("Starting api call.");
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            FileProperties apiResult = JsonConvert.DeserializeObject<FileProperties>(apiJson);

            WriteObject(apiResult);
        }
    }
}