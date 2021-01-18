using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Helpers;

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
        private string activityId;

        [Parameter(Position = 1, ParameterSetName = "AllActivities")]
        public SwitchParameter AllActivities
        {
            get { return allActivities; }
            set { allActivities = value; }
        }
        private SwitchParameter allActivities;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            string apiUri;
            switch (ParameterSetName)
            {
                case "AllActivities":
                    apiUri = $"machineactions";
                    break;

                default:
                    apiUri = $"machineactions/{activityId}";
                    break;
            }
            
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            switch (ParameterSetName)
            {
                case "SingleActivity":
                    ActivityResponse apiResult = new JsonConverter<ActivityResponse>(apiJson).Value;
                    WriteObject(apiResult);
                    break;

                case "AllActivities":
                    ResponseCollection<ActivityResponse> apiResults = new JsonConverter<ResponseCollection<ActivityResponse>>(apiJson).Value;

                    foreach (ActivityResponse item in apiResults.Value)
                    {
                        WriteObject(item);
                    }
                    break;
            }

        }
    }
}