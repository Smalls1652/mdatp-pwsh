using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Helpers;

    [Cmdlet(VerbsCommon.Get, "DatpFile")]
    public class GetDatpFile : DatpCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true
        )]
        public List<string> FileIdentifier
        {
            get { return fileIdentifier; }
            set { fileIdentifier = value; }
        }

        private List<string> fileIdentifier;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            foreach (string identifier in fileIdentifier)
            {
                string apiUri = $"files/{identifier}";

                WriteVerbose($"Getting file info for identifier '{identifier}'.");
                string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

                FileProperties apiResult = new JsonConverter<FileProperties>(apiJson).Value;
                WriteObject(apiResult);
            }
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }
}