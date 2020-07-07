using System;
using System.Management.Automation;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Identity.Client;

using MdatpPwsh.Classes;
using MdatpPwsh.Classes.Post;

namespace MdatpPwsh
{
    [Cmdlet(VerbsLifecycle.Start, "DatpMachineScan")]
    public class StartDatpMachineScan : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public string MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private static string machineId;

        [Parameter(Position = 1)]
        [ValidateSet("Quick", "Full")]
        public string ScanType
        {
            get { return scanType; }
            set { scanType = value; }
        }
        private static string scanType = "Quick";

        [Parameter(Mandatory = true, Position = 2)]
        [ValidateNotNullOrEmpty()]
        public string Comment
        {
            get { return cmnt; }
            set { cmnt = value; }
        }
        private static string cmnt;

        private static string apiUri;

        private static string apiPost;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            MachineScan postObj = new MachineScan();
            postObj.Comment = cmnt;
            postObj.ScanType = scanType;

            apiPost = JsonConvert.SerializeObject(postObj);

            apiUri = $"/machines/{machineId}/runAntiVirusScan";

            WriteVerbose($"Starting a '{scanType} Scan' on '{machineId}'.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = null;

            InvokeDatpPostApiCall invokeDatpPostApiCall = new InvokeDatpPostApiCall();
            invokeDatpPostApiCall.Uri = apiUri;
            invokeDatpPostApiCall.PostBody = apiPost;
            invokeDatpPostApiCall.Token = token;

            foreach (HttpResponseMessage r in invokeDatpPostApiCall.Invoke<HttpResponseMessage>())
            {
                apiResponse = r;
            }

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            WriteVerbose(apiJson);
            ActivityResponse apiResult = JsonConvert.DeserializeObject<ActivityResponse>(apiJson);

            WriteObject(apiResult);
        }

        protected override void EndProcessing()
        {
        }
    }
}