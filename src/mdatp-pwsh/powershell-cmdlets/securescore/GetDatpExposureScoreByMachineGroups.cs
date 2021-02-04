using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;


namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Helpers;

    [Cmdlet(VerbsCommon.Get, "DatpExposureScoreByMachineGroups")]
    [OutputType(typeof(SecureScore[]))]
    public class GetDatpExposureScoreByMachineGroups : DatpCmdlet
    {
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            string apiUri;
            string apiJson;

            WriteVerbose("Starting api call.");
            apiUri = $"exposureScore/ByMachineGroups";
            apiJson = SendApiCall(apiUri, null, HttpMethod.Get);
            ResponseCollection<SecureScore> apiResult = new JsonConverter<ResponseCollection<SecureScore>>(apiJson).Value;

            foreach (SecureScore item in apiResult.Value)
            {
                WriteObject(item);
            }
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }
}