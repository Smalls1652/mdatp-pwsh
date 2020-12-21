using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;

    [Cmdlet(VerbsCommon.Get, "DatpUserMachines")]
    public class GetDatpUserMachines : DatpCmdlet
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
            apiUri = $"users/{userName}/machines";

            WriteVerbose($"Getting machines '{userName}' has logged into.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Starting api call.");
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            ResponseCollection<Machine> apiResult = JsonSerializer.Deserialize<ResponseCollection<Machine>>(apiJson);

            foreach (Machine item in apiResult.Value)
            {
                WriteObject(item);
            }

        }

        protected override void EndProcessing()
        {
        }
    }
}