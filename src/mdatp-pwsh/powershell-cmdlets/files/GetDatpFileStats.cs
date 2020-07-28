using System;
using System.Management.Automation;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Identity.Client;

namespace MdatpPwsh
{
    using Classes;

    [Cmdlet(VerbsCommon.Get, "DatpFileStats")]
    public class GetDatpFileStats : DatpCmdlet
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
            apiUri = $"files/{fileIdentifier}/stats";

            WriteVerbose("Starting api call.");
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            FileStats apiResult = JsonConvert.DeserializeObject<FileStats>(apiJson);

            WriteObject(apiResult);
        }
    }
}