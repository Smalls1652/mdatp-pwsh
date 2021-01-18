using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

using System.Text.Json.Serialization;

namespace MdatpPwsh.Models
{
    public class InvestigationPkgDownload
    {
        [JsonPropertyName("value")]
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