using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace mdatp_pwsh
{
    namespace Classes
    {
        public class File
        {
            [JsonProperty("fileProductName")]
            public string FileProductName { get; set; }

            [JsonProperty("filePublisher")]
            public string FilePublisher { get; set; }

            [JsonProperty("sha1")]
            public string SHA1 { get; set; }

            [JsonProperty("sha256")]
            public string SHA256 { get; set; }

            [JsonProperty("md5")]
            public string MD5 { get; set; }

            [JsonProperty("size")]
            public Int64 FileSize { get; set; }

            [JsonProperty("fileType")]
            public string FileType { get; set; }

            [JsonProperty("isPeFile")]
            public Boolean IsPeFile { get; set; }

            [JsonProperty("globalPrevalence")]
            public Int64 GlobalPrevalence { get; set; }

            [JsonProperty("globalFirstObserved")]
            public DateTime GlobalFirstObserved { get; set; }

            [JsonProperty("globalLastObserved")]
            public DateTime GlobalLastObserved { get; set; }

            [JsonProperty("signer")]
            public string Signer { get; set; }

            [JsonProperty("issuer")]
            public string Issuer { get; set; }

            [JsonProperty("signerHash")]
            public string SignerHash { get; set; }

            [JsonProperty("isValidCertificate")]
            public Boolean IsValidCertificate { get; set; }
        }

        public class FileIdentifierData
        {
            [JsonProperty("fileIdentifier")]
            public string FileIdentifier { get; set; }

            [JsonProperty("fileIdentifierType")]
            public string FileIdentifierType { get; set; }
        }
    }
}