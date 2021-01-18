using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;

    [Cmdlet(VerbsCommon.Get, "DatpUserAlerts")]
    public class GetDatpUserAlerts : DatpCmdlet
    {
        [Parameter(Mandatory = true)]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private static string userName;

        private static string apiUri;

        protected override void BeginProcessing()
        {
            apiUri = $"users/{userName}/alerts";

            WriteVerbose($"Getting alerts triggered by '{userName}'.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Starting api call.");
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            ResponseCollection<Alert> apiResult = JsonSerializer.Deserialize<ResponseCollection<Alert>>(apiJson);

            foreach (Alert item in apiResult.Value)
            {
                WriteObject(item);
            }

        }

        protected override void EndProcessing()
        {
        }
    }
}