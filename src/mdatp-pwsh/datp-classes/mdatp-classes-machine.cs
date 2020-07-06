using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MdatpPwsh
{
    namespace Classes
    {
        public class Machine
        {
            [JsonProperty("computerDnsName")]
            public string ComputerName { get; set; }

            [JsonProperty("id")]
            public string MachineId { get; set; }

            [JsonProperty("aadDeviceId")]
            public string AadDeviceId { get; set; }

            [JsonProperty("machineTags")]
            public string[] MachineTags { get; set; }

            [JsonProperty("firstSeen")]
            public DateTime FirstSeen { get; set; }

            [JsonProperty("LastSeen")]
            public DateTime LastSeen { get; set; }

            [JsonProperty("OsPlatform")]
            public string OsPlatform { get; set; }

            [JsonProperty("osVersion")]
            public string OsVersion { get; set; }

            [JsonProperty("osBuild")]
            public Nullable<Int64> OsBuild { get; set; }

            [JsonProperty("lastIpAddress")]
            public string LastIpAddress { get; set; }

            [JsonProperty("lastExternalIpAddress")]
            public string LastExternalIpAddress { get; set; }

            [JsonProperty("agentVersion")]
            public Version AgentVersion { get; set; }

            [JsonProperty("healthStatus")]
            public string HealthStatus { get; set; }

            [JsonProperty("rbacGroupId")]
            public Int64 RbacGroupId { get; set; }

            [JsonProperty("rbacGroupName")]
            public string RbacGroupName { get; set; }

            [JsonProperty("riskScore")]
            public string RiskScore { get; set; }

        }

        public class MachineCollection
        {
            public List<Machine> value { get; set; }
        }
    }
}