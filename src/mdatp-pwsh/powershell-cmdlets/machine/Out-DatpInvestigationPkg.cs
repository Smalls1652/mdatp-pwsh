using System;
using System.IO;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Helpers;

    [Cmdlet(VerbsData.Out, "DatpInvestigationPkg")]
    [OutputType(typeof(FileInfo))]
    public class OutDatpInvestigationPkg : DatpCmdlet
    {

        [Parameter(
            Position = 0,
            Mandatory = true
        )]
        public string ActivityId
        {
            get { return activityId; }
            set { activityId = value; }
        }
        private string activityId;

        [Parameter(
            Position = 1,
            Mandatory = true
        )]
        public DirectoryInfo FolderPath
        {
            get { return folderPath; }
            set { folderPath = value; }
        }
        private DirectoryInfo folderPath;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            string apiUri = $"machineactions/{activityId}/GetPackageUri";

            WriteVerbose($"Getting package for activity '{activityId}'.");
            string apiJson = SendApiCall(apiUri, null, HttpMethod.Get);

            InvestigationPkgDownload apiResult = new JsonConverter<InvestigationPkgDownload>(apiJson).Value;
            apiResult.ActivityId = ActivityId;

            WriteVerbose("Downloading investigation package.");
            FileInfo outFile = apiResult.DownloadPackage(folderPath);

            WriteObject(outFile);
        }
    }
}