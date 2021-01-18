using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Helpers;

    [Cmdlet(VerbsCommon.Get, "DatpFileStats")]
    public class GetDatpFileStats : DatpCmdlet
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
            string apiUri = $"files/{fileIdentifier}/stats";

            WriteVerbose($"Getting stats for file identifier '{fileIdentifier}'.");
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            FileStats apiResult = new JsonConverter<FileStats>(apiJson).Value;
            WriteObject(apiResult);
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }
}