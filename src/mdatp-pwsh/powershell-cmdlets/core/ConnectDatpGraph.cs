using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Threading.Tasks;
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
            IPublicClientApplication app = PublicClientApplicationBuilder.Create(moduleConfig.PublicClientAppId)
                .WithAuthority($"https://login.microsoftonline.com/{moduleConfig.TenantId}")
                .WithDefaultRedirectUri()
                .Build();

            PublicAuthenticationHelper TokenFlow = new PublicAuthenticationHelper(app);

            string[] scopes = new string[] {
                "https://securitycenter.microsoft.com/mtp/.default"
                };

            AuthenticationResult result = null;

            try
            {
                result = TokenFlow.GetDeviceCode(scopes).GetAwaiter().GetResult();
            }
            catch (System.Exception e)
            {
                throw e;
            }

            SessionState.PSVariable.Set(new PSVariable("DatpGraphToken", result, ScopedItemOptions.Private));
            WriteObject(result);
        }

    }
}