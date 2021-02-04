using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;


namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Helpers;

    [Cmdlet(VerbsCommon.Get, "DatpExposureScoreForOrg")]
    [OutputType(typeof(ExposureScore))]
    public class GetDatpExposureScoreForOrg : DatpCmdlet
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
            apiUri = $"exposureScore";
            apiJson = SendApiCall(apiUri, null, HttpMethod.Get);
            ExposureScore apiResult = new JsonConverter<ExposureScore>(apiJson).Value;

            WriteObject(apiResult);
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }
}