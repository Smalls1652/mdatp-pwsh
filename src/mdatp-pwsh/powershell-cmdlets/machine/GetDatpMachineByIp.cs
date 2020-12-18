using System;
using System.Management.Automation;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Identity.Client;

using MdatpPwsh.Classes;

namespace MdatpPwsh
{
    [Cmdlet(VerbsCommon.Get, "DatpMachineByIp")]
    public class GetDatpMachineByIp : DatpCmdlet
    {
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true)]
        public string IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }
        private string ipAddress;

        public DateTime TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }
        private DateTime timeStamp = DateTime.Now;

        private string apiUri;

        protected override void ProcessRecord()
        {
            apiUri = $"machines/findbyip(ip='{ipAddress}',timestamp={timeStamp.ToString("yyyy-MM-ddTHH:mm:ssZ")})";

            WriteVerbose("Starting api call.");
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            
            MachineCollection apiResults = JsonConvert.DeserializeObject<MachineCollection>(apiJson);

            foreach (Machine item in apiResults.value)
            {
                WriteObject(item);
            }
        }
    }
}