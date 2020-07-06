using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Identity.Client;

using MdatpPwsh.Classes;
using MdatpPwsh.Classes.Post;

namespace MdatpPwsh
{
    [Cmdlet(VerbsCommon.Remove, "DatpMachineTag")]
    public class RemoveDatpMachineTag : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public string MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private static string machineId;

        [Parameter(Mandatory = true, Position = 1)]
        public string TagName
        {
            get { return tagName; }
            set { tagName = value; }
        }
        private static string tagName;

        private static string apiUri;

        private static string apiPost;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            MachineTag postObj = new MachineTag();
            postObj.Value = tagName;
            postObj.Action = "Remove";

            apiPost = JsonConvert.SerializeObject(postObj);

            apiUri = $"/machines/{machineId}/tags";

            WriteVerbose($"Adding tag, '{tagName}', to '{machineId}'.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = new ApiCaller().MakePostApiCall(apiUri, apiPost, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            Machine apiResult = JsonConvert.DeserializeObject<Machine>(apiJson);

            WriteObject(apiResult);
        }

        protected override void EndProcessing()
        {
        }
    }
}