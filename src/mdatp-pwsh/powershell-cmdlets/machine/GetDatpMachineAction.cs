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
    [Cmdlet(VerbsCommon.Get, "DatpMachineAction")]
    [CmdletBinding(DefaultParameterSetName = "AllActivities")]
    public class GetDatpMachineAction : PSCmdlet
    {
        [Parameter(Position = 0, ParameterSetName = "SingleActivity")]
        public string ActivityId
        {
            get { return activityId; }
            set { activityId = value; }
        }
        private static string activityId;

        [Parameter(Position = 1, ParameterSetName = "AllActivities")]
        public SwitchParameter AllActivities
        {
            get { return allActivities; }
            set { allActivities = value; }
        }
        private static SwitchParameter allActivities;

        private static string apiUri;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            switch (ParameterSetName)
            {
                case "SingleActivity":
                    apiUri = $"/machineactions/{activityId}";
                    break;

                case "AllActivities":
                    apiUri = $"/machineactions";
                    break;
            }
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = new ApiCaller().MakeGetApiCall(apiUri, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            WriteVerbose(apiJson);

            switch (ParameterSetName)
            {
                case "SingleActivity":
                    ActivityResponse apiResult = JsonConvert.DeserializeObject<ActivityResponse>(apiJson);
                    WriteObject(apiResult);
                    break;

                case "AllActivities":
                    ActivityResponseCollection apiResults = JsonConvert.DeserializeObject<ActivityResponseCollection>(apiJson);

                    foreach (ActivityResponse item in apiResults.value)
                    {
                        WriteObject(item);
                    }
                    break;
            }

        }
    }
}