using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

using System.Text.Json;
using Microsoft.Identity.Client;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models.Core;
    using MdatpPwsh.Session;

    [Cmdlet(VerbsCommunications.Connect, "DatpGraph")]
    public class ConnectDatpGraph : DatpCmdlet
    {

        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

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

                moduleConfig = JsonSerializer.Deserialize<DatpModuleConfig>(configReader.ReadToEnd());

                configReader.Close();
            }

            IPublicClientApplication app = null;

            try
            {
                app = GetSessionClient().App;
                WriteVerbose("PublicClient already in memory.");
            }
            catch
            {
                WriteVerbose("Building PublicClient app object.");
                app = PublicClientApplicationBuilder.Create(moduleConfig.PublicClientAppId)
                    .WithAuthority($"https://login.microsoftonline.com/{moduleConfig.TenantId}")
                    .WithDefaultRedirectUri()
                    .Build();
            }

            PublicAuthenticationHelper TokenFlow = new PublicAuthenticationHelper(app);

            string[] scopes = new string[] {
                "https://securitycenter.microsoft.com/mtp/.default"
                };

            AuthenticationResult result = null;

            try
            {
                Console.CancelKeyPress += new ConsoleCancelEventHandler(cancelHandler);
                CancellationToken token = cancellationTokenSource.Token;

                result = TokenFlow.GetDeviceCode(scopes, token).GetAwaiter().GetResult();
            }
            catch (TaskCanceledException e)
            {
                cancellationTokenSource.Dispose();

                ErrorRecord psErrorRecordObj = new ErrorRecord(
                    e,
                    "LoginCancelled",
                    ErrorCategory.CloseError,
                    result
                );

                ThrowTerminatingError(psErrorRecordObj);
            }
            finally
            {
                cancellationTokenSource.Dispose();
            }

            DatpSessionClient sessionClient = new DatpSessionClient(new Uri("https://api.securitycenter.microsoft.com/api/v1.0/"), result, app);

            SessionState.PSVariable.Set(new PSVariable("DatpSessionClient", sessionClient, ScopedItemOptions.Private));
            WriteObject("You are now connected to the Defender ATP API.");
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }

        protected void cancelHandler(object sender, ConsoleCancelEventArgs args)
        {
            cancellationTokenSource.Cancel();
            args.Cancel = true;
        }
    }
}