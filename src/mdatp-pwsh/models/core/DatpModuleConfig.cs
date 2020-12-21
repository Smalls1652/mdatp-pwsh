using System;

using System.Text.Json.Serialization;

namespace MdatpPwsh.Models.Core
{
    public class DatpModuleConfig
    {
        public string PublicClientAppId { get; set; }
        public string TenantId { get; set; }
    }
}