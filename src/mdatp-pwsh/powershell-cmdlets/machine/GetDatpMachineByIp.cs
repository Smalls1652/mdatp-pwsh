using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Helpers;

    [Cmdlet(VerbsCommon.Get, "DatpMachineByIp")]
    [OutputType(
        typeof(Machine),
        typeof(Machine[])
    )]
    public class GetDatpMachineByIp : DatpCmdlet
    {
        [Parameter(
            Position = 0,
            ValueFromPipelineByPropertyName = true
        )]
        public string[] IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }
        private string[] ipAddress;

        public DateTime TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }
        private DateTime timeStamp = DateTime.Now;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            foreach (string ipAddr in ipAddress)
            {
                string apiUri = $"machines/findbyip(ip='{ipAddr}',timestamp={timeStamp.ToString("yyyy-MM-ddTHH:mm:ssZ")})";

                string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);
                ResponseCollection<Machine> apiResults = new JsonConverter<ResponseCollection<Machine>>(apiJson).Value;
                
                foreach (Machine item in apiResults.Value)
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