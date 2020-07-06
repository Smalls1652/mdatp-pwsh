using System;
using System.IO;
using System.Management.Automation;
using Newtonsoft.Json;
using Microsoft.Identity.Client;

namespace MdatpPwsh
{
    [Cmdlet(VerbsCommunications.Connect, "DatpGraph")]
    public class ConnectDatpGraph : PSCmdlet
    {
        protected override void ProcessRecord()
        {

            string userProfilePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);

            DirectoryInfo userProfile = new DirectoryInfo(userProfilePath);

            string configFilePath = Path.Combine(userProfile.FullName, ".mdatp-pwsh", "config.json");

            DatpModuleConfig moduleConfig = null;

            if (!(File.Exists(configFilePath)))
            {
                throw new Exception("No config file found. Run 'Set-DatpModuleConfig' on first run.");
            }
            else
            {
                StreamReader configReader = new StreamReader(configFilePath);

                moduleConfig = JsonConvert.DeserializeObject<DatpModuleConfig>(configReader.ReadToEnd());

                configReader.Close();
            }

            WriteVerbose("Building PublicClient app object.");
            var app = PublicClientApplicationBuilder.Create(moduleConfig.PublicClientAppId)
                .WithAuthority($"https://login.microsoftonline.com/{moduleConfig.TenantId}")
                .WithDefaultRedirectUri()
                .Build();

            var TokenFlow = new PublicAuthenticationHelper(app);

            string[] scopes = new string[] {
                "https://securitycenter.microsoft.com/mtp/.default"
                };

            AuthenticationResult result = null;
            WriteVerbose("Starting token flow.");
            result = TokenFlow.SilentAcquire(scopes).GetAwaiter().GetResult();

            if (result == null)
            {
                WriteVerbose("Attempting to get token through device code...");
                try
                {
                    result = TokenFlow.GetDeviceCode(scopes).GetAwaiter().GetResult();
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
            SessionState.PSVariable.Set(new PSVariable("DatpGraphToken", result, ScopedItemOptions.Private));
            WriteObject(result);
        }

    }

    [Cmdlet(VerbsCommon.Set, "DatpModuleConfig")]
    public class SetDatpModuleConfig : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string PublicClientAppId
        {
            get { return publicClientAppId; }
            set { publicClientAppId = value; }
        }
        private static string publicClientAppId;

        [Parameter(Mandatory = true, Position = 1)]
        public string TenantId
        {
            get { return tenantId; }
            set { tenantId = value; }
        }
        private static string tenantId;

        protected override void ProcessRecord()
        {
            DatpModuleConfig configObj = new DatpModuleConfig();
            configObj.PublicClientAppId = publicClientAppId;
            configObj.TenantId = tenantId;

            string configContents = JsonConvert.SerializeObject(configObj);

            string userProfilePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);

            DirectoryInfo userProfile = new DirectoryInfo(userProfilePath);

            DirectoryInfo configFolder = null;
            try
            {
                configFolder = userProfile.CreateSubdirectory(".mdatp-pwsh");
            }
            catch (IOException)
            {
                WriteVerbose("Settings folder already exists.");
            }

            string configFile = Path.Combine(configFolder.FullName, "config.json");

            try
            {
                File.Create(configFile).Close();
            }
            catch (IOException)
            {
                WriteVerbose("Config file already exists.");
            }

            StreamWriter configWriter = new StreamWriter(configFile);

            configWriter.Write(configContents);

            configWriter.Close();

            WriteObject(configObj);
        }
    }
}
