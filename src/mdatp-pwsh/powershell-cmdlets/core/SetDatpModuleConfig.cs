using System.IO;
using System.Management.Automation;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models.Core;

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

            string configContents = JsonSerializer.Serialize<DatpModuleConfig>(configObj);

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