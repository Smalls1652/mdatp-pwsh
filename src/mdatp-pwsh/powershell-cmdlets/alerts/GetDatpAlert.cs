using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Helpers;
    using MdatpPwsh.Models;
    using MdatpPwsh.Enums.Alerts;

    [Cmdlet(VerbsCommon.Get, "DatpAlert")]
    [CmdletBinding(DefaultParameterSetName = "ListAlerts")]
    [OutputType(typeof(Alert[]))]
    public class GetDatpAlert : DatpCmdlet
    {
        [Parameter(
            Position = 0,
            ParameterSetName = "ListAlerts"
        )]
        public AlertStatus AlertStatus
        {
            get { return alertStatus; }
            set { alertStatus = value; }
        }
        private AlertStatus alertStatus = AlertStatus.New;

        [Parameter(
            Position = 1,
            ParameterSetName = "GetAlert"
        )]
        public string AlertId
        {
            get { return alertId; }
            set { alertId = value; }
        }
        private string alertId;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            string apiUri;
            switch (ParameterSetName)
            {
                case "GetAlert":
                    apiUri = $"alerts/{alertId}";
                    break;

                default:
                    switch (alertStatus)
                    {
                        case AlertStatus.InProgress:
                            apiUri = $"alerts?$filter=status eq 'InProgress'";
                            break;

                        case AlertStatus.New:
                            apiUri = $"alerts?$filter=status eq 'New'";
                            break;

                        case AlertStatus.Resolved:
                            apiUri = $"alerts?$filter=status eq 'Resolved'";
                            break;

                        case AlertStatus.Unknown:
                            apiUri = $"alerts?$filter=status eq 'Unknown'";
                            break;

                        default:
                            apiUri = $"alerts";
                            break;
                    }
                    break;
            }

            WriteVerbose("Getting alerts.");
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            dynamic apiResult = null;

            switch (ParameterSetName)
            {
                case "GetAlert":
                    apiResult = new JsonConverter<Alert>(apiJson).Value;
                    WriteObject(apiResult);
                    break;

                default:
                    apiResult = new JsonConverter<ResponseCollection<Alert>>(apiJson).Value;

                    foreach (Alert obj in apiResult.Value)
                    {
                        WriteObject(obj);
                    }
                    break;
            }
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }
}