using System;

using System.Text.Json.Serialization;

namespace MdatpPwsh.Models.Core
{
    public class DatpModuleConfig
    {
        public DatpModuleConfig() { }
        public DatpModuleConfig(string publicClientAppId, string tenantId)
        {
            PublicClientAppId = publicClientAppId;
            TenantId = tenantId;
        }
        public string PublicClientAppId { get; set; }
        public string TenantId { get; set; }
    }
}