using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Helpers;

    [Cmdlet(VerbsCommon.Get, "DatpMachineUsers")]
    public class GetDatpMachineUsers : DatpCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true
        )]
        public List<string> MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private List<string> machineId;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            foreach (string machine in machineId)
            {
                WriteVerbose($"Getting users who have logged onto '{machine}'.");

                string apiUri = $"machines/{machine}/logonusers";
                string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

                ResponseCollection<User> apiResult = new JsonConverter<ResponseCollection<User>>(apiJson).Value;

                foreach (User item in apiResult.Value)
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