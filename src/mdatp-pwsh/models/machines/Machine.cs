using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MdatpPwsh.Models
{
    public class Machine
    {
        public Machine()
        {
            GenerateMachinePageUri();
        }

        [JsonPropertyName("computerDnsName")]
        public string ComputerName { get; set; }

        [JsonPropertyName("id")]
        public string MachineId { get; set; }

        [JsonPropertyName("aadDeviceId")]
        public string AadDeviceId { get; set; }

        [JsonPropertyName("machineTags")]
        public string[] MachineTags { get; set; }

        [JsonPropertyName("firstSeen")]
        public DateTime FirstSeen { get; set; }

        [JsonPropertyName("LastSeen")]
        public DateTime LastSeen { get; set; }

        [JsonPropertyName("OsPlatform")]
        public string OsPlatform { get; set; }

        [JsonPropertyName("osVersion")]
        public string OsVersion { get; set; }

        [JsonPropertyName("osBuild")]
        public Nullable<Int64> OsBuild { get; set; }

        [JsonPropertyName("lastIpAddress")]
        public string LastIpAddress { get; set; }

        [JsonPropertyName("lastExternalIpAddress")]
        public string LastExternalIpAddress { get; set; }

        [JsonPropertyName("agentVersion")]
        public Version AgentVersion { get; set; }

        [JsonPropertyName("healthStatus")]
        public string HealthStatus { get; set; }

        [JsonPropertyName("rbacGroupId")]
        public Int64 RbacGroupId { get; set; }

        [JsonPropertyName("rbacGroupName")]
        public string RbacGroupName { get; set; }

        [JsonPropertyName("riskScore")]
        public string RiskScore { get; set; }

        public Uri MachinePage
        {
            get { return machinePage; }
        }
        private Uri machinePage;

        private void GenerateMachinePageUri()
        {
            machinePage = new Uri($"https://securitycenter.windows.com/machines/{this.MachineId}");
        }

    }
}