using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;

    [Cmdlet(VerbsCommon.Get, "DatpMachineAction")]
    [CmdletBinding(DefaultParameterSetName = "AllActivities")]
    public class GetDatpMachineAction : DatpCmdlet
    {
        [Parameter(
            Position = 0,
            ParameterSetName = "SingleActivity",
            ValueFromPipelineByPropertyName = true
        )]
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
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case "SingleActivity":
                    apiUri = $"machineactions/{activityId}";
                    break;

                case "AllActivities":
                    apiUri = $"machineactions";
                    break;
            }
            
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            switch (ParameterSetName)
            {
                case "SingleActivity":
                    ActivityResponse apiResult = JsonSerializer.Deserialize<ActivityResponse>(apiJson);
                    WriteObject(apiResult);
                    break;

                case "AllActivities":
                    ResponseCollection<ActivityResponse> apiResults = JsonSerializer.Deserialize<ResponseCollection<ActivityResponse>>(apiJson);

                    foreach (ActivityResponse item in apiResults.Value)
                    {
                        WriteObject(item);
                    }
                    break;
            }

        }
    }
}