using System;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Enums.Alerts;

    [Cmdlet(VerbsCommon.Get, "DatpAlert")]
    [CmdletBinding(DefaultParameterSetName = "ListAlerts")]
    public class GetDatpAlert : DatpCmdlet
    {
        [Parameter(Position = 0, ParameterSetName = "ListAlerts")]
        public AlertStatus AlertStatus
        {
            get { return alertStatus; }
            set { alertStatus = value; }
        }
        private AlertStatus alertStatus = AlertStatus.New;

        [Parameter(Position = 1, ParameterSetName = "GetAlert")]
        public string AlertId
        {
            get { return alertId; }
            set { alertId = value; }
        }
        private string alertId;

        private static string apiUri;

        protected override void BeginProcessing()
        {
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
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Starting api call.");
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            dynamic apiResult = null;

            switch (ParameterSetName)
            {
                case "GetAlert":
                    apiResult = JsonSerializer.Deserialize<Alert>(apiJson);
                    WriteObject(apiResult);
                    break;

                default:
                    apiResult = JsonSerializer.Deserialize<ResponseCollection<Alert>>(apiJson);

                    foreach (Alert obj in apiResult.value)
                    {
                        WriteObject(obj);
                    }
                    break;
            }
        }
    }
}