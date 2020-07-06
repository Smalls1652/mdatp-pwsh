namespace MdatpPwsh
{
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
}