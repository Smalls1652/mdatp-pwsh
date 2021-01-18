using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;

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

            
            ResponseCollection<Machine> apiResults = JsonSerializer.Deserialize<ResponseCollection<Machine>>(apiJson);

            foreach (Machine item in apiResults.Value)
            {
                WriteObject(item);
            }
        }
    }
}