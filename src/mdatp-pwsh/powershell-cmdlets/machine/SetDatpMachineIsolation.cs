using System;
using System.Management.Automation;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Identity.Client;

using MdatpPwsh.Classes;
using MdatpPwsh.Classes.Post;

namespace MdatpPwsh
{
    [Cmdlet(VerbsCommon.Set, "DatpMachineIsolation")]
    public class SetDatpMachineIsolation : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public string MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private static string machineId;

        [Parameter(Mandatory = true, Position = 1)]
        public string Comment
        {
            get { return cmnt; }
            set { cmnt = value; }
        }
        private static string cmnt;

        [Parameter(Mandatory = true, Position = 2)]
        [ValidateSet(
            "Full Isolation",
            "Selective Isolation",
            "Release Isolation"
        )]
        public string IsolationType
        {
            get { return isoType; }
            set { isoType = value; }
        }
        private static string isoType;

        private static string apiUri;
        private static string apiPost;
        private static ActivityResponse apiResult;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            switch (isoType)
            {
                case "Full Isolation":
                    apiUri = $"machines/{machineId}/isolate";
                    IsolateMachine isoFullPostObj = new IsolateMachine();
                    isoFullPostObj.Comment = cmnt;
                    isoFullPostObj.IsolationType = "Full";
                    apiPost = JsonConvert.SerializeObject(isoFullPostObj);
                    break;

                case "Selective Isolation":
                    apiUri = $"machines/{machineId}/isolate";
                    IsolateMachine isoSelPostObj = new IsolateMachine();
                    isoSelPostObj.Comment = cmnt;
                    isoSelPostObj.IsolationType = "Selective";
                    apiPost = JsonConvert.SerializeObject(isoSelPostObj);
                    break;

                case "Release Isolation":
                    apiUri = $"machines/{machineId}/unisolate";
                    UnIsolateMachine unIsoPost = new UnIsolateMachine();
                    unIsoPost.Comment = cmnt;
                    apiPost = JsonConvert.SerializeObject(unIsoPost);
                    break;
            }

            WriteVerbose($"Getting machine info for {machineId}");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = null;

            InvokeDatpApiCall invokeDatpApiCall = new InvokeDatpApiCall(apiUri, token, HttpMethod.Post, apiPost);
            foreach (HttpResponseMessage r in invokeDatpApiCall.Invoke<HttpResponseMessage>())
            {
                apiResponse = r;
            }

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            apiResult = JsonConvert.DeserializeObject<ActivityResponse>(apiJson);

        }

        protected override void EndProcessing()
        {
            WriteObject(apiResult);
        }
    }
}