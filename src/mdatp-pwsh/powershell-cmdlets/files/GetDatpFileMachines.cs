using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Helpers;

    [Cmdlet(VerbsCommon.Get, "DatpFileMachines")]
    public class GetDatpFileMachines : DatpCmdlet
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
            string apiUri = $"files/{fileIdentifier}/machines";

            WriteVerbose($"Getting machines reporting to have seen file identifier '{fileIdentifier}'.");
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            ResponseCollection<Machine> apiResult = new JsonConverter<ResponseCollection<Machine>>(apiJson).Value;
            foreach (Machine item in apiResult.Value)
            {
                WriteObject(item);
            }
        }
    }
}