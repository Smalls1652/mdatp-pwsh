using System;
using System.Management.Automation;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Identity.Client;

using MdatpPwsh.Classes;
using MdatpPwsh.Classes.Post;

namespace MdatpPwsh
{
    [Cmdlet(VerbsCommon.Get, "DatpMachine")]
    [CmdletBinding(DefaultParameterSetName = "AllMachines")]
    public class GetDatpMachine : PSCmdlet
    {
        [Parameter(Position = 0, ParameterSetName = "SingleMachine", ValueFromPipelineByPropertyName = true)]
        public string MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private static string machineId;

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
                    apiUri = $"/machines/{machineId}";
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
                    Machine apiResult = JsonConvert.DeserializeObject<Machine>(apiJson);
                    WriteObject(apiResult);
                    break;

                case "AllMachines":
                    MachineCollection apiResults = JsonConvert.DeserializeObject<MachineCollection>(apiJson);

                    foreach (Machine item in apiResults.value)
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
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private static string machineId;

        private static string apiUri;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            apiUri = $"/machines/{machineId}/alerts";

            WriteVerbose($"Getting alerts triggered by '{machineId}'.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = new ApiCaller().MakeGetApiCall(apiUri, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            AlertCollection apiResult = JsonConvert.DeserializeObject<AlertCollection>(apiJson);

            foreach (Alert item in apiResult.value)
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
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private static string machineId;

        private static string apiUri;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            apiUri = $"/machines/{machineId}/logonusers";

            WriteVerbose($"Getting users who have logged onto '{machineId}'.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = new ApiCaller().MakeGetApiCall(apiUri, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            UserCollection apiResult = JsonConvert.DeserializeObject<UserCollection>(apiJson);

            foreach (User item in apiResult.value)
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
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public string MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private static string machineId;

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

            MachineTag postObj = new MachineTag();
            postObj.Value = tagName;
            postObj.Action = "Add";

            apiPost = JsonConvert.SerializeObject(postObj);

            apiUri = $"/machines/{machineId}/tags";

            WriteVerbose($"Adding tag, '{tagName}', to '{machineId}'.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = new ApiCaller().MakePostApiCall(apiUri, apiPost, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            Machine apiResult = JsonConvert.DeserializeObject<Machine>(apiJson);

            WriteObject(apiResult);
        }

        protected override void EndProcessing()
        {
        }
    }

    [Cmdlet(VerbsCommon.Remove, "DatpMachineTag")]
    public class RemoveDatpMachineTag : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public string MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private static string machineId;

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

            MachineTag postObj = new MachineTag();
            postObj.Value = tagName;
            postObj.Action = "Remove";

            apiPost = JsonConvert.SerializeObject(postObj);

            apiUri = $"/machines/{machineId}/tags";

            WriteVerbose($"Adding tag, '{tagName}', to '{machineId}'.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = new ApiCaller().MakePostApiCall(apiUri, apiPost, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            Machine apiResult = JsonConvert.DeserializeObject<Machine>(apiJson);

            WriteObject(apiResult);
        }

        protected override void EndProcessing()
        {
        }
    }

    [Cmdlet(VerbsLifecycle.Start, "DatpMachineScan")]
    public class StartDatpMachineScan : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public string MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private static string machineId;

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

            MachineScan postObj = new MachineScan();
            postObj.Comment = cmnt;
            postObj.ScanType = scanType;

            apiPost = JsonConvert.SerializeObject(postObj);

            apiUri = $"/machines/{machineId}/runAntiVirusScan";

            WriteVerbose($"Starting a '{scanType} Scan' on '{machineId}'.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = new ApiCaller().MakePostApiCall(apiUri, apiPost, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            WriteVerbose(apiJson);
            ActivityResponse apiResult = JsonConvert.DeserializeObject<ActivityResponse>(apiJson);

            WriteObject(apiResult);
        }

        protected override void EndProcessing()
        {
        }
    }

    [Cmdlet(VerbsCommon.Set, "DatpMachineIsolation")]
    public class SetDatpMachineIsolation : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public string MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private static string machineId;

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
        private static ActivityResponse apiResult;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            switch (isoType)
            {
                case "Full Isolation":
                    apiUri = $"/machines/{machineId}/isolate";
                    IsolateMachine isoFullPostObj = new IsolateMachine();
                    isoFullPostObj.Comment = cmnt;
                    isoFullPostObj.IsolationType = "Full";
                    apiPost = JsonConvert.SerializeObject(isoFullPostObj);
                    break;

                case "Selective Isolation":
                    apiUri = $"/machines/{machineId}/isolate";
                    IsolateMachine isoSelPostObj = new IsolateMachine();
                    isoSelPostObj.Comment = cmnt;
                    isoSelPostObj.IsolationType = "Selective";
                    apiPost = JsonConvert.SerializeObject(isoSelPostObj);
                    break;

                case "Release Isolation":
                    apiUri = $"/machines/{machineId}/unisolate";
                    UnIsolateMachine unIsoPost = new UnIsolateMachine();
                    unIsoPost.Comment = cmnt;
                    apiPost = JsonConvert.SerializeObject(unIsoPost);
                    break;
            }

            WriteVerbose($"Getting machine info for {machineId}");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = new ApiCaller().MakePostApiCall(apiUri, apiPost, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            apiResult = JsonConvert.DeserializeObject<ActivityResponse>(apiJson);

        }

        protected override void EndProcessing()
        {
            WriteObject(apiResult);
        }
    }

    [Cmdlet(VerbsCommon.Get, "DatpMachineAction")]
    [CmdletBinding(DefaultParameterSetName = "AllActivities")]
    public class GetDatpMachineAction : PSCmdlet
    {
        [Parameter(Position = 0, ParameterSetName = "SingleActivity")]
        public string ActivityId
        {
            get { return activityId; }
            set { activityId = value; }
        }
        private static string activityId;

        [Parameter(Position = 1, ParameterSetName = "AllActivities")]
        public SwitchParameter AllActivities
        {
            get { return allActivities; }
            set { allActivities = value; }
        }
        private static SwitchParameter allActivities;

        private static string apiUri;

        protected override void BeginProcessing()
        {
            if ((AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken") == null)
            {
                throw new Exception("Graph token not found.");
            }

            switch (ParameterSetName)
            {
                case "SingleActivity":
                    apiUri = $"/machineactions/{activityId}";
                    break;

                case "AllActivities":
                    apiUri = $"/machineactions";
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
                case "SingleActivity":
                    ActivityResponse apiResult = JsonConvert.DeserializeObject<ActivityResponse>(apiJson);
                    WriteObject(apiResult);
                    break;

                case "AllActivities":
                    ActivityResponseCollection apiResults = JsonConvert.DeserializeObject<ActivityResponseCollection>(apiJson);

                    foreach (ActivityResponse item in apiResults.value)
                    {
                        WriteObject(item);
                    }
                    break;
            }

        }
    }

    [Cmdlet(VerbsLifecycle.Start, "DatpInvestigationPkgCollection")]
    public class StartDatpInvestigationPkgCollection : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public string MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private static string machineId;

        [Parameter(Mandatory = true, Position = 1)]
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

            CollectInvestigationPackage postObj = new CollectInvestigationPackage();
            postObj.Comment = cmnt;

            apiPost = JsonConvert.SerializeObject(postObj);

            apiUri = $"/machines/{machineId}/collectInvestigationPackage";

            WriteVerbose($"Initiating investigaton package collection on '{machineId}'.");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Getting token from session.");
            AuthenticationResult token = (AuthenticationResult)SessionState.PSVariable.GetValue("DatpGraphToken");

            WriteVerbose("Starting api call.");
            HttpResponseMessage apiResponse = new ApiCaller().MakePostApiCall(apiUri, apiPost, token);

            string apiJson = apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            ActivityResponse apiResult = JsonConvert.DeserializeObject<ActivityResponse>(apiJson);

            WriteObject(apiResult);
        }

        protected override void EndProcessing()
        {
        }
    }

}