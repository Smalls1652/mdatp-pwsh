using System;
using System.IO;
using System.Management.Automation;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Identity.Client;

namespace MdatpPwsh
{
    using Classes;

    [Cmdlet(VerbsData.Out, "DatpInvestigationPkg")]
    public class OutDatpInvestigationPkg : PSCmdlet
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
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            apiUri = $"machineactions/{activityId}/GetPackageUri";

            WriteVerbose($"Getting package for activity '{activityId}'.");

        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = null;

            InvokeDatpApiCall invokeDatpApiCall = new InvokeDatpApiCall(apiUri, token, HttpMethod.Get);
            foreach (HttpResponseMessage r in invokeDatpApiCall.Invoke<HttpResponseMessage>())
            {
                apiResponse = r;
            }

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            InvestigationPkgDownload apiResult = JsonConvert.DeserializeObject<InvestigationPkgDownload>(apiJson);
            apiResult.ActivityId = ActivityId;

            WriteVerbose("Downloading investigation package.");
            FileInfo outFile = apiResult.DownloadPackage(folderPath);

            WriteObject(outFile);
        }
    }
}