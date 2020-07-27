using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MdatpPwsh
{
    namespace Classes
    {
        public class FileProperties
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
            public dynamic IsPeFile
            {
                get { return isPeFile; }
                set
                { 
                    switch (null == value)
                    {
                        case true:
                            isPeFile = false;
                            break;

                        default:
                            isPeFile = true;
                            break;

                    }
                }
            }
            private dynamic isPeFile;

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
            public dynamic IsValidCertificate
            {
                get { return isValidCertificate; }
                set
                { 
                    switch (null == value)
                    {
                        case true:
                            isValidCertificate = false;
                            break;

                        default:
                            isValidCertificate = true;
                            break;

                    }
                }
            }
            private dynamic isValidCertificate;
        }

        public class FileIdentifierData
        {
            [JsonProperty("fileIdentifier")]
            public string FileIdentifier { get; set; }

            [JsonProperty("fileIdentifierType")]
            public string FileIdentifierType { get; set; }
        }

        public class FileStats
        {
            [JsonProperty("sha1")]
            public string SHA1 { get; set; }

            [JsonProperty("orgPrevalence")]
            public int OrgPrevalence { get; set; }

            [JsonProperty("orgFirstSeen")]
            public Nullable<DateTime> OrgFirstSeen { get; set; }

            [JsonProperty("orgLastSeen")]
            public Nullable<DateTime> OrgLastSeen { get; set; }

            [JsonProperty("globalPrevalence")]
            public int GlobalPrevalence { get; set; }

            [JsonProperty("globalFirstObserved")]
            public Nullable<DateTime> GlobalFirstObserved { get; set; }

            [JsonProperty("globalLastObserved")]
            public Nullable<DateTime> GlobalLastObserved { get; set; }

            [JsonProperty("topFileNames")]
            public List<string> TopFileNames { get; set; }
        }
    }
}