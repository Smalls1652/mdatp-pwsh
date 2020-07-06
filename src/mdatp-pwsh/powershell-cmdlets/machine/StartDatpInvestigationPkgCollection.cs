using System;
using System.Management.Automation;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Identity.Client;

using MdatpPwsh.Classes;
using MdatpPwsh.Classes.Post;

namespace MdatpPwsh
{
    [Cmdlet(VerbsLifecycle.Start, "DatpInvestigationPkgCollection")]
    public class StartDatpInvestigationPkgCollection : PSCmdlet
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

        private static string apiUri;

        private static string apiPost;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            CollectInvestigationPackage postObj = new CollectInvestigationPackage();
            postObj.Comment = cmnt;

            apiPost = JsonConvert.SerializeObject(postObj);

            apiUri = $"/machines/{machineId}/collectInvestigationPackage";

            WriteVerbose($"Initiating investigaton package collection on '{machineId}'.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = new ApiCaller().MakePostApiCall(apiUri, apiPost, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            ActivityResponse apiResult = JsonConvert.DeserializeObject<ActivityResponse>(apiJson);

            WriteObject(apiResult);
        }

        protected override void EndProcessing()
        {
        }
    }
}