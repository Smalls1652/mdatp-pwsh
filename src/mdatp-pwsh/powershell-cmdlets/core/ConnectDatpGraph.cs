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

            //Initialize the path to the module's config file in the user's profile 
            string userProfilePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            DirectoryInfo userProfile = new DirectoryInfo(userProfilePath);
            string configFilePath = Path.Combine(userProfile.FullName, ".mdatp-pwsh", "config.json");

            DatpModuleConfig moduleConfig = null;
            if (!(File.Exists(configFilePath)))
            {
                //Throw an error if the config file wasn't found.
                throw new Exception("No config file found. Run 'Set-DatpModuleConfig' on first run.");
            }
            else
            {
                //Read the contents of the config file and convert it to 'DatpModuleConfig' class
                StreamReader configReader = new StreamReader(configFilePath);
                moduleConfig = JsonSerializer.Deserialize<DatpModuleConfig>(configReader.ReadToEnd());
                configReader.Close();
            }

            IPublicClientApplication app = null;
            try
            {
                //Check to see if an existing DatpSessionClient already exists in memory
                app = GetSessionClient().App;
                WriteVerbose("PublicClient already in memory.");
            }
            catch
            {
                //Build the PublicClient object with the data in the module config
                WriteVerbose("Building PublicClient app object.");
                app = PublicClientApplicationBuilder.Create(moduleConfig.PublicClientAppId)
                    .WithAuthority($"https://login.microsoftonline.com/{moduleConfig.TenantId}")
                    .WithDefaultRedirectUri()
                    .Build();
            }

            //Initialize the token flow process with the newly built PublicClient app.
            PublicAuthenticationHelper TokenFlow = new PublicAuthenticationHelper(app);

            string[] scopes = new string[] {
                "https://securitycenter.microsoft.com/mtp/.default"
                };

            AuthenticationResult result = null;
            ConsoleCancelEventHandler cancelEventHandler = new ConsoleCancelEventHandler(cancelHandler); //Initialize the cancellation event handler if a cancel command is sent.

            try
            {
                Console.CancelKeyPress += cancelEventHandler; //Register the cancellation event handler to the cancel key combo
                CancellationToken token = cancellationTokenSource.Token;

                result = TokenFlow.GetDeviceCode(scopes, token).GetAwaiter().GetResult(); //Run the device code token flow
            }
            catch (TaskCanceledException e) //If the task is cancelled...
            {
                Console.CancelKeyPress -= cancelEventHandler; //Unregister the cancellation event handler
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
                Console.CancelKeyPress -= cancelEventHandler; //Unregister the cancellation event handler
                cancellationTokenSource.Dispose();
            }
            //The 'cancelEventHandler' **needs** to be unregistered from the cancel key combo; otherwise, it can cause the cancel key combo to cause the console to crash later on.

            //Initialize the session client and set it into the memory.
            DatpSessionClient sessionClient = new DatpSessionClient(new Uri("https://api.securitycenter.microsoft.com/api/v1.0/"), result, app);
            SessionState.PSVariable.Set(new PSVariable("DatpSessionClient", sessionClient, ScopedItemOptions.Private));

            WriteObject("You are now connected to the Defender for Endpoint API.");
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }

        protected void cancelHandler(object sender, ConsoleCancelEventArgs args) //Handler for cancellation requests
        {
            cancellationTokenSource.Cancel();
            args.Cancel = true;
        }
    }
}