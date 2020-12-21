using System;
using System.IO;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;

    [Cmdlet(VerbsData.Out, "DatpInvestigationPkg")]
    public class OutDatpInvestigationPkg : DatpCmdlet
    {

        [Parameter(Position = 0, Mandatory = true)]
        public string ActivityId
        {
            get { return activityId; }
            set { activityId = value; }
        }

        [Parameter(Position = 1, Mandatory = true)]
        public DirectoryInfo FolderPath
        {
            get { return folderPath; }
            set { folderPath = value; }
        }

        private string activityId;
        private DirectoryInfo folderPath;

        private string apiUri;

        protected override void BeginProcessing()
        {
            apiUri = $"machineactions/{activityId}/GetPackageUri";

            WriteVerbose($"Getting package for activity '{activityId}'.");

        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Starting api call.");
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            InvestigationPkgDownload apiResult = JsonSerializer.Deserialize<InvestigationPkgDownload>(apiJson);
            apiResult.ActivityId = ActivityId;

            WriteVerbose("Downloading investigation package.");
            FileInfo outFile = apiResult.DownloadPackage(folderPath);

            WriteObject(outFile);
        }
    }
}