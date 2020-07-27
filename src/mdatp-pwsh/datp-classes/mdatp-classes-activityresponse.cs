using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;

namespace MdatpPwsh
{
    namespace Classes
    {
        public class ActivityResponse
        {
            [JsonProperty("id")]
            public string ActivityId { get; set; }

            [JsonProperty("type")]
            public string ActivityType { get; set; }

            [JsonProperty("requestor")]
            public string Requestor { get; set; }

            [JsonProperty("requestorcomment")]
            public string RequestorComment { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("machineId")]
            public string MachineId { get; set; }

            [JsonProperty("creationDateTimeUtc")]
            public Nullable<DateTime> CreationDateTimeUtc { get; set; }

            [JsonProperty("lastUpdateTimeUtc")]
            public Nullable<DateTime> LastUpdateTimeUtc { get; set; }

            [JsonProperty("relatedFileInfo")]
            public FileIdentifierData RelatedFileInfo { get; set; }

        }

        public class ActivityResponseCollection
        {
            public List<ActivityResponse> value { get; set; }
        }

        public class InvestigationPkgDownload
        {
            [JsonProperty("value")]
            public Uri DownloadUri { get; set; }

            [JsonIgnore()]
            public string ActivityId { get; set; }

            public FileInfo DownloadPackage(DirectoryInfo downloadPath)
            {
                HttpClient downloadClient = new HttpClient();
                HttpRequestMessage downloadRequestMsg = new HttpRequestMessage(HttpMethod.Get, DownloadUri);
                HttpResponseMessage downloadedData = downloadClient.SendAsync(downloadRequestMsg).GetAwaiter().GetResult();
                downloadClient.Dispose();

                string outFilePath = Path.Combine(downloadPath.FullName, $"WDATP_Investigation_Package_{ActivityId}.zip");

                FileStream outFileWriter = new FileStream(outFilePath, FileMode.Create);
                downloadedData.Content.CopyToAsync(outFileWriter).GetAwaiter().GetResult();
                outFileWriter.Close();

                FileInfo outFile = new FileInfo(outFilePath);

                return outFile;
            }
        }
    }
}