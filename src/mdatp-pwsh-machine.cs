using System;
using System.Management.Automation;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Identity.Client;

namespace mdatp_pwsh
{
    [Cmdlet(VerbsCommon.Get, "DatpMachine")]
    [CmdletBinding(DefaultParameterSetName = "AllMachines")]
    public class GetDatpMachine : PSCmdlet
    {
        [Parameter(Position = 0, ParameterSetName = "SingleMachine")]
        public string ComputerName
        {
            get { return computerName; }
            set { computerName = value; }
        }
        private static string computerName;

        [Parameter(Position = 1, ParameterSetName = "AllMachines")]
        public SwitchParameter AllMachines
        {
            get { return allMachines; }
            set { allMachines = value; }
        }
        private static SwitchParameter allMachines = true;

        private static string apiUri;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            switch (ParameterSetName)
            {
                case "SingleMachine":
                    apiUri = $"/machines/{computerName}";
                    break;

                case "AllMachines":
                    apiUri = $"/machines";
                    break;
            }
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = new ApiCaller().MakeGetApiCall(apiUri, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            WriteVerbose(apiJson);

            switch (ParameterSetName)
            {
                case "SingleMachine":
                    DatpMachine apiResult = JsonConvert.DeserializeObject<DatpMachine>(apiJson);
                    WriteObject(apiResult);
                    break;

                case "AllMachines":
                    DatpMachineCollection apiResults = JsonConvert.DeserializeObject<DatpMachineCollection>(apiJson);

                    foreach (DatpMachine item in apiResults.value)
                    {
                        WriteObject(item);
                    }
                    break;
            }

        }
    }

    [Cmdlet(VerbsCommon.Get, "DatpMachineAlerts")]
    public class GetDatpMachineAlerts : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public string ComputerName
        {
            get { return computerName; }
            set { computerName = value; }
        }
        private static string computerName;

        private static string apiUri;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            apiUri = $"/machines/{computerName}/alerts";

            WriteVerbose($"Getting alerts triggered by '{computerName}'.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = new ApiCaller().MakeGetApiCall(apiUri, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            DatpAlertCollection apiResult = JsonConvert.DeserializeObject<DatpAlertCollection>(apiJson);

            foreach (DatpAlert item in apiResult.value)
            {
                WriteObject(item);
            }

        }

        protected override void EndProcessing()
        {
        }
    }

    [Cmdlet(VerbsCommon.Get, "DatpMachineUsers")]
    public class GetDatpMachineUsers : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public string ComputerName
        {
            get { return computerName; }
            set { computerName = value; }
        }
        private static string computerName;

        private static string apiUri;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            apiUri = $"/machines/{computerName}/logonusers";

            WriteVerbose($"Getting users who have logged onto '{computerName}'.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = new ApiCaller().MakeGetApiCall(apiUri, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            DatpUserCollection apiResult = JsonConvert.DeserializeObject<DatpUserCollection>(apiJson);

            foreach (DatpUser item in apiResult.value)
            {
                WriteObject(item);
            }

        }

        protected override void EndProcessing()
        {
        }
    }

    /*
    [Cmdlet(VerbsCommon.Get, "DatpMachineByIp")]
    public class GetDatpMachineByIp : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public string IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }
        private static string ipAddress;

        private static string apiUri;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            DateTime currentDate = DateTime.Now;
            string lastMonth = currentDate.AddDays(-30).ToUniversalTime().ToString("s");

            apiUri = $"/machines/findbyip(ip='{ipAddress},timestamp={lastMonth}Z)";

            WriteVerbose($"Getting machines with the Ip Address of '{ipAddress}' in the last 30 days.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = new ApiCaller().MakeGetApiCall(apiUri, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            DatpMachineCollection apiResult = JsonConvert.DeserializeObject<DatpMachineCollection>(apiJson);

            foreach (DatpMachine item in apiResult.value)
            {
                WriteObject(item);
            }

        }

        protected override void EndProcessing()
        {
        }
    }
    */

    [Cmdlet(VerbsCommon.Add, "DatpMachineTag")]
    public class AddDatpMachineTag : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string ComputerName
        {
            get { return computerName; }
            set { computerName = value; }
        }
        private static string computerName;

        [Parameter(Mandatory = true, Position = 1)]
        public string TagName
        {
            get { return tagName; }
            set { tagName = value; }
        }
        private static string tagName;

        private static string apiUri;

        private static string apiPost;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            DatpMachineTagPost postObj = new DatpMachineTagPost();
            postObj.Value = tagName;
            postObj.Action = "Add";

            apiPost = JsonConvert.SerializeObject(postObj);

            apiUri = $"/machines/{computerName}/tags";

            WriteVerbose($"Adding tag, '{tagName}', to '{computerName}'.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = new ApiCaller().MakePostApiCall(apiUri, apiPost, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            DatpMachine apiResult = JsonConvert.DeserializeObject<DatpMachine>(apiJson);

            WriteObject(apiResult);
        }

        protected override void EndProcessing()
        {
        }
    }

    [Cmdlet(VerbsCommon.Remove, "DatpMachineTag")]
    public class RemoveDatpMachineTag : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string ComputerName
        {
            get { return computerName; }
            set { computerName = value; }
        }
        private static string computerName;

        [Parameter(Mandatory = true, Position = 1)]
        public string TagName
        {
            get { return tagName; }
            set { tagName = value; }
        }
        private static string tagName;

        private static string apiUri;

        private static string apiPost;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            DatpMachineTagPost postObj = new DatpMachineTagPost();
            postObj.Value = tagName;
            postObj.Action = "Remove";

            apiPost = JsonConvert.SerializeObject(postObj);

            apiUri = $"/machines/{computerName}/tags";

            WriteVerbose($"Adding tag, '{tagName}', to '{computerName}'.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = new ApiCaller().MakePostApiCall(apiUri, apiPost, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            DatpMachine apiResult = JsonConvert.DeserializeObject<DatpMachine>(apiJson);

            WriteObject(apiResult);
        }

        protected override void EndProcessing()
        {
        }
    }

    [Cmdlet(VerbsLifecycle.Start, "DatpMachineScan")]
    public class StartDatpMachineScan : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string ComputerName
        {
            get { return computerName; }
            set { computerName = value; }
        }
        private static string computerName;

        [Parameter(Position = 1)]
        [ValidateSet("Quick", "Full")]
        public string ScanType
        {
            get { return scanType; }
            set { scanType = value; }
        }
        private static string scanType = "Quick";

        [Parameter(Mandatory = true, Position = 2)]
        [ValidateNotNullOrEmpty()]
        public string Comment
        {
            get { return cmnt; }
            set { cmnt = value; }
        }
        private static string cmnt;

        private static string apiUri;

        private static string apiPost;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            DatpMachineScanPost postObj = new DatpMachineScanPost();
            postObj.Comment = cmnt;
            postObj.ScanType = scanType;

            apiPost = JsonConvert.SerializeObject(postObj);

            apiUri = $"/machines/{computerName}/runAntiVirusScan";

            WriteVerbose($"Starting a '{scanType} Scan' on '{computerName}'.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = new ApiCaller().MakePostApiCall(apiUri, apiPost, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            WriteVerbose(apiJson);
            DatpMachineScanResponse apiResult = JsonConvert.DeserializeObject<DatpMachineScanResponse>(apiJson);

            WriteObject(apiResult);
        }

        protected override void EndProcessing()
        {
        }
    }

    [Cmdlet(VerbsCommon.Set, "DatpMachineIsolation")]
    public class SetDatpMachineIsolation : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string ComputerName
        {
            get { return computerName; }
            set { computerName = value; }
        }
        private static string computerName;

        [Parameter(Mandatory = true, Position = 1)]
        public string Comment
        {
            get { return cmnt; }
            set { cmnt = value; }
        }
        private static string cmnt;

        [Parameter(Mandatory = true, Position = 2)]
        [ValidateSet(
            "Full Isolation",
            "Selective Isolation",
            "Release Isolation"
        )]
        public string IsolationType
        {
            get { return isoType; }
            set { isoType = value; }
        }
        private static string isoType;

        private static string apiUri;
        private static string apiPost;
        private static DatpIsolateResponse apiResult;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            switch (isoType)
            {
                case "Full Isolation":
                    apiUri = $"/machines/{computerName}/isolate";
                    DatpIsolatePost isoFullPostObj = new DatpIsolatePost();
                    isoFullPostObj.Comment = cmnt;
                    isoFullPostObj.IsolationType = "Full";
                    apiPost = JsonConvert.SerializeObject(isoFullPostObj);
                    break;

                case "Selective Isolation":
                    apiUri = $"/machines/{computerName}/isolate";
                    DatpIsolatePost isoSelPostObj = new DatpIsolatePost();
                    isoSelPostObj.Comment = cmnt;
                    isoSelPostObj.IsolationType = "Selective";
                    apiPost = JsonConvert.SerializeObject(isoSelPostObj);
                    break;

                case "Release Isolation":
                    apiUri = $"/machines/{computerName}/unisolate";
                    DatpUnIsolatePost unIsoPost = new DatpUnIsolatePost();
                    unIsoPost.Comment = cmnt;
                    apiPost = JsonConvert.SerializeObject(unIsoPost);
                    break;
            }

            WriteVerbose($"Getting machine info for {computerName}");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = new ApiCaller().MakePostApiCall(apiUri, apiPost, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            apiResult = JsonConvert.DeserializeObject<DatpIsolateResponse>(apiJson);

        }

        protected override void EndProcessing()
        {
            WriteObject(apiResult);
        }
    }

}