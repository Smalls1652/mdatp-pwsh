using System;

using System.Text.Json.Serialization;

namespace MdatpPwsh.Models
{
    public class FileIdentifierData
        {
            [JsonPropertyName("fileIdentifier")]
            public string FileIdentifier { get; set; }

            [JsonPropertyName("fileIdentifierType")]
            public string FileIdentifierType { get; set; }
        }
}