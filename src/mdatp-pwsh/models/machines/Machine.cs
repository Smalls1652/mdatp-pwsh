using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MdatpPwsh.Models
{
    public class Machine
    {
        [JsonPropertyName("computerDnsName")]
        public string ComputerName { get; set; }

        [JsonPropertyName("id")]
        public string MachineId { get; set; }

        [JsonPropertyName("aadDeviceId")]
        public string AadDeviceId { get; set; }

        [JsonPropertyName("machineTags")]
        public List<string> MachineTags { get; set; }

        [JsonPropertyName("firstSeen")]
        public DateTime FirstSeen
        {
            get { return this.firstSeen; }
            set { firstSeen = value.ToLocalTime(); }
        }
        private DateTime firstSeen;

        [JsonPropertyName("lastSeen")]
        public DateTime LastSeen
        {
            get { return this.lastSeen; }
            set { lastSeen = value.ToLocalTime(); }
        }
        private DateTime lastSeen;

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
        public string AgentVersion { get; set; }

        [JsonPropertyName("healthStatus")]
        public string HealthStatus { get; set; }

        [JsonPropertyName("rbacGroupId")]
        public Int64 RbacGroupId { get; set; }

        [JsonPropertyName("rbacGroupName")]
        public string RbacGroupName { get; set; }

        [JsonPropertyName("riskScore")]
        public string RiskScore { get; set; }

        public string MachinePage
        {
            get { return $"https://securitycenter.windows.com/machines/{this.MachineId}"; }
        }

    }
}