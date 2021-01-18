using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Helpers;

    [Cmdlet(VerbsCommon.Get, "DatpUserMachines")]
    public class GetDatpUserMachines : DatpCmdlet
    {
        [Parameter(Mandatory = true)]
        public List<string> UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private List<string> userName;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            foreach (string user in userName)
            {
                string apiUri = $"users/{userName}/machines";

                WriteVerbose($"Getting machines '{userName}' has logged into.");
                string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

                ResponseCollection<Machine> apiResult = new JsonConverter<ResponseCollection<Machine>>(apiJson).Value;

                foreach (Machine item in apiResult.Value)
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