using System;

using System.Text.Json.Serialization;

namespace MdatpPwsh.Models
{
    public class FileProperties
    {
        [JsonPropertyName("fileProductName")]
        public string FileProductName { get; set; }

        [JsonPropertyName("filePublisher")]
        public string FilePublisher { get; set; }

        [JsonPropertyName("sha1")]
        public string SHA1 { get; set; }

        [JsonPropertyName("sha256")]
        public string SHA256 { get; set; }

        [JsonPropertyName("md5")]
        public string MD5 { get; set; }

        [JsonPropertyName("size")]
        public Int64 FileSize { get; set; }

        [JsonPropertyName("fileType")]
        public string FileType { get; set; }

        [JsonPropertyName("isPeFile")]
        public bool IsPeFile { get; set; }

        [JsonPropertyName("globalPrevalence")]
        public Int64 GlobalPrevalence { get; set; }

        [JsonPropertyName("globalFirstObserved")]
        public DateTime GlobalFirstObserved { get; set; }

        [JsonPropertyName("globalLastObserved")]
        public DateTime GlobalLastObserved { get; set; }

        [JsonPropertyName("signer")]
        public string Signer { get; set; }

        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        [JsonPropertyName("signerHash")]
        public string SignerHash { get; set; }

        [JsonPropertyName("isValidCertificate")]
        public Nullable<bool> IsValidCertificate { get; set; }
    }
}