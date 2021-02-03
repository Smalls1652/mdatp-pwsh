using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Helpers;

    [Cmdlet(VerbsCommon.Get, "DatpUserAlerts")]
    [OutputType(
        typeof(Alert),
        typeof(Alert[])
    )]
    public class GetDatpUserAlerts : DatpCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true
        )]
        public string[] UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string[] userName;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            foreach (string user in userName)
            {
                string apiUri = $"users/{user}/alerts";

                WriteVerbose($"Getting alerts triggered by '{user}'.");
                string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

                ResponseCollection<Alert> apiResult = new JsonConverter<ResponseCollection<Alert>>(apiJson).Value;

                foreach (Alert item in apiResult.Value)
                {
                    WriteObject(item);
                }
            }
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }
}